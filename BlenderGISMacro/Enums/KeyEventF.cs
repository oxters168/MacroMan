namespace BlenderGISMacro
{
    public enum KeyEventF
    {
        /// <summary>
        /// If specified, the scan code was preceded by a prefix byte having the value 0xE0 (224).
        /// </summary>
        EXTENDEDKEY = 0x0001,
        /// <summary>
        /// If specified, the key is being released. If not specified, the key is being depressed.
        /// </summary>
        KEYUP = 0x0002,
    }
}
