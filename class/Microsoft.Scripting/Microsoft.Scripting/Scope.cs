using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Scripting
{
	public enum ScopeMemberAttributes
	{
		DontDelete = 2,
		DontEnumerate = 4,
		None = 0,
		ReadOnly = 1
	}

	public class Scope
	{
		public Scope ()
		{
			throw new NotImplementedException ();
		}

		public Scope (IAttributesCollection dictionary)
		{
			throw new NotImplementedException ();
		}

		public Scope (Scope parent, IAttributesCollection dictionary)
		{
			throw new NotImplementedException ();
		}

		public Scope (Scope parent, IAttributesCollection dictionary, bool isVisible)
		{
			throw new NotImplementedException ();
		}

		public void Clear ()
		{
			throw new NotImplementedException ();
		}

		public bool ContainsName (SymbolId name)
		{
			throw new NotImplementedException ();
		}

		public bool ContainsName (LanguageContext context, SymbolId name)
		{
			throw new NotImplementedException ();
		}

		public IEnumerable<KeyValuePair<object, object>> GetAllItems (LanguageContext context)
		{
			throw new NotImplementedException ();
		}

		public IEnumerable<object> GetAllKeys (LanguageContext context)
		{
			throw new NotImplementedException ();
		}

		public IEnumerable<SymbolId> GetKeys (LanguageContext context)
		{
			throw new NotImplementedException ();
		}

		public object LookupName (SymbolId name)
		{
			throw new NotImplementedException ();
		}

		public object LookupName (LanguageContext context, SymbolId name)
		{
			throw new NotImplementedException ();
		}

		public void RemoveName (SymbolId name)
		{
			throw new NotImplementedException ();
		}

		public bool RemoveName (LanguageContext context, SymbolId name)
		{
			throw new NotImplementedException ();
		}

		public void RemoveNameForContext (LanguageContext context, SymbolId name)
		{
			throw new NotImplementedException ();
		}

		public void SetName (SymbolId name, object value)
		{
			throw new NotImplementedException ();
		}

		public void SetName (ContextId context, SymbolId name, object value)
		{
			throw new NotImplementedException ();
		}

		public void SetName (SymbolId name, object value, ScopeMemberAttributes attributes)
		{
			throw new NotImplementedException ();
		}

		public void SetName (ContextId context, SymbolId name, object value, ScopeMemberAttributes attributes)
		{
			throw new NotImplementedException ();
		}

		public void SetObjectName (ContextId context, object name, object value, ScopeMemberAttributes attributes)
		{
			throw new NotImplementedException ();
		}

		public bool TryGetName (SymbolId name, out object value)
		{
			throw new NotImplementedException ();
		}

		public bool TryGetName (LanguageContext context, SymbolId name, out object value)
		{
			throw new NotImplementedException ();
		}

		public bool TryGetNameForContext (LanguageContext context, SymbolId name, out object value)
		{
			throw new NotImplementedException ();
		}

		public bool TryGetObjectName (LanguageContext context, object name, out object value)
		{
			throw new NotImplementedException ();
		}

		public bool TryLookupName (SymbolId name, out object value)
		{
			throw new NotImplementedException ();
		}

		public bool TryLookupName (LanguageContext context, SymbolId name, out object value)
		{
			throw new NotImplementedException ();
		}

		public bool TryLookupObjectName (LanguageContext context, object name, out object value)
		{
			throw new NotImplementedException ();
		}

		public bool TryRemoveForContext (LanguageContext context, SymbolId name)
		{
			throw new NotImplementedException ();
		}

		public bool TryRemoveName (SymbolId name)
		{
			throw new NotImplementedException ();
		}

		public bool TryRemoveName (LanguageContext context, SymbolId name)
		{
			throw new NotImplementedException ();
		}

		public bool TryRemoveObjectName (LanguageContext context, object name)
		{
			throw new NotImplementedException ();
		}


		public IAttributesCollection Dict {
			get { throw new NotImplementedException (); }
		}

		public Scope GlobalScope {
			get { throw new NotImplementedException (); }
		}

		public bool IsVisible {
			get { throw new NotImplementedException (); }
		}

		public IEnumerable<KeyValuePair<SymbolId, object>> Items {
			get	{ throw new NotImplementedException ();	}
		}

		public IEnumerable<SymbolId> Keys {
			get { throw new NotImplementedException (); }
		}

		public Scope Parent { 
			get { throw new NotImplementedException (); } 
		}

	}
}
