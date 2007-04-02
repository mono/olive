namespace System.Data.Linq.Design
{
    public interface IDatabaseExtractor
    {
        void ExtractToFile(string connection, string database, ExtractOptions options, string resultFile);

        string ExtractToText(string connection, string database, ExtractOptions options);
    }
}