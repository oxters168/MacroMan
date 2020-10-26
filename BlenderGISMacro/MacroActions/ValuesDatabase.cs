using System.Linq;

namespace MacroMan.MacroActions
{
    public class ValuesDatabase
    {
        private static IntegerValue[] integers = new IntegerValue[10];
        private static StringedValue[] stringedValues = new StringedValue[10];
        //private static Dictionary<string, int> integers = new Dictionary<string, int>();
        //private static Dictionary<string, string> stringedValues = new Dictionary<string, string>();

        public static void SetInteger(string key, int value)
        {
            int freeIndex = -1;
            bool done = false;
            for (int i = 0; i < integers.Length; i++)
            {
                if (freeIndex < 0 && !integers[i].IsSet)
                    freeIndex = i;

                if (integers[i].name.Equals(key))
                {
                    done = true;
                    integers[i].value = value;
                    break;
                }
            }
            if (!done)
            {
                if (freeIndex < 0)
                {
                    freeIndex = integers.Length;
                    IntegerValue[] temp = integers;
                    integers = new IntegerValue[freeIndex + 10];
                    for (int i = 0; i < freeIndex; i++)
                        integers[i] = temp[i];
                }

                integers[freeIndex].value = value;
            }
        }
        public static int GetInteger(string key)
        {
            return integers.First(integer => integer.name.Equals(key)).value;
        }

        /*public static void SetString(string key, string value)
        {
            stringedValues[key] = value;
        }
        public static string GetString(string key)
        {
            string value = null;
            if (stringedValues.ContainsKey(key))
                value = stringedValues[key];
            if (string.IsNullOrEmpty(value))
                value = string.Empty;
            return value;
        }*/
    }
}
