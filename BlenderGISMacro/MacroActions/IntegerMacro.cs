using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MacroMan.MacroActions
{
    public class IntegerMacro : MacroType
    {
        /// <summary>
        /// This enum is used to identify the action this macro will do
        /// We can create an array of actions if we want for this enum,
        /// but I don't see why I would do that than just manually call the actions
        /// </summary>
        private enum IntegerAction
        {
            add = 0,
            subtract = 1,
            multiply = 2,
            divide = 3,
            modulo = 4,
        }
        /// <summary>
        /// This enum is used to identify and retrieve the variables stored within this
        /// macro. The variables can be found in the properties array.
        /// </summary>
        private enum IntegerProperties
        {
            first_value = 0,
            second_value = 1,
            result_value = 2,
            first_source = 3,
            first_source_id = 4,
            second_source = 5,
            second_source_id = 6,
            result_source = 7,
            result_source_id = 8,
            first_source_key = 9,
            first_source_macro_id = 10,
            first_source_macro_key = 11,
            second_source_key = 12,
            second_source_macro_id = 13,
            second_source_macro_key = 14,
            result_source_key = 15,
            result_source_macro_id = 16,
            result_source_macro_key = 17,
        }

        public string errorMessage { get; private set; }
        public int error { get; private set; }

        private IntegerAction executedAction;
        private MacroProperty[] properties = new MacroProperty[]
        {
            new MacroProperty()
            {
                name = IntegerProperties.first_value.ToString(),
                id = (int)IntegerProperties.first_value,
                type = PropertyType.integer,
                value = 0,
                readOnly = false,
            },
            new MacroProperty()
            {
                name = IntegerProperties.second_value.ToString(),
                id = (int)IntegerProperties.second_value,
                type = PropertyType.integer,
                value = 0,
                readOnly = false,
            },
            new MacroProperty()
            {
                name = IntegerProperties.result_value.ToString(),
                id = (int)IntegerProperties.result_value,
                type = PropertyType.integer,
                value = 0,
                readOnly = true,
            },
            new MacroProperty()
            {
                name = IntegerProperties.first_source_id.ToString(),
                id = (int)IntegerProperties.first_source_id,
                type = PropertyType.integer,
                value = 0,
                readOnly = false,
            },
            new MacroProperty()
            {
                name = IntegerProperties.first_source_key.ToString(),
                id = (int)IntegerProperties.first_source_key,
                type = PropertyType.stringed_value,
                value = null,
                readOnly = false,
            },
            new MacroProperty()
            {
                name = IntegerProperties.first_source_macro_id.ToString(),
                id = (int)IntegerProperties.first_source_macro_id,
                type = PropertyType.integer,
                value = -1,
                readOnly = false,
            },
            new MacroProperty()
            {
                name = IntegerProperties.first_source_macro_key.ToString(),
                id = (int)IntegerProperties.first_source_macro_key,
                type = PropertyType.stringed_value,
                value = null,
                readOnly = false,
            },
            new MacroProperty()
            {
                name = IntegerProperties.second_source_id.ToString(),
                id = (int)IntegerProperties.second_source_id,
                type = PropertyType.integer,
                value = -1,
                readOnly = false,
            },
            new MacroProperty()
            {
                name = IntegerProperties.second_source_key.ToString(),
                id = (int)IntegerProperties.second_source_key,
                type = PropertyType.stringed_value,
                value = null,
                readOnly = false,
            },
            new MacroProperty()
            {
                name = IntegerProperties.second_source_macro_id.ToString(),
                id = (int)IntegerProperties.second_source_macro_id,
                type = PropertyType.integer,
                value = -1,
                readOnly = false,
            },
            new MacroProperty()
            {
                name = IntegerProperties.second_source_macro_key.ToString(),
                id = (int)IntegerProperties.second_source_macro_key,
                type = PropertyType.stringed_value,
                value = null,
                readOnly = false,
            },
            new MacroProperty()
            {
                name = IntegerProperties.result_source_id.ToString(),
                id = (int)IntegerProperties.result_source_id,
                type = PropertyType.integer,
                value = -1,
                readOnly = false,
            },
            new MacroProperty()
            {
                name = IntegerProperties.result_source_key.ToString(),
                id = (int)IntegerProperties.result_source_key,
                type = PropertyType.stringed_value,
                value = null,
                readOnly = false,
            },
            new MacroProperty()
            {
                name = IntegerProperties.result_source_macro_id.ToString(),
                id = (int)IntegerProperties.result_source_macro_id,
                type = PropertyType.integer,
                value = -1,
                readOnly = false,
            },
            new MacroProperty()
            {
                name = IntegerProperties.result_source_macro_key.ToString(),
                id = (int)IntegerProperties.result_source_macro_key,
                type = PropertyType.integer,
                value = null,
                readOnly = false,
            },
            new MacroProperty()
            {
                name = IntegerProperties.first_source.ToString(),
                id = (int)IntegerProperties.first_source,
                type = PropertyType.integer,
                value = 0,
                readOnly = false,
            },
            new MacroProperty()
            {
                name = IntegerProperties.second_source.ToString(),
                id = (int)IntegerProperties.second_source,
                type = PropertyType.integer,
                value = 0,
                readOnly = false,
            },
            new MacroProperty()
            {
                name = IntegerProperties.result_source.ToString(),
                id = (int)IntegerProperties.result_source,
                type = PropertyType.integer,
                value = 0,
                readOnly = false,
            },
        };

        /*public static Dictionary<int, string> GetProperties()
        {
            return EnumToDictionary(typeof(IntegerProperties));
        }
        public static Dictionary<int, string> GetActions()
        {
            return EnumToDictionary(typeof(IntegerAction));
        }*/
        public static Array GetProperties()
        {
            return Enum.GetValues(typeof(IntegerProperties));
        }
        public static Array GetActions()
        {
            return Enum.GetValues(typeof(IntegerAction));
        }

        public override void SetAction(int actionId)
        {
            executedAction = (IntegerAction)actionId;
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
        public override Task<int> Execute()
        {
            error = 0;
            errorMessage = null;
            try
            {
                var firstSource = (DataSource)GetProperty((int)IntegerProperties.first_source).value;
                var secondSource = (DataSource)GetProperty((int)IntegerProperties.second_source).value;
                var resultSource = (DataSource)GetProperty((int)IntegerProperties.result_source).value;
                int firstSourceId = (int)GetProperty((int)IntegerProperties.first_source_id).value;
                int secondSourceId = (int)GetProperty((int)IntegerProperties.first_source_id).value;
                int resultSourceId = (int)GetProperty((int)IntegerProperties.first_source_id).value;
                int firstSourceMacroId = (int)GetProperty((int)IntegerProperties.first_source_macro_id).value;
                int secondSourceMacroId = (int)GetProperty((int)IntegerProperties.second_source_macro_id).value;
                int resultSourceMacroId = (int)GetProperty((int)IntegerProperties.result_source_macro_id).value;

                string firstSourceKey = (string)GetProperty((int)IntegerProperties.first_source_key).value;
                string secondSourceKey = (string)GetProperty((int)IntegerProperties.second_source_key).value;
                string resultSourceKey = (string)GetProperty((int)IntegerProperties.result_source_key).value;
                string firstSourceMacroKey = (string)GetProperty((int)IntegerProperties.first_source_macro_key).value;
                string secondSourceMacroKey = (string)GetProperty((int)IntegerProperties.second_source_macro_key).value;
                string resultSourceMacroKey = (string)GetProperty((int)IntegerProperties.result_source_macro_key).value;

                MacroType firstMacroSource = TryGetMacro(firstSourceMacroKey, firstSourceMacroId);
                MacroType secondMacroSource = TryGetMacro(secondSourceMacroKey, firstSourceMacroId);
                MacroType resultMacroSource = TryGetMacro(resultSourceMacroKey, firstSourceMacroId);

                int firstValue = 0;
                if ((firstSource & DataSource.self) != 0)
                    firstValue = (int)TryGetProperty(firstSourceKey, firstSourceId).value;
                else if ((firstSource & DataSource.macro) != 0)
                    firstValue = Convert.ToInt32(firstMacroSource.TryGetProperty(firstSourceKey, firstSourceId).value);
                else if ((firstSource & DataSource.database) != 0)
                    firstValue = ValuesDatabase.TryGetInteger(firstSourceKey, firstSourceId);

                int secondValue = 0;
                if ((secondSource & DataSource.self) != 0)
                    secondValue = (int)TryGetProperty(secondSourceKey, secondSourceId).value;
                else if ((secondSource & DataSource.macro) != 0)
                    secondValue = Convert.ToInt32(secondMacroSource.TryGetProperty(secondSourceKey, secondSourceId).value);
                else if ((secondSource & DataSource.database) != 0)
                    secondValue = ValuesDatabase.TryGetInteger(secondSourceKey, secondSourceId);

                int resultValue = 0;
                switch (executedAction)
                {
                    case IntegerAction.add:
                        resultValue = firstValue + secondValue;
                        break;
                    case IntegerAction.subtract:
                        resultValue = firstValue - secondValue;
                        break;
                    case IntegerAction.multiply:
                        resultValue = firstValue * secondValue;
                        break;
                    case IntegerAction.divide:
                        resultValue = firstValue / secondValue;
                        break;
                    case IntegerAction.modulo:
                        resultValue = firstValue % secondValue;
                        break;
                }

                if ((resultSource & DataSource.self) != 0)
                    TrySetPropertyValue(resultSourceKey, resultSourceId, resultValue);
                if ((resultSource & DataSource.macro) != 0)
                    resultMacroSource.TrySetPropertyValue(resultSourceKey, resultSourceId, resultValue);
                if ((resultSource & DataSource.database) != 0)
                    ValuesDatabase.TrySetInteger(resultSourceKey, resultSourceId, resultValue);
            }
            catch (Exception e) { error = 1; errorMessage = e.ToString(); }

            return Task.FromResult(error);
        }
    }
}
