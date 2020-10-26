using System;
using System.Collections.Generic;
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

        private int uniqueId;
        private static int totalId;
        private static List<MacroType> cachedMacros = new List<MacroType>();

        public MacroType()
        {
            uniqueId = totalId++;
            cachedMacros.Add(this);
        }

        public int GetId() { return uniqueId;  } //Every macro action should have a unique id
        public abstract Dictionary<int, string> GetActions();
        public abstract void SetAction(int actionId);
        public abstract int GetAction();
        public abstract Dictionary<int, string> GetProperties();
        public abstract void SetPropertyValue(int propertyId, object value);
        internal abstract MacroProperty GetProperty(int propertyId);
        public abstract object GetPropertyValue(int propertyId);
        public abstract int GetPropertyType(int propertyId); //Will be used to determine whether the input of the property is a number, string, boolean, or dropdown
        public abstract bool IsPropertyReadOnly(int propertyId); //An output property can be used as input in other actions
        public abstract Task<int> Execute(); //The return value can be used to give feedback on the executed action

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
