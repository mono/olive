//
// Constants.cs
//
// Author:
//	Atsushi Enomoto <atsushi@ximian.com>
//
// Copyright (C) 2006 Novell, Inc (http://www.novell.com)
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


namespace System.ServiceModel
{
	internal class Constants
	{
		public const string WSA1 = "http://www.w3.org/2005/08/addressing";

		public const string WsaAnonymousUri = "http://www.w3.org/2005/08/addressing/anonymous";

		public const string MSSerialization = "http://schemas.microsoft.com/2003/10/Serialization/";

		public const string WSSX509Token = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-x509-token-profile-1.0#X509v3";

		public const string XmlDsig = "http://www.w3.org/2000/09/xmldsig#";

		public const string WSSSamlToken = "http://docs.oasis-open.org/wss/oasis-wss-saml-token-profile-1.1#SAMLV1.1";

		public const string WSSUserNameToken = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#UsernameToken";

		public const string WsscContextToken = "http://schemas.xmlsoap.org/ws/2005/02/sc/sct";

		public const string WSSKerberosToken = "http://docs.oasis-open.org/wss/oasis-wss-kerberos-token-profile-1.1#GSS_Kerberosv5_AP_REQ";

		public const string WstNamespace = "http://schemas.xmlsoap.org/ws/2005/02/trust";
		public const string WssNamespace = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd";
		public const string WspNamespace = "http://schemas.xmlsoap.org/ws/2004/09/policy";
		public const string WsaNamespace = "http://www.w3.org/2005/08/addressing";
		public const string WsuNamespace = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd";
		public const string WsscNamespace = "http://schemas.xmlsoap.org/ws/2005/02/sc";

		public const string WstIssueAction = "http://schemas.xmlsoap.org/ws/2005/02/trust/RST/Issue";

		public const string WstRenewAction = "http://schemas.xmlsoap.org/ws/2005/02/trust/RST/Renew";

		public const string WstCancelAction = "http://schemas.xmlsoap.org/ws/2005/02/trust/RST/Cancel";

		public const string WstValidateAction = "http://schemas.xmlsoap.org/ws/2005/02/trust/RST/Validate";

		public const string WstIssueReplyAction = "http://schemas.xmlsoap.org/ws/2005/02/trust/RSTR/Issue";

		public const string WstRenewReplyAction = "http://schemas.xmlsoap.org/ws/2005/02/trust/RSTR/Renew";

		public const string WstCancelReplyAction = "http://schemas.xmlsoap.org/ws/2005/02/trust/RSTR/Cancel";

		public const string WstValidateReplyAction = "http://schemas.xmlsoap.org/ws/2005/02/trust/RSTR/Validate";
	}
}
