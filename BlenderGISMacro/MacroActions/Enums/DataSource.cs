namespace MacroMan.MacroActions
{
    [System.Flags]
    public enum DataSource
    {
        self = 0x01,
        macro = 0x02,
        database = 0x04,
    }
}
