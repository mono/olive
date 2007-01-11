//
// MessageSecurityBindingSupport.cs
//
// Author:
//	Atsushi Enomoto <atsushi@ximian.com>
//
// Copyright (C) 2005-2007 Novell, Inc.  http://www.novell.com
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Net.Security;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Security;
using System.ServiceModel.Security.Tokens;

using ReqType = System.ServiceModel.Security.Tokens.ServiceModelSecurityTokenRequirement;

namespace System.ServiceModel.Channels
{
	internal class SupportingTokenInfo
	{
		public SupportingTokenInfo (SecurityToken token,
			SecurityTokenAttachmentMode mode,
			bool isOptional)
		{
			Token = token;
			Mode = mode;
			IsOptional = isOptional;
		}

		public SecurityToken Token;
		public SecurityTokenAttachmentMode Mode;
		public bool IsOptional;
	}

	internal class SupportingTokenInfoCollection : Collection<SupportingTokenInfo>
	{
		protected override void InsertItem (int index, SupportingTokenInfo item)
		{
			foreach (SupportingTokenInfo i in this)
				if (i.Token.GetType () == item.Token.GetType ())
					throw new ArgumentException (String.Format ("Supporting tokens do not allow multiple SecurityTokens of the same type: {0}", i.Token.GetType ()));
			base.InsertItem (index, item);
		}
	}

	internal abstract class MessageSecurityBindingSupport
	{
		SecurityTokenManager manager;
		ChannelProtectionRequirements requirements;
		SecurityTokenSerializer serializer;
		SecurityBindingElementSupport element_support;

		// only filled at prepared state.
		internal SecurityToken encryption_token;
		internal SecurityToken signing_token;
		internal SecurityTokenAuthenticator authenticator;
		internal SecurityTokenResolver auth_token_resolver;

		protected MessageSecurityBindingSupport (
			SecurityBindingElementSupport elementSupport,
			SecurityTokenManager manager,
			ChannelProtectionRequirements requirements)
		{
			element_support = elementSupport;
			Initialize (manager, requirements);
		}

		public void Initialize (SecurityTokenManager manager,
			ChannelProtectionRequirements requirements)
		{
			this.manager = manager;
			if (requirements == null)
				requirements = new ChannelProtectionRequirements ();
			this.requirements = requirements;
		}

		public ChannelProtectionRequirements ChannelRequirements {
			get { return requirements; }
		}

		public SecurityTokenManager SecurityTokenManager {
			get { return manager; }
		}

		public SecurityTokenSerializer TokenSerializer {
			get {
				if (serializer == null)
					serializer = manager.CreateSecurityTokenSerializer (Element.MessageSecurityVersion.SecurityTokenVersion);
				return serializer;
			}
		}

		public SecurityTokenAuthenticator TokenAuthenticator {
			get { return authenticator; }
		}

		public SecurityTokenResolver OutOfBandTokenResolver {
			get { return auth_token_resolver; }
		}

		public SecurityToken EncryptionToken {
			get { return encryption_token; }
		}

		public SecurityToken SigningToken {
			get { return signing_token; }
		}

		#region element_support

		public SecurityBindingElement Element {
			get { return element_support.Element; }
		}

		public bool AllowSerializedSigningTokenOnReply {
			get { return element_support.AllowSerializedSigningTokenOnReply; }
		}

		public MessageProtectionOrder MessageProtectionOrder { 
			get { return element_support.MessageProtectionOrder; }
		}

		public SecurityTokenParameters InitiatorParameters { 
			get { return element_support.InitiatorParameters; }
		}

		public SecurityTokenParameters RecipientParameters { 
			get { return element_support.RecipientParameters; }
		}

		public bool RequireSignatureConfirmation {
			get { return element_support.RequireSignatureConfirmation; }
		}

		public string DefaultSignatureAlgorithm {
			get { return element_support.DefaultSignatureAlgorithm; }
		}

		#endregion

		public SecurityTokenProvider CreateTokenProvider (SecurityTokenRequirement requirement)
		{
			return manager.CreateSecurityTokenProvider (requirement);
		}

		public SecurityTokenAuthenticator CreateTokenAuthenticator (SecurityTokenRequirement requirement, out SecurityTokenResolver resolver)
		{
			return manager.CreateSecurityTokenAuthenticator (requirement, out resolver);
		}
	}

	internal class InitiatorMessageSecurityBindingSupport : MessageSecurityBindingSupport
	{
		ChannelFactoryBase factory;

