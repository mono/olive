namespace System.Data.Linq.Design
{
    [Flags]
    public enum ExtractTypes
    {
        Tables = 1,
        Views = 2,
        Functions = 4,
        System = 8,
        StoredProcedures = 16,
        Constraints = 32,
        Indexes = 64,
        Relationships = 128,
        All = Tables | Views | Functions | System | StoredProcedures |
            Constraints | Indexes | Relationships
    }
}