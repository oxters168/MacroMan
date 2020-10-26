using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MacroMan.MacroActions
{
    public abstract class MacroType
    {
        //All the different action categories inherit from this class
        //They will all have their own actions and properties for those actions
        //Keyboard actions
        //Mouse actions
        //Timed actions
        //etc...

        public string name;
        private int uniqueId;
        private static int totalId;
        private static List<MacroType> cachedMacros = new List<MacroType>();

        public MacroType()
        {
            uniqueId = totalId++;
            cachedMacros.Add(this);
        }

        public static MacroType GetMacro(int id)
        {
            return cachedMacros.FirstOrDefault(macro => macro.uniqueId == id);
        }
        public static MacroType GetMacro(string key)
        {
            return cachedMacros.FirstOrDefault(macro => macro.name.Equals(key));
        }

        internal static MacroType TryGetMacro(string key, int id)
        {
            MacroType macro = null;
            if (!string.IsNullOrEmpty(key))
                macro = MacroType.GetMacro(key);
            else if (id >= 0)
                macro = MacroType.GetMacro(id);
            return macro;
        }

        public int GetId() { return uniqueId;  } //Every macro action should have a unique id
        public abstract void SetAction(int actionId);
        public abstract int GetAction();
        public abstract void SetPropertyValue(int propertyId, object value);
        public abstract void SetPropertyValue(string propertyKey, object value);
        internal abstract void TrySetPropertyValue(string propertyKey, int propertyId, object value);
        public abstract MacroProperty GetProperty(int propertyId);
        public abstract MacroProperty GetProperty(string propertyKey);
        internal abstract MacroProperty TryGetProperty(string propertyKey, int propertyId);
        public abstract Task<int> Execute(); //The return value can be used to give feedback on the executed action

        public static Array GetProperties(Macro macroType)
        {
            Array properties = null;
            switch (macroType)
            {
                case Macro.Keyboard:
                    properties = KeyboardMacro.GetProperties();
                    break;
                case Macro.Integer:
                    properties = IntegerMacro.GetProperties();
                    break;
            }
            return properties;
        }
        public static Array GetActions(Macro macroType)
        {
            Array actions = null;
            switch (macroType)
            {
                case Macro.Keyboard:
                    actions = KeyboardMacro.GetActions();
                    break;
                case Macro.Integer:
                    actions = IntegerMacro.GetActions();
                    break;
            }
            return actions;
        }

        /// <summary>
        /// Source: https://www.dotnetperls.com/uppercase-first-letter
        /// </summary>
        public static string ToFirstLettersUpper(string original)
        {
            var charArray = original.ToCharArray();
            for (int i = 1; i < charArray.Length; i++)
                if (charArray[i - 1] == ' ')
                    charArray[i] = char.ToUpper(charArray[i]);

            return new string(charArray);
        }
        public static Dictionary<int, string> EnumToDictionary(Type enumType)
        {
            var allValues = Enum.GetValues(enumType);
            var dick = new Dictionary<int, string>();
            foreach (var value in allValues)
                dick.Add((int)value, ToFirstLettersUpper(value.ToString().Replace('_', ' ')));

            return dick;
        }
        public static Dictionary<TKey, TValue> ToDictionary<TSource, TKey, TValue>(IEnumerable<TSource> items, Converter<TSource, TKey> keySelector, Converter<TSource, TValue> valueSelector)
        {
            Dictionary<TKey, TValue> result = new Dictionary<TKey, TValue>();
            foreach (TSource item in items)
            {
                result.Add(keySelector(item), valueSelector(item));
            }
            return result;
        }
        public static Dictionary<int, string> PropsToDictionary(IEnumerable<MacroProperty> props)
        {
            return ToDictionary<MacroProperty, int, string>(props, delegate (MacroProperty prop) { return prop.id; }, delegate (MacroProperty prop) { return prop.name; });
        }
    }
}
