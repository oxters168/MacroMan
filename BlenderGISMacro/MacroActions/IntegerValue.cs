namespace MacroMan.MacroActions
{
    public struct IntegerValue
    {
        public int value { get { return _value; } set { set = true; _value = value; } }
        private int _value;
        public string name;
        public bool IsSet { get { return set; } }
        private bool set;
    }
}
