using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Xml;

using ConfigurationType = System.Configuration.Configuration;

namespace System.ServiceModel.Configuration
{
// AddressHeaderCollectionElement
	public partial class AddressHeaderCollectionElement
	{
		[MonoTODO]
		protected override void DeserializeElement (
			XmlReader reader, bool serializeCollectionKey)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		protected override bool SerializeToXmlElement (
			XmlWriter writer, string elementName)
		{
			throw new NotImplementedException ();
		}
	}

// AuthorizationPolicyTypeElement
	public partial class AuthorizationPolicyTypeElement
	{
		[MonoTODO]
		public AuthorizationPolicyTypeElement (string configurationName)
		{
			throw new NotImplementedException ();
		}
	}

// BindingsSection
	public partial class BindingsSection
	{
		public static BindingsSection GetSection (
			System.Configuration.Configuration config)
		{
			ServiceModelSectionGroup sm = ServiceModelSectionGroup.GetSectionGroup (config);
			if (sm == null)
				throw new SystemException ("Could not retrieve configuration section group 'system.serviceModel'");
			if (sm.Bindings == null)
				throw new SystemException ("Could not retrieve configuration sub section group 'bindings' in 'system.serviceModel'");
			return sm.Bindings;
		}

		[MonoTODO]
		public new BindingCollectionElement this [string name] {
			get {
				switch (name) {
				case "basicHttpBinding":
					return BasicHttpBinding;
				case "customBinding":
					return CustomBinding;
				}
				throw new NotImplementedException (String.Format ("Could not find {0}", name));
			}
		}

	}

// AuthorizationPolicyTypeElementCollection
	public sealed partial class AuthorizationPolicyTypeElementCollection
		 : ServiceModelConfigurationElementCollection<AuthorizationPolicyTypeElement>
	{
		protected override object GetElementKey (ConfigurationElement element)
		{
			return ((AuthorizationPolicyTypeElement) element).PolicyType;
		}
	}

// BaseAddressElementCollection
	public sealed partial class BaseAddressElementCollection
		 : ServiceModelConfigurationElementCollection<BaseAddressElement>
	{
		protected override object GetElementKey (ConfigurationElement element)
		{
			return ((BaseAddressElement) element).BaseAddress;
		}
	}

// ChannelEndpointElementCollection
	public sealed partial class ChannelEndpointElementCollection
		 : ServiceModelEnhancedConfigurationElementCollection<ChannelEndpointElement>
	{
		protected override object GetElementKey (ConfigurationElement element)
		{
			return ((ChannelEndpointElement) element).Name;
		}
	}

// ClaimTypeElementCollection
	public sealed partial class ClaimTypeElementCollection
		 : ServiceModelConfigurationElementCollection<ClaimTypeElement>,  ICollection,  IEnumerable
	{
		protected override object GetElementKey (ConfigurationElement element)
		{
			return ((ClaimTypeElement) element).ClaimType;
		}
	}

// ComContractElementCollection
	public sealed partial class ComContractElementCollection
		 : ServiceModelEnhancedConfigurationElementCollection<ComContractElement>
	{
		protected override object GetElementKey (ConfigurationElement element)
		{
			return ((ComContractElement) element).Name;
		}
	}

// ComMethodElementCollection
	public sealed partial class ComMethodElementCollection
		 : ServiceModelEnhancedConfigurationElementCollection<ComMethodElement>
	{
		protected override object GetElementKey (ConfigurationElement element)
		{
			return ((ComMethodElement) element).ExposedMethod;
		}
	}

// ComPersistableTypeElementCollection
	public sealed partial class ComPersistableTypeElementCollection
		 : ServiceModelEnhancedConfigurationElementCollection<ComPersistableTypeElement>
	{
		protected override object GetElementKey (ConfigurationElement element)
		{
			// FIXME: ID? anyways, cosmetic COM stuff...
			return ((ComPersistableTypeElement) element).Name;
		}
	}

// ComUdtElementCollection
	public sealed partial class ComUdtElementCollection
		 : ServiceModelEnhancedConfigurationElementCollection<ComUdtElement>
	{
		protected override object GetElementKey (ConfigurationElement element)
		{
			// FIXME: another property? anyways COM stuff...
			return ((ComUdtElement) element).Name;
		}
	}

// CustomBindingElementCollection
	public sealed partial class CustomBindingElementCollection
		 : ServiceModelEnhancedConfigurationElementCollection<CustomBindingElement>,  ICollection,  IEnumerable
	{
		protected override object GetElementKey (ConfigurationElement element)
		{
			return ((CustomBindingElement) element).Name;
		}
	}

// EndpointBehaviorElementCollection
	public sealed partial class EndpointBehaviorElementCollection
		 : ServiceModelEnhancedConfigurationElementCollection<EndpointBehaviorElement>,  ICollection,  IEnumerable
	{
		protected override object GetElementKey (ConfigurationElement element)
		{
			return ((EndpointBehaviorElement) element).Name;
		}
	}

// ExtensionElementCollection
	public partial class ExtensionElementCollection
		 : ServiceModelConfigurationElementCollection<ExtensionElement>,  ICollection,  IEnumerable
	{
		protected override object GetElementKey (ConfigurationElement element)
		{
			return ((ExtensionElement) element).Name;
		}
	}

// IssuedTokenClientBehaviorsElementCollection
	public sealed partial class IssuedTokenClientBehaviorsElementCollection
		 : ServiceModelConfigurationElementCollection<IssuedTokenClientBehaviorsElement>
	{
		[MonoTODO]
		protected override object GetElementKey (ConfigurationElement element)
		{
			throw new NotImplementedException ();
		}
	}

// PolicyImporterElementCollection
	public sealed partial class PolicyImporterElementCollection
		 : ServiceModelEnhancedConfigurationElementCollection<PolicyImporterElement>
	{
		protected override object GetElementKey (ConfigurationElement element)
		{
			return ((PolicyImporterElement) element).Type;
		}
	}

// ServiceBehaviorElementCollection
	public sealed partial class ServiceBehaviorElementCollection
		 : ServiceModelEnhancedConfigurationElementCollection<ServiceBehaviorElement>,  ICollection,  IEnumerable
	{
		protected override object GetElementKey (ConfigurationElement element)
		{
			return ((ServiceBehaviorElement) element).Name;
		}

		protected override bool ThrowOnDuplicate {
			get { return true; }
		}

		internal ServiceBehaviorElement Find (string name)
		{
			foreach (ServiceBehaviorElement el in this)
				if (el.Name == name)
					return el;
			return null;
		}

		[MonoTODO]
		protected override void BaseAdd (ConfigurationElement element)
		{
			base.BaseAdd (element);
		}

		[MonoTODO]
		protected override void DeserializeElement (
			XmlReader reader, bool serializeCollectionKey)
		{
			base.DeserializeElement (reader, serializeCollectionKey);
		}
	}

// ServiceBehaviorElement
	public partial class ServiceBehaviorElement
	{
		protected override void DeserializeElement (
			XmlReader reader, bool serializeCollectionKey)
		{
			if (reader.IsEmptyElement) {
				reader.Skip ();
				return;
			}
			reader.ReadStartElement ();

			for (reader.MoveToContent ();
			     reader.NodeType != XmlNodeType.EndElement;
			     reader.MoveToContent ()) {
				if (reader.NodeType != XmlNodeType.Element) {
//					OnDeserializeUnrecognizedElement (reader.LocalName, reader);
//					continue;
throw new Exception ();
				}
				switch (reader.LocalName) {
				case "serviceDebug":
					ServiceDebugElement debug = new ServiceDebugElement ();
					debug.CallDeserializeElement (reader, serializeCollectionKey);
					break;
				case "serviceMetadata":
					ServiceMetadataPublishingElement meta = new ServiceMetadataPublishingElement ();
					meta.CallDeserializeElement (reader, serializeCollectionKey);
					break;
				default:
Console.WriteLine (reader.LocalName);
					OnDeserializeUnrecognizedElement (reader.LocalName, reader);
					break;
				}
			}
			reader.ReadEndElement ();
			reader.MoveToContent ();
		}
	}

// ServiceDebugElement
	public partial class ServiceDebugElement
	{
		internal void CallDeserializeElement (XmlReader r, bool serializeCollectionKey)
		{
			base.DeserializeElement (r, serializeCollectionKey);
		}
	}

// ServiceMetadataPublishingElement 
	public partial class ServiceMetadataPublishingElement 
	{
		internal void CallDeserializeElement (XmlReader r, bool serializeCollectionKey)
		{
			base.DeserializeElement (r, serializeCollectionKey);
		}

