using System;

namespace MacroMan.MacroActions
{
    [Serializable]
    public struct MacroProperty
    {
        public string name;
        public int id;
        public PropertyType type;
        public object value;
        public bool readOnly;
        public Func<Array> customOptions;

        public Array GetOptions()
        {
            Array options = null;
            if (type == PropertyType.boolean)
                options = Enum.GetValues(typeof(BooleanValue));
            else if (customOptions != null)
                options = customOptions();
            return options;
        }
    }
}
