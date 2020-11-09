using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MacroMan.MacroActions
{
    [Serializable]
    public class StringMacro : MacroType
    {
        /// <summary>
        /// This enum is used to identify the action this macro will do
        /// We can create an array of actions if we want for this enum,
        /// but I don't see why I would do that than just manually call the actions
        /// </summary>
        private enum StringAction
        {
            concatenate = 0,
            substring = 1,
            get_char_at = 2,
            to_upper = 3,
            to_lower = 4,
            get_hash_code = 5,
            convert_to_int = 6,
            trim = 7,
            trim_start = 8,
            trim_end = 9,
            contains = 10,
            starts_with = 11,
            ends_with = 12,
            index_of = 13,
            last_index_of = 14,
        }
        /// <summary>
        /// This enum is used to identify and retrieve the variables stored within this
        /// macro. The variables can be found in the properties array.
        /// </summary>
        private enum StringProperties
        {
            first_source = 0,
            first_value = 1,
            first_source_macro_id = 2,
            first_source_id = 3,

            second_source = 4,
            second_value = 5,
            second_source_macro_id = 6,
            second_source_id = 7,

            result_source = 8,
            result_value = 9,
            result_source_macro_id = 10,
            result_source_id = 11,

            start_index = 12,
            end_index = 13,
        }

        public string errorMessage { get; private set; }
        public int error { get; private set; }

        private StringAction executedAction;
        private MacroProperty[] properties = new MacroProperty[]
        {
            new MacroProperty()
            {
                name = StringProperties.first_value.ToString(),
                id = (int)StringProperties.first_value,
                type = PropertyType.stringed_value,
                value = string.Empty,
                readOnly = false,
            },
            new MacroProperty()
            {
                name = StringProperties.second_value.ToString(),
                id = (int)StringProperties.second_value,
                type = PropertyType.stringed_value,
                value = string.Empty,
                readOnly = false,
            },
            new MacroProperty()
            {
                name = StringProperties.result_value.ToString(),
                id = (int)StringProperties.result_value,
                type = PropertyType.stringed_value,
                value = string.Empty,
                readOnly = true,
            },
            new MacroProperty()
            {
                name = StringProperties.first_source_id.ToString(),
                id = (int)StringProperties.first_source_id,
                type = PropertyType.dynamic,
                value = string.Empty,
                readOnly = false,
            },
            new MacroProperty()
            {
                name = StringProperties.first_source_macro_id.ToString(),
                id = (int)StringProperties.first_source_macro_id,
                type = PropertyType.integer,
                value = -1,
                readOnly = false,
            },
            new MacroProperty()
            {
                name = StringProperties.second_source_id.ToString(),
                id = (int)StringProperties.second_source_id,
                type = PropertyType.dynamic,
                value = string.Empty,
                readOnly = false,
            },
            new MacroProperty()
            {
                name = StringProperties.second_source_macro_id.ToString(),
                id = (int)StringProperties.second_source_macro_id,
                type = PropertyType.integer,
                value = -1,
                readOnly = false,
            },
            new MacroProperty()
            {
                name = StringProperties.result_source_id.ToString(),
                id = (int)StringProperties.result_source_id,
                type = PropertyType.dynamic,
                value = string.Empty,
                readOnly = false,
            },
            new MacroProperty()
            {
                name = StringProperties.result_source_macro_id.ToString(),
                id = (int)StringProperties.result_source_macro_id,
                type = PropertyType.integer,
                value = -1,
                readOnly = false,
            },
            new MacroProperty()
            {
                name = StringProperties.first_source.ToString(),
                id = (int)StringProperties.first_source,
                type = PropertyType.integer,
                value = (int)DataSource.Self,
                readOnly = false,
                customOptions = () => { return Enum.GetValues(typeof(DataSource)); },
            },
            new MacroProperty()
            {
                name = StringProperties.second_source.ToString(),
                id = (int)StringProperties.second_source,
                type = PropertyType.integer,
                value = (int)DataSource.Self,
                readOnly = false,
                customOptions = () => { return Enum.GetValues(typeof(DataSource)); },
            },
            new MacroProperty()
            {
                name = StringProperties.result_source.ToString(),
                id = (int)StringProperties.result_source,
                type = PropertyType.integer,
                value = (int)DataSource.Self,
                readOnly = false,
                customOptions = () => { return Enum.GetValues(typeof(DataSource)); },
            },
            new MacroProperty()
            {
                name = StringProperties.start_index.ToString(),
                id = (int)StringProperties.start_index,
                type = PropertyType.integer,
                value = 0,
                readOnly = false,
            },
            new MacroProperty()
            {
                name = StringProperties.end_index.ToString(),
                id = (int)StringProperties.end_index,
                type = PropertyType.integer,
                value = 0,
                readOnly = false,
            },
        };

        public StringMacro() : base() { }
        public StringMacro(MacroType other) : base(other) { }

        public override Array GetProperties()
        {
            return Enum.GetValues(typeof(StringProperties));
        }
        public override Array GetShownProperties()
        {
            var allProperties = (StringProperties[])Enum.GetValues(typeof(StringProperties));
            List<StringProperties> shownProperties = new List<StringProperties>();
            for (int i = 0; i < allProperties.Length; i++)
            {
                if (!GetProperty((int)allProperties[i]).readOnly)
                    shownProperties.Add(allProperties[i]);
            }
            return shownProperties.ToArray();
        }
        public override Array GetActions()
        {
            return Enum.GetValues(typeof(StringAction));
        }
        public override void SetAction(int actionId)
        {
            executedAction = (StringAction)actionId;
        }
        public override int GetAction()
        {
            return (int)executedAction;
        }
        public override MacroProperty GetProperty(int propertyId)
        {
            return properties.First(property => property.id == propertyId);
        }
        public override MacroProperty GetProperty(string propertyKey)
        {
            return properties.First(property => property.name.Equals(propertyKey));
        }
        internal override MacroProperty TryGetProperty(string propertyKey, int propertyId)
        {
            return properties.First(property => (!string.IsNullOrEmpty(propertyKey) && property.name.Equals(propertyKey)) || (propertyId >= 0 && property.id == propertyId));
        }
        public override void SetPropertyValue(int propertyId, object value)
        {
            for (int i = 0; i < properties.Length; i++)
            {
                if (properties[i].id == propertyId)
                {
                    properties[i].value = value;
                    break;
                }
            }
        }
        public override void SetPropertyValue(string propertyKey, object value)
        {
            for (int i = 0; i < properties.Length; i++)
            {
                if (properties[i].name.Equals(propertyKey))
                {
                    properties[i].value = value;
                    break;
                }
            }
        }
        internal override void TrySetPropertyValue(string propertyKey, int propertyId, object value)
        {
            if (!string.IsNullOrEmpty(propertyKey))
                SetPropertyValue(propertyKey, value);
            else if (propertyId >= 0)
                SetPropertyValue(propertyId, value);
            else
                throw new KeyNotFoundException();
        }
        public override Task<int> Execute(System.Threading.CancellationToken cancelToken)
        {
            error = 0;
            errorMessage = null;
            try
            {
                var firstSource = (DataSource)GetProperty((int)StringProperties.first_source).value;
                var secondSource = (DataSource)GetProperty((int)StringProperties.second_source).value;
                var resultSource = (DataSource)GetProperty((int)StringProperties.result_source).value;
                object firstSourceId = GetProperty((int)StringProperties.first_source_id).value;
                object secondSourceId = GetProperty((int)StringProperties.second_source_id).value;
                object resultSourceId = GetProperty((int)StringProperties.result_source_id).value;
                int firstSourceMacroId = (int)GetProperty((int)StringProperties.first_source_macro_id).value;
                int secondSourceMacroId = (int)GetProperty((int)StringProperties.second_source_macro_id).value;
                int resultSourceMacroId = (int)GetProperty((int)StringProperties.result_source_macro_id).value;

                MacroType firstMacroSource = GetMacro(firstSourceMacroId);
                MacroType secondMacroSource = GetMacro(secondSourceMacroId);
                MacroType resultMacroSource = GetMacro(resultSourceMacroId);

                string firstValue = string.Empty;
                if ((firstSource & DataSource.Self) != 0)
                    firstValue = GetProperty((int)StringProperties.first_value).value.ToString();
                else if ((firstSource & DataSource.Macro) != 0)
                    firstValue = firstMacroSource.GetProperty((int)firstSourceId).value.ToString();
                else if ((firstSource & DataSource.Database) != 0)
                    firstValue = ValuesDatabase.GetValue(firstSourceId).ToString();

                string secondValue = string.Empty;
                if ((secondSource & DataSource.Self) != 0)
                    secondValue = GetProperty((int)StringProperties.second_value).value.ToString();
                else if ((secondSource & DataSource.Macro) != 0)
                    secondValue = secondMacroSource.GetProperty((int)secondSourceId).value.ToString();
                else if ((secondSource & DataSource.Database) != 0)
                    secondValue = ValuesDatabase.GetValue(secondSourceId).ToString();

                int startIndex = (int)GetProperty((int)StringProperties.start_index).value;
                int endIndex = (int)GetProperty((int)StringProperties.end_index).value;

                object resultValue = string.Empty;
                switch (executedAction)
                {
                    case StringAction.concatenate:
                        resultValue = firstValue + secondValue;
                        break;
                    case StringAction.substring:
                        resultValue = firstValue.Substring(startIndex, (endIndex - startIndex) + 1);
                        break;
                    case StringAction.get_char_at:
                        resultValue = firstValue[startIndex].ToString();
                        break;
                    case StringAction.to_upper:
                        resultValue = firstValue.ToUpper();
                        break;
                    case StringAction.to_lower:
                        resultValue = firstValue.ToLower();
                        break;
                    case StringAction.get_hash_code:
                        resultValue = firstValue.GetHashCode().ToString();
                        break;
                    case StringAction.convert_to_int:
                        resultValue = Convert.ToInt32(firstValue);
                        break;
                    case StringAction.trim:
                        resultValue = firstValue.Trim(secondValue.ToCharArray());
                        break;
                    case StringAction.trim_start:
                        resultValue = firstValue.TrimStart(secondValue.ToCharArray());
                        break;
                    case StringAction.trim_end:
                        resultValue = firstValue.TrimEnd(secondValue.ToCharArray());
                        break;
                    case StringAction.contains:
                        resultValue = firstValue.Contains(secondValue) ? 1 : 0;
                        break;
                    case StringAction.starts_with:
                        resultValue = firstValue.StartsWith(secondValue) ? 1 : 0;
                        break;
                    case StringAction.ends_with:
                        resultValue = firstValue.EndsWith(secondValue) ? 1 : 0;
                        break;
                    case StringAction.index_of:
                        resultValue = firstValue.IndexOf(secondValue);
                        break;
                    case StringAction.last_index_of:
                        resultValue = firstValue.LastIndexOf(secondValue);
                        break;
                }

                if ((resultSource & DataSource.Self) != 0)
                    SetPropertyValue((int)StringProperties.result_value, resultValue);
                if ((resultSource & DataSource.Macro) != 0)
                    resultMacroSource.SetPropertyValue((int)resultSourceId, resultValue);
                if ((resultSource & DataSource.Database) != 0)
                {
                    if (resultValue is string)
                        ValuesDatabase.SetString(resultSourceId, (string)resultValue);
                    else
                        ValuesDatabase.SetInteger(resultSourceId, (int)resultValue);
                }
            }
            catch (Exception e) { error = 1; errorMessage = e.ToString(); }

            return Task.FromResult(error);
        }
    }
}