		public object CreateBehavior ()
		{
			ServiceMetadataBehavior b = new ServiceMetadataBehavior ();
			b.HttpGetEnabled = HttpGetEnabled;
			b.HttpsGetEnabled = HttpsGetEnabled;
			b.HttpGetUrl = HttpGetUrl;
			b.HttpsGetUrl = HttpsGetUrl;
			return b;
		}
	}

// ServiceElementCollection
	public sealed partial class ServiceElementCollection
		 : ServiceModelEnhancedConfigurationElementCollection<ServiceElement>
	{
		protected override object GetElementKey (ConfigurationElement element)
		{
			return ((ServiceElement) element).Name;
		}
	}

// ServiceEndpointElementCollection
	public sealed partial class ServiceEndpointElementCollection
		 : ServiceModelEnhancedConfigurationElementCollection<ServiceEndpointElement>
	{
		protected override object GetElementKey (ConfigurationElement element)
		{
			return ((ServiceEndpointElement) element).Name;
		}
	}

// StandardBindingElementCollection
	public sealed partial class StandardBindingElementCollection<TBindingConfiguration>
		 : ServiceModelEnhancedConfigurationElementCollection<TBindingConfiguration>,  ICollection,  IEnumerable
		 where TBindingConfiguration : StandardBindingElement, new()
	{
		protected override object GetElementKey (ConfigurationElement element)
		{
			return ((StandardBindingElement) element).Name;
		}
	}

// TransportConfigurationTypeElementCollection
	public sealed partial class TransportConfigurationTypeElementCollection
		 : ServiceModelConfigurationElementCollection<TransportConfigurationTypeElement>
	{
		protected override object GetElementKey (ConfigurationElement element)
		{
			return ((TransportConfigurationTypeElement) element).Name;
		}
	}


// WsdlImporterElementCollection
	public sealed partial class WsdlImporterElementCollection
		 : ServiceModelEnhancedConfigurationElementCollection<WsdlImporterElement>
	{
		protected override object GetElementKey (ConfigurationElement element)
		{
			return ((WsdlImporterElement) element).Type;
		}
	}

// X509CertificateTrustedIssuerElementCollection
	public sealed partial class X509CertificateTrustedIssuerElementCollection
		 : ServiceModelConfigurationElementCollection<X509CertificateTrustedIssuerElement>
	{
		[MonoTODO]
		protected override object GetElementKey (ConfigurationElement element)
		{
			throw new NotImplementedException ();
		}
	}

// X509ScopedServiceCertificateElementCollection
	public sealed partial class X509ScopedServiceCertificateElementCollection
		 : ServiceModelConfigurationElementCollection<X509ScopedServiceCertificateElement>
	{
		[MonoTODO]
		protected override object GetElementKey (ConfigurationElement element)
		{
			throw new NotImplementedException ();
		}
	}

// XmlElementElementCollection
	public sealed partial class XmlElementElementCollection
		 : ServiceModelConfigurationElementCollection<XmlElementElement>
	{
		[MonoTODO]
		protected override object GetElementKey (ConfigurationElement element)
		{
			throw new NotImplementedException ();
		}
	}

// XPathMessageFilterElementCollection
	public sealed partial class XPathMessageFilterElementCollection
		 : ServiceModelConfigurationElementCollection<XPathMessageFilterElement>
	{
		[MonoTODO]
		protected override object GetElementKey (ConfigurationElement element)
		{
			throw new NotImplementedException ();
		}
	}

// BehaviorExtensionElement
	[MonoTODO]
	public abstract partial class BehaviorExtensionElement
		 : ServiceModelExtensionElement
	{
		protected BehaviorExtensionElement ()
		{
		}

		// Properties
		public abstract Type BehaviorType { get;  }
	}

// CustomBindingCollectionElement
	public partial class CustomBindingCollectionElement
	{
		public override Type BindingType {
			get { return typeof (CustomBinding); }
		}
	}

// CustomBindingElement
	public partial class CustomBindingElement
	{
		[MonoTODO]
		public void ApplyConfiguration (Binding binding)
		{
			throw new NotImplementedException ();
		}
	}

// StandardBindingCollectionElement
	public partial class StandardBindingCollectionElement<TStandardBinding,TBindingConfiguration>
	{
		public override Type BindingType {
			get { return typeof (TStandardBinding); }
		}
	}

	public partial class StandardBindingElement
		 : ConfigurationElement, IBindingConfigurationElement
	{
		[MonoTODO]
		public void ApplyConfiguration (Binding binding)
		{
			throw new NotImplementedException ();
		}
	}

// ServiceModelExtensionCollectionElement
	public partial class ServiceModelExtensionCollectionElement<TServiceModelExtensionElement> 
		: ConfigurationElement,
		ICollection<TServiceModelExtensionElement>,
		IEnumerable<TServiceModelExtensionElement>, 
		IEnumerable
	{
		[MonoTODO]
		int ICollection<TServiceModelExtensionElement>.Count {
			get { throw new NotImplementedException (); }
		}
	}
}
