using System.Collections.ObjectModel;

namespace System.Data.Linq.Design
{
    public class ValidationMessage
    {
        #region .ctor
        public ValidationMessage(string description, Severity severity, ReadOnlyCollection<NodeId> nodePath)
        {
            this.description = description;
            this.severity = severity;
            this.nodePath = nodePath;
        }
        #endregion

        #region Fields
        private string description;
        private ReadOnlyCollection<NodeId> nodePath;
        private Severity severity;
        #endregion

        #region Properties
        public ReadOnlyCollection<NodeId> NodePath
        {
            get { return nodePath; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public Severity Severity
        {
            get { return severity; }
            set { severity = value; }
        }
        #endregion
    }
}