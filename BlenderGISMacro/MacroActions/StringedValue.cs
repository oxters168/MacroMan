namespace MacroMan.MacroActions
{
    public struct StringedValue
    {
        public string value { get { return _value; } set { set = true; _value = value; } }
        private string _value;
        public string name { get { return _name; } set { set = true; _name = value; } }
        private string _name;
        public bool set { get; private set; }
    }
}
