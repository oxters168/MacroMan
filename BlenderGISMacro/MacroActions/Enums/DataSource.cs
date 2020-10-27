namespace MacroMan.MacroActions
{
    [System.Flags]
    public enum DataSource
    {
        Self = 0x01,
        Macro = 0x02,
        Database = 0x04,
    }
}
