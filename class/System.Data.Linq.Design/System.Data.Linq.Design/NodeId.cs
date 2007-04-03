namespace System.Data.Linq.Design
{
    public class NodeId
    {
        #region Fields
        private string name;
        private NodeType nodeType;
        #endregion

        #region Properties
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public NodeType NodeType
        {
            get { return nodeType; }
            set { nodeType = value; }
        }
        #endregion
    }
}