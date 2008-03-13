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

		public new BindingCollectionElement this [string name] {
			get {
				object element = base [name];
				if (element is BindingCollectionElement)
					return (BindingCollectionElement) element;
				throw new NotImplementedException (String.Format ("Could not find {0}", name));
			}
		}

	}

// ChannelEndpointElementCollection
	public sealed partial class ChannelEndpointElementCollection
		 : ServiceModelEnhancedConfigurationElementCollection<ChannelEndpointElement>
	{
		protected override object GetElementKey (ConfigurationElement element)
		{
			ChannelEndpointElement el = (ChannelEndpointElement) element;
			return el.Name + ";" + el.Contract;
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

// ServiceDebugElement
	public partial class ServiceDebugElement
	{
		[MonoTODO]
		protected internal override object CreateBehavior ()
		{
			throw new NotImplementedException ();
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

// CallbackBehaviorElement
	public partial class CallbackDebugElement
	{
		protected internal override object CreateBehavior ()
		{
			return new CallbackDebugBehavior (IncludeExceptionDetailInFaults);
		}
	}

// CallbackTimeoutsElement
	public partial class CallbackTimeoutsElement
	{
		[MonoTODO]
		protected internal override object CreateBehavior ()
		{
			throw new NotImplementedException ();
		}
	}

// ClientCredentialsElement
	public partial class ClientCredentialsElement
	{
		[MonoTODO]
		protected internal override object CreateBehavior ()
		{
			throw new NotImplementedException ();
		}
	}

// ClientViaElement
	public partial class ClientViaElement
	{
		[MonoTODO]
		protected internal override object CreateBehavior ()
		{
			throw new NotImplementedException ();
		}
	}

// DataContractSerializerElement
	public partial class DataContractSerializerElement
	{
		[MonoTODO]
		protected internal override object CreateBehavior ()
		{
			throw new NotImplementedException ();
		}
	}

// ServiceCredentialsElement
	public partial class ServiceCredentialsElement
	{
		[MonoTODO]
		protected internal override object CreateBehavior ()
		{
			throw new NotImplementedException ();
		}
	}

// ServiceSecurityAuditElement
	public partial class ServiceSecurityAuditElement
	{
		[MonoTODO]
		protected internal override object CreateBehavior ()
		{
			throw new NotImplementedException ();
		}
	}

// ServiceThrottlingElement
	public partial class ServiceThrottlingElement
	{
		[MonoTODO]
		protected internal override object CreateBehavior ()
		{
			throw new NotImplementedException ();
		}
	}

// ServiceTimeoutsElement
	public partial class ServiceTimeoutsElement
	{
		[MonoTODO]
		protected internal override object CreateBehavior ()
		{
			throw new NotImplementedException ();
		}
	}

// SynchronousReceiveElement
	public partial class SynchronousReceiveElement
	{
		[MonoTODO]
		protected internal override object CreateBehavior ()
		{
			throw new NotImplementedException ();
		}
	}

// TransactedBatchingElement
	public partial class TransactedBatchingElement
	{
		[MonoTODO]
		protected internal override object CreateBehavior ()
		{
			throw new NotImplementedException ();
		}
	}

}