		public InitiatorMessageSecurityBindingSupport (
			SecurityBindingElementSupport elementSupport,
			SecurityTokenManager manager,
			ChannelProtectionRequirements requirements)
			: base (elementSupport, manager, requirements)
		{
		}

		public void Prepare (ChannelFactoryBase factory, EndpointAddress address)
		{
			this.factory = factory;

			SecurityTokenRequirement r = new RecipientServiceModelSecurityTokenRequirement ();
			RecipientParameters.CallInitializeSecurityTokenRequirement (r);

			authenticator = CreateTokenAuthenticator (r, out auth_token_resolver);

			encryption_token = GetEncryptionToken (address, RecipientParameters);
			signing_token = GetSigningToken (address, InitiatorParameters);
		}

		public void Release ()
		{
			authenticator = null;

			IDisposable disposable = signing_token as IDisposable;
			if (disposable != null)
				disposable.Dispose ();
			signing_token = null;

			disposable = encryption_token as IDisposable;
			if (disposable != null)
				disposable.Dispose ();
			encryption_token = null;

			this.factory = null;
		}

		SecurityToken GetEncryptionToken (EndpointAddress targetAddress, SecurityTokenParameters targetParams)
		{
			SecurityTokenRequirement requirement =
				new InitiatorServiceModelSecurityTokenRequirement ();
//			requirement.Properties [ReqType.IssuerAddressProperty] = targetAddress;
			requirement.Properties [ReqType.TargetAddressProperty] = targetAddress;
			requirement.KeyUsage = SecurityKeyUsage.Exchange;
			requirement.Properties [ReqType.SecurityBindingElementProperty] = Element;
			requirement.Properties [ReqType.MessageSecurityVersionProperty] =
				Element.MessageSecurityVersion.SecurityTokenVersion;

			targetParams.CallInitializeSecurityTokenRequirement (requirement);

			SecurityTokenProvider provider =
				CreateTokenProvider (requirement);
			ICommunicationObject obj = provider as ICommunicationObject;
			try {
				if (obj != null)
					obj.Open (factory.DefaultSendTimeout);
				return provider.GetToken (factory.DefaultSendTimeout);
			} finally {
				if (obj != null && obj.State == CommunicationState.Opened)
					obj.Close ();
			}
		}

		SecurityToken GetSigningToken (EndpointAddress address, SecurityTokenParameters targetParams)
		{
			if (!targetParams.InternalSupportsClientAuthentication ||
			    !targetParams.InternalHasAsymmetricKey) {
				if (RequireSignatureConfirmation)
					throw new InvalidOperationException ("The security token parameters do not support signing.");
				return null;
			}

			SecurityTokenRequirement requirement =
				new InitiatorServiceModelSecurityTokenRequirement ();
//			requirement.Properties [ReqType.IssuerAddressProperty] = address;
			requirement.Properties [ReqType.TargetAddressProperty] = address;
			requirement.KeyUsage = SecurityKeyUsage.Signature;
			requirement.Properties [ReqType.SecurityBindingElementProperty] = Element;
			requirement.Properties [ReqType.MessageSecurityVersionProperty] =
				Element.MessageSecurityVersion.SecurityTokenVersion;

			targetParams.CallInitializeSecurityTokenRequirement (requirement);

			SecurityTokenProvider provider =
				CreateTokenProvider (requirement);
			ICommunicationObject obj = provider as ICommunicationObject;
			try {
				if (obj != null)
					obj.Open (factory.DefaultSendTimeout);
				return provider.GetToken (factory.DefaultSendTimeout);
			} finally {
				if (obj != null && obj.State == CommunicationState.Opened)
					obj.Close ();
			}
		}

		public SupportingTokenInfoCollection CollectInitiatorSupportingTokens (
			string action,
			EndpointAddress to)
		{
			SupportingTokenInfoCollection tokens =
				new SupportingTokenInfoCollection ();

			SupportingTokenParameters supp;

			CollectInitiatorSupportingTokensCore (tokens, Element.EndpointSupportingTokenParameters, to, true);
			if (Element.OperationSupportingTokenParameters.TryGetValue (action, out supp))
				CollectInitiatorSupportingTokensCore (tokens, supp, to, true);
			CollectInitiatorSupportingTokensCore (tokens, Element.OptionalEndpointSupportingTokenParameters, to, false);
			if (Element.OptionalOperationSupportingTokenParameters.TryGetValue (action, out supp))
				CollectInitiatorSupportingTokensCore (tokens, supp, to, false);

			return tokens;
		}

