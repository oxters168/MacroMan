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

        public static string IntegersExt()
        {
            return "intdb";
        }
        public static void SaveIntegersTo(string loc)
        {
            var bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            using (var fs = new System.IO.FileStream(loc, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.ReadWrite, System.IO.FileShare.None))
            using (var ms = new System.IO.MemoryStream())
            using (var sw = new System.IO.StreamWriter(fs))
            {
                bf.Serialize(ms, integers);
                fs.SetLength(0);
                ms.Position = 0;
                ms.CopyTo(fs);
            }
        }
        public static void LoadIntegers(string loc)
        {
            var bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            using (var fs = new System.IO.FileStream(loc, System.IO.FileMode.Open, System.IO.FileAccess.Read))
            {
                integers = (List<IntegerValue>)bf.Deserialize(fs);
            }
        }
        public static string StringsExt()
        {
            return "strdb";
        }
        public static void SaveStringsTo(string loc)
        {
            var bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            using (var fs = new System.IO.FileStream(loc, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.ReadWrite, System.IO.FileShare.None))
            using (var ms = new System.IO.MemoryStream())
            using (var sw = new System.IO.StreamWriter(fs))
            {
                bf.Serialize(ms, stringedValues);
                fs.SetLength(0);
                ms.Position = 0;
                ms.CopyTo(fs);
            }
        }
        public static void LoadStrings(string loc)
        {
            var bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            using (var fs = new System.IO.FileStream(loc, System.IO.FileMode.Open, System.IO.FileAccess.Read))
            {
                stringedValues = (List<StringedValue>)bf.Deserialize(fs);
            }
        }

        private static void ExtendIntegersIfOutOfRange(int id)
        {
            while (id >= integers.Count)
                integers.Add(new IntegerValue());
        }
        private static void ExtendStringsIfOutOfRange(int id)
        {
            while (id >= stringedValues.Count)
                stringedValues.Add(new StringedValue());
        }
        public static object GetValue(object key)
        {
            object value;
            if (StringExists(key))
                value = GetString(key);
            else
                value = GetInteger(key);
            return value;
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

            ExtendIntegersIfOutOfRange(id);

            var current = integers[id];
            if (!string.IsNullOrEmpty(key))
                current.name = key;
            current.value = value;
            integers[id] = current;
        }
        public static void SetInteger(object key, int value)
        {
            if (key is string)
                SetInteger((string)key, value);
            else
                SetInteger((int)key, value);
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

            ExtendIntegersIfOutOfRange(id);
            return integers[id].value;
        }
        public static int GetInteger(object key)
        {
            int value;
            if (key is string)
                value = GetInteger((string)key);
            else
                value = GetInteger((int)key);
            return value;
        }
        public static bool IntegerExists(string key)
        {
            return integers.Where(value => value.name.Equals(key)).Count() > 0;
        }
        public static bool IntegerExists(int key)
        {
            return key >= 0 && key < integers.Count;
        }
        public static bool IntegerExists(object key)
        {
            if (key is string)
                return IntegerExists((string)key);
            else
                return IntegerExists((int)key);
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
                integerData.Rows.Add(i, integers[i].name, integers[i].value);

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

            ExtendStringsIfOutOfRange(id);

            var current = stringedValues[id];
            if (!string.IsNullOrEmpty(key))
                current.name = key;
            current.value = value;
            stringedValues[id] = current;
        }
        public static void SetString(object key, string value)
        {
            if (key is string)
                SetString((string)key, value);
            else
                SetString((int)key, value);
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

            ExtendStringsIfOutOfRange(id);
            return stringedValues[id].value;
        }
        public static string GetString(object key)
        {
            string value;
            if (key is string)
                value = GetString((string)key);
            else
                value = GetString((int)key);
            return value;
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
        public static bool StringExists(string key)
        {
            return stringedValues.Where(value => value.name.Equals(key)).Count() > 0;
        }
        public static bool StringExists(int key)
        {
            return key >= 0 && key < stringedValues.Count;
        }
        public static bool StringExists(object key)
        {
            if (key is string)
                return StringExists((string)key);
            else
                return StringExists((int)key);
        }

        public static DataTable StringsToDataTable()
        {
            DataTable stringedData = new DataTable();
            var idColumn = stringedData.Columns.Add("Id", typeof(int));
            var nameColumn = stringedData.Columns.Add("Name", typeof(string));
            var valueColumn = stringedData.Columns.Add("Value", typeof(string));
            idColumn.ReadOnly = true;
            nameColumn.ReadOnly = false;
            valueColumn.ReadOnly = false;

            for (int i = 0; i < stringedValues.Count; i++)
                stringedData.Rows.Add(i, stringedValues[i].name, stringedValues[i].value);

            return stringedData;
        }
    }
}
