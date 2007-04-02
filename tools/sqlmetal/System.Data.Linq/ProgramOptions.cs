using Mono.GetOptions;

namespace System.Data.Linq
{
    public sealed class ProgramOptions : Options
    {
        private string inputType;
        private string outputType;
        private string inputFile;
        private string outputFile;
        private string nspace;
        private string mapOutputFile;
        private string language;

        private string dbName;
        private string server;
        private string userId;
        private string password;
        private string dbType;

        [Option("The ID used for connecting to the database.", "user")]
        public string UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        [Option("The password used to connect to the database.", "pass", AlternateForm="password")]
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        [Option("The type of source database (eg. MySQL, SQL, Oracle, etc.).", "type")]
        public string DbType
        {
            get { return dbType; }
            set { dbType = value; }
        }

        public string DbName
        {
            get { return dbName; }
            set { dbName = value; }
        }

        [Option("The source server of the mapping.", "server")]
        public string Server
        {
            get { return server; }
            set { 
                server = value;
                inputType = "sql";
            }
        }

        [Option("The type of input for the mapping (either XML or SQL).", "inputType")]
        public string InputType
        {
            get { return inputType; }
            set { inputType = value; }
        }

        [Option("Sets the XML output file for the mapping.", "xml")]
        public string XmlOutput
        {
            get { return inputFile; }
            set
            {
                outputType = "xml";
                outputFile = value;
            }
        }

        [Option("Sets the output code file for the mapping", "code")]
        public string CodeOutput
        {
            get { return outputFile; }
            set
            {
                outputType = "code";
                outputFile = value;
            }
        }

        [Option("The language used to export the mapping.", "language")]
        public string Language
        {
            get { return language; }
            set {
                switch (value.ToLower())
                {
                    case "c#":
                    case "csharp":
                    case "vcs":
                        language = "csharp";
                        break;
                    case "visualbasic":
                    case "vb":
                    case "vbasic":
                        language = "vbasic";
                        break;
                    default:
                        throw new ArgumentException("Language '" + value + "' not supported.");
                }

                outputType = "code";
            }
        }

        public bool IsXmlInput
        {
            get { return String.Compare(inputType, "xml", StringComparison.OrdinalIgnoreCase) == 0; }
        }

        public bool IsSqlInput
        {
            get { return String.Compare(inputType, "sql", StringComparison.OrdinalIgnoreCase) == 0; }
        }

        public string OutputType
        {
            get { return outputType; }
            set { outputType = value; }
        }

        public string InputFile
        {
            get { return inputFile; }
            set { inputFile = value; }
        }

        public string OutputFile
        {
            get { return outputFile; }
            set { outputFile = value; }
        }

        public string Namespace
        {
            get { return nspace; }
            set { nspace = value; }
        }

        public string MapOutputFile
        {
            get { return mapOutputFile; }
            set { mapOutputFile = value; }
        }

        [KillOption]
        public override WhatToDoNext DoHelp2()
        {
            return base.DoHelp2();
        }
    }
}