		void CollectInitiatorSupportingTokensCore (
			SupportingTokenInfoCollection l,
			SupportingTokenParameters s,
			EndpointAddress to,
			bool required)
		{
			foreach (SecurityTokenParameters p in s.Signed)
				l.Add (new SupportingTokenInfo (GetEncryptionToken (to, p), SecurityTokenAttachmentMode.Signed, required));
			foreach (SecurityTokenParameters p in s.Endorsing)
				l.Add (new SupportingTokenInfo (GetEncryptionToken (to, p), SecurityTokenAttachmentMode.Endorsing, required));
			foreach (SecurityTokenParameters p in s.SignedEndorsing)
				l.Add (new SupportingTokenInfo (GetEncryptionToken (to, p), SecurityTokenAttachmentMode.SignedEndorsing, required));
			foreach (SecurityTokenParameters p in s.SignedEncrypted)
				l.Add (new SupportingTokenInfo (GetEncryptionToken (to, p), SecurityTokenAttachmentMode.SignedEncrypted, required));
		}
	}

	class RecipientMessageSecurityBindingSupport : MessageSecurityBindingSupport
	{
		ChannelListenerBase listener;

		public RecipientMessageSecurityBindingSupport (
			SecurityBindingElementSupport elementSupport,
			SecurityTokenManager manager,
			ChannelProtectionRequirements requirements)
			: base (elementSupport, manager, requirements)
		{
		}

		public void Prepare (Uri listenUri, ChannelListenerBase listener)
		{
			this.listener = listener;

			SecurityTokenRequirement r = new RecipientServiceModelSecurityTokenRequirement ();
			RecipientParameters.CallInitializeSecurityTokenRequirement (r);

			authenticator = CreateTokenAuthenticator (r, out auth_token_resolver);

			encryption_token = GetEncryptionToken (listenUri, InitiatorParameters);
			signing_token = GetSigningToken (listenUri, RecipientParameters);
		}

		public void Release ()
		{
			authenticator = null;

			IDisposable disposable = signing_token as IDisposable;
			if (disposable != null)
				disposable.Dispose ();
			signing_token = null;

			disposable = encryption_token as IDisposable;
			if (disposable != null)
				disposable.Dispose ();
			encryption_token = null;

			this.listener = null;
		}

		public SupportingTokenInfoCollection CollectRecipientSupportingTokens (
			string action,
			Uri listenUri)
		{
			SupportingTokenInfoCollection tokens =
				new SupportingTokenInfoCollection ();

			SupportingTokenParameters supp;

			CollectRecipientSupportingTokensCore (tokens, Element.EndpointSupportingTokenParameters, listenUri, true);
			if (Element.OperationSupportingTokenParameters.TryGetValue (action, out supp))
				CollectRecipientSupportingTokensCore (tokens, supp, listenUri, true);
			CollectRecipientSupportingTokensCore (tokens, Element.OptionalEndpointSupportingTokenParameters, listenUri, false);
			if (Element.OptionalOperationSupportingTokenParameters.TryGetValue (action, out supp))
				CollectRecipientSupportingTokensCore (tokens, supp, listenUri, false);

			return tokens;
		}

		void CollectRecipientSupportingTokensCore (
			SupportingTokenInfoCollection l,
			SupportingTokenParameters s,
			Uri listenUri,
			bool required)
		{
			foreach (SecurityTokenParameters p in s.Signed)
				l.Add (new SupportingTokenInfo (GetEncryptionToken (listenUri, p), SecurityTokenAttachmentMode.Signed, required));
			foreach (SecurityTokenParameters p in s.Endorsing)
				l.Add (new SupportingTokenInfo (GetEncryptionToken (listenUri, p), SecurityTokenAttachmentMode.Endorsing, required));
			foreach (SecurityTokenParameters p in s.SignedEndorsing)
				l.Add (new SupportingTokenInfo (GetEncryptionToken (listenUri, p), SecurityTokenAttachmentMode.SignedEndorsing, required));
			foreach (SecurityTokenParameters p in s.SignedEncrypted)
				l.Add (new SupportingTokenInfo (GetEncryptionToken (listenUri, p), SecurityTokenAttachmentMode.SignedEncrypted, required));
		}

