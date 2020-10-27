using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MacroMan.MacroActions
{
    public abstract class MacroType
    {
        public string name = string.Empty;
        private int uniqueId;
        private static int totalId;
        private static List<MacroType> cachedMacros = new List<MacroType>();
        private static Macro[] macroTypes = (Macro[])Enum.GetValues(typeof(Macro));
        private static MacroType[] references = new MacroType[macroTypes.Length];

        public MacroType()
        {
            uniqueId = totalId++;
            cachedMacros.Add(this);
        }
        public MacroType(MacroType other) : this()
        {
            string newName = other.name;
            while (cachedMacros.Where(macro => macro.name.Equals(newName)).Count() > 0)
                newName = newName + "_cp";
            name = newName;

            SetAction(other.GetAction());

            var props = GetProperties();
            for (int i = 0; i < props.Length; i++)
            {
                int propertyId = (int)props.GetValue(i);
                SetPropertyValue(propertyId, other.GetProperty(propertyId).value);
            }
        }

        public override string ToString()
        {
            return name;
        }

        public static void RemoveFromCache(MacroType macro)
        {
            cachedMacros.Remove(macro);
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

        public int GetId() { return uniqueId;  }
        public abstract Array GetProperties();
        public abstract Array GetShownProperties();
        public abstract Array GetActions();
        public abstract void SetAction(int actionId);
        public abstract int GetAction();
        public abstract void SetPropertyValue(int propertyId, object value);
        public abstract void SetPropertyValue(string propertyKey, object value);
        internal abstract void TrySetPropertyValue(string propertyKey, int propertyId, object value);
        public abstract MacroProperty GetProperty(int propertyId);
        public abstract MacroProperty GetProperty(string propertyKey);
        internal abstract MacroProperty TryGetProperty(string propertyKey, int propertyId);
        public abstract Task<int> Execute();

        public static async Task Execute(params MacroType[] sequence)
        {
            for (int i = 0; i < sequence.Length; i++)
            {
                MacroType macro = sequence[i];
                await macro.Execute();
            }
        }

        public static Macro GetMacroType(MacroType macro)
        {
            Macro macroType = Macro.Integer;
            if (macro is KeyboardMacro)
                macroType = Macro.Keyboard;
            else if (macro is IntegerMacro)
                macroType = Macro.Integer;
            else if (macro is TimeMacro)
                macroType = Macro.Time;
            return macroType;
        }
        public static MacroType GenerateMacro(Macro macroType, MacroType toClone = null)
        {
            MacroType macro = null;
            switch (macroType)
            {
                case Macro.Keyboard:
                    if (toClone != null)
                        macro = new KeyboardMacro(toClone);
                    else
                        macro = new KeyboardMacro();
                    break;
                case Macro.Integer:
                    if (toClone != null)
                        macro = new IntegerMacro(toClone);
                    else
                        macro = new IntegerMacro();
                    break;
                case Macro.Time:
                    if (toClone != null)
                        macro = new TimeMacro(toClone);
                    else
                        macro = new TimeMacro();
                    break;
            }
            return macro;
        }
        public static MacroType GenerateFauxMacro(Macro macroType)
        {
            MacroType macro;
            int prevUniqueId = totalId;
            macro = GenerateMacro(macroType);
            macro.uniqueId = -1;
            totalId = prevUniqueId;
            RemoveFromCache(macro);
            return macro;
        }
        private static MacroType GetReference(Macro macroType)
        {
            int typeIndex = Array.IndexOf(macroTypes, macroType);

            MacroType reference = references[typeIndex];
            if (reference == null)
            {
                reference = GenerateFauxMacro(macroType);
                references[typeIndex] = reference;
            }

            return reference;
        }
        public static Array GetProperties(Macro macroType)
        {
            return GetReference(macroType).GetProperties();
        }
        public static Array GetShownProperties(Macro macroType)
        {
            return GetReference(macroType).GetShownProperties();
        }
        public static Array GetActions(Macro macroType)
        {
            return GetReference(macroType).GetActions();
        }
        public static Array GetPropertyOptions(Macro macroType, int propertyId)
        {
            return GetReference(macroType).GetProperty(propertyId).GetOptions();
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
