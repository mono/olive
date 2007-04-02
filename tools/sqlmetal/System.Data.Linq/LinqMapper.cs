using System.Data.Linq.Design;

using Mono.GetOptions;

namespace System.Data.Linq
{
    class LinqMapper
    {
        static int Main(string[] args)
        {
            ProgramOptions opts = new ProgramOptions();
            opts.ProcessArgs(args);

            if (opts.IsSqlInput)
            {
                if (opts.DbType == null)
                    opts.DbType = "mysql";

                ConnectionStringFormatter stringFormatter = null;
                try
                {
                    stringFormatter = ConnectionStringFormatter.GetFormatter(opts.DbType);
                }
                catch (ArgumentException)
                {
                    Console.Out.WriteLine("Invalid connection type.");
                    return 1;
                }
            }
            else if (opts.IsXmlInput)
            {
                //TODO:
            }
            else
            {
                return 1;
            }

            return 0;
        }
    }
}