		SecurityToken GetSigningToken (Uri listenUri, SecurityTokenParameters targetParams)
		{
			SecurityTokenRequirement requirement =
				new RecipientServiceModelSecurityTokenRequirement ();
			requirement.Properties [ReqType.ListenUriProperty] = listenUri;
			requirement.KeyUsage = SecurityKeyUsage.Signature;
			requirement.Properties [ReqType.SecurityBindingElementProperty] = Element;
			requirement.Properties [ReqType.MessageSecurityVersionProperty] =
				Element.MessageSecurityVersion.SecurityTokenVersion;

			targetParams.CallInitializeSecurityTokenRequirement (requirement);

			SecurityTokenProvider provider =
				CreateTokenProvider (requirement);
			ICommunicationObject obj = provider as ICommunicationObject;
			try {
				if (obj != null)
					obj.Open (listener.DefaultSendTimeout);
				return provider.GetToken (listener.DefaultSendTimeout);
			} finally {
				if (obj != null && obj.State == CommunicationState.Opened)
					obj.Close ();
			}
		}

		SecurityToken GetEncryptionToken (Uri listenUri, SecurityTokenParameters targetParams)
		{
			SecurityTokenRequirement requirement =
				new RecipientServiceModelSecurityTokenRequirement ();
			requirement.Properties [ReqType.ListenUriProperty] = listenUri;
			requirement.KeyUsage = SecurityKeyUsage.Exchange;
			requirement.Properties [ReqType.SecurityBindingElementProperty] = Element;
			requirement.Properties [ReqType.MessageSecurityVersionProperty] =
				Element.MessageSecurityVersion.SecurityTokenVersion;

			targetParams.CallInitializeSecurityTokenRequirement (requirement);

			SecurityTokenProvider provider =
				CreateTokenProvider (requirement);
			ICommunicationObject obj = provider as ICommunicationObject;
			try {
				if (obj != null)
					obj.Open (listener.DefaultSendTimeout);
				return provider.GetToken (listener.DefaultSendTimeout);
			} finally {
				if (obj != null && obj.State == CommunicationState.Opened)
					obj.Close ();
			}
		}
	}

	internal abstract class SecurityBindingElementSupport
	{
		public abstract SecurityBindingElement Element { get; }

		public abstract bool AllowSerializedSigningTokenOnReply { get; }

		public abstract MessageProtectionOrder MessageProtectionOrder { get; }

		public abstract SecurityTokenParameters InitiatorParameters { get; }

		public abstract SecurityTokenParameters RecipientParameters { get; }

		public abstract bool RequireSignatureConfirmation { get; }

		public abstract string DefaultSignatureAlgorithm { get; }
	}

	internal class SymmetricSecurityBindingElementSupport : SecurityBindingElementSupport
	{
		SymmetricSecurityBindingElement element;

		public SymmetricSecurityBindingElementSupport (
			SymmetricSecurityBindingElement element)
		{
			this.element = element;
		}

		public override SecurityBindingElement Element {
			get { return element; }
		}

		// FIXME: const true or false
		public override bool AllowSerializedSigningTokenOnReply {
			get { throw new NotImplementedException (); }
		}

		public override MessageProtectionOrder MessageProtectionOrder {
			get { return element.MessageProtectionOrder; }
		}

		public override SecurityTokenParameters InitiatorParameters {
			get { return element.ProtectionTokenParameters; }
		}

		public override SecurityTokenParameters RecipientParameters {
			get { return element.ProtectionTokenParameters; }
		}

		public override bool RequireSignatureConfirmation {
			get { return element.RequireSignatureConfirmation; }
		}

		public override string DefaultSignatureAlgorithm {
			get { return element.DefaultAlgorithmSuite.DefaultSymmetricSignatureAlgorithm; }
		}
	}

	internal class AsymmetricSecurityBindingElementSupport : SecurityBindingElementSupport
	{
		AsymmetricSecurityBindingElement element;

		public AsymmetricSecurityBindingElementSupport (
			AsymmetricSecurityBindingElement element)
		{
			this.element = element;
		}

		public override bool AllowSerializedSigningTokenOnReply {
			get { return element.AllowSerializedSigningTokenOnReply; }
		}

		public override SecurityBindingElement Element {
			get { return element; }
		}

		public override MessageProtectionOrder MessageProtectionOrder {
			get { return element.MessageProtectionOrder; }
		}

		public override SecurityTokenParameters InitiatorParameters {
			get { return element.InitiatorTokenParameters; }
		}

		public override SecurityTokenParameters RecipientParameters {
			get { return element.RecipientTokenParameters; }
		}

		public override bool RequireSignatureConfirmation {
			get { return element.RequireSignatureConfirmation; }
		}

		public override string DefaultSignatureAlgorithm {
			get { return element.DefaultAlgorithmSuite.DefaultAsymmetricSignatureAlgorithm; }
		}
	}
}
