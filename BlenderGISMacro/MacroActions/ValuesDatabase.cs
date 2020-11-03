using System.Linq;
using System.Collections.Generic;
using System;
using System.Data;

namespace MacroMan.MacroActions
{
    public class ValuesDatabase
    {
        private static List<IntegerValue> integers = new List<IntegerValue>();
        private static List<StringedValue> stringedValues = new List<StringedValue>();

        private static void ExtendIfOutOfRange(int id)
        {
            while (id >= integers.Count)
                integers.Add(new IntegerValue());
            //if (id >= integers.Count)
                //integers.AddRange(new IntegerValue[(id + 1) - integers.Count]);
        }

        public static int IntegersCount()
        {
            return integers.Count;
        }
        public static void SetInteger(string key, int value)
        {
            int currentCount = integers.Count;
            int freeIndex = currentCount;
            bool done = false;
            for (int i = 0; i < currentCount; i++)
            {
                if (freeIndex >= currentCount && !integers[i].set)
                    freeIndex = i;

                if (integers[i].name.Equals(key))
                {
                    done = true;
                    SetInteger(i, value);
                    break;
                }
            }

            if (!done)
                SetInteger(freeIndex, value, key);
        }
        public static void SetInteger(int id, int value, string key = null)
        {
            if (id < 0)
                throw new IndexOutOfRangeException();

            ExtendIfOutOfRange(id);

            var current = integers[id];
            if (!string.IsNullOrEmpty(key))
                current.name = key;
            current.value = value;
            integers[id] = current;
        }
        internal static void TrySetInteger(string key, int id, int value)
        {
            if (!string.IsNullOrEmpty(key))
                SetInteger(key, value);
            else if (id >= 0)
                SetInteger(id, value);
            else
                throw new KeyNotFoundException();
        }
        public static int GetInteger(string key)
        {
            return integers.First(integer => integer.name.Equals(key)).value;
        }
        public static int GetInteger(int id)
        {
            if (id < 0)
                throw new IndexOutOfRangeException();

            ExtendIfOutOfRange(id);
            return integers[id].value;
        }
        internal static int TryGetInteger(string key, int id)
        {
            int value;
            if (!string.IsNullOrEmpty(key))
                value = GetInteger(key);
            else
                value = GetInteger(id);
            return value;
        }
        public static DataTable IntegersToDataTable()
        {
            DataTable integerData = new DataTable();
            var idColumn = integerData.Columns.Add("Id", typeof(int));
            var nameColumn = integerData.Columns.Add("Name", typeof(string));
            var valueColumn = integerData.Columns.Add("Value", typeof(int));
            idColumn.ReadOnly = true;
            nameColumn.ReadOnly = false;
            valueColumn.ReadOnly = false;
            valueColumn.DefaultValue = 0;

            for (int i = 0; i < integers.Count; i++)
            {
                integerData.Rows.Add(i, integers[i].name, integers[i].value);
            }

            return integerData;
        }

        public static int StringsCount()
        {
            return stringedValues.Count;
        }
        public static void SetString(string key, string value)
        {
            int currentCount = stringedValues.Count;
            int freeIndex = currentCount;
            bool done = false;
            for (int i = 0; i < currentCount; i++)
            {
                if (freeIndex >= currentCount && !stringedValues[i].set)
                    freeIndex = i;

                if (stringedValues[i].name.Equals(key))
                {
                    done = true;
                    SetString(i, value);
                    break;
                }
            }
            if (!done)
                SetString(freeIndex, value, key);
        }
        public static void SetString(int id, string value, string key = null)
        {
            if (id < 0)
                throw new IndexOutOfRangeException();

            ExtendIfOutOfRange(id);

            var current = stringedValues[id];
            if (!string.IsNullOrEmpty(key))
                current.name = key;
            current.value = value;
            stringedValues[id] = current;
        }
        internal static void TrySetString(string key, int id, string value)
        {
            if (!string.IsNullOrEmpty(key))
                SetString(key, value);
            else if (id >= 0)
                SetString(id, value);
            else
                throw new KeyNotFoundException();
        }
        public static string GetString(string key)
        {
            return stringedValues.First(stringedValue => stringedValue.name.Equals(key)).value;
        }
        public static string GetString(int id)
        {
            if (id < 0)
                throw new IndexOutOfRangeException();

            ExtendIfOutOfRange(id);
            return stringedValues[id].value;
        }
        internal static string TryGetString(string key, int id)
        {
            string value;
            if (!string.IsNullOrEmpty(key))
                value = GetString(key);
            else
                value = GetString(id);
            return value;
        }
    }
}
