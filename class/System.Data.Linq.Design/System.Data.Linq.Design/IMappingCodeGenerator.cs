using System.Collections.Generic;

namespace System.Data.Linq.Design
{
    public interface IMappingCodeGenerator
    {
        IEnumerable<ResultFile> GenerateFromFile(string fileName, GenerateOptions options);

        IEnumerable<ResultFile> GenerateFromText(string text, GenerateOptions options);

        IEnumerable<ValidationMessage> ValidateFileName(string fileName);

        IEnumerable<ValidationMessage> ValidateText(string text);
    }
}