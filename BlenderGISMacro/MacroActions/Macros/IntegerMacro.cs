using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MacroMan.MacroActions
{
    [Serializable]
    public class IntegerMacro : MacroType
    {
        /// <summary>
        /// This enum is used to identify the action this macro will do
        /// We can create an array of actions if we want for this enum,
        /// but I don't see why I would do that than just manually call the actions
        /// </summary>
        private enum IntegerAction
        {
            operate = 0,
        }
        /// <summary>
        /// This enum is used to identify and retrieve the variables stored within this
        /// macro. The variables can be found in the properties array.
        /// </summary>
        private enum IntegerProperties
        {
            operation = 0,

            first_source = 1,
            first_value = 2,
            first_source_macro_id = 3,
            first_source_id = 4,

            second_source = 5,
            second_value = 6,
            second_source_macro_id = 7,
            second_source_id = 8,

            result_source = 9,
            result_value = 10,
            result_source_macro_id = 11,
            result_source_id = 12,
        }

        public string errorMessage { get; private set; }
        public int error { get; private set; }

        private IntegerAction executedAction;
        private MacroProperty[] properties = new MacroProperty[]
        {
            new MacroProperty()
            {
                name = IntegerProperties.operation.ToString(),
                id = (int)IntegerProperties.operation,
                type = PropertyType.integer,
                value = 0,
                readOnly = false,
                customOptions = () => { return Enum.GetValues(typeof(AlgebraicOperations)); },
            },
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
                type = PropertyType.dynamic,
                value = string.Empty,
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
                name = IntegerProperties.second_source_id.ToString(),
                id = (int)IntegerProperties.second_source_id,
                type = PropertyType.dynamic,
                value = string.Empty,
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
                name = IntegerProperties.result_source_id.ToString(),
                id = (int)IntegerProperties.result_source_id,
                type = PropertyType.dynamic,
                value = string.Empty,
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
                name = IntegerProperties.first_source.ToString(),
                id = (int)IntegerProperties.first_source,
                type = PropertyType.integer,
                value = (int)DataSource.Self,
                readOnly = false,
                customOptions = () => { return Enum.GetValues(typeof(DataSource)); },
            },
            new MacroProperty()
            {
                name = IntegerProperties.second_source.ToString(),
                id = (int)IntegerProperties.second_source,
                type = PropertyType.integer,
                value = (int)DataSource.Self,
                readOnly = false,
                customOptions = () => { return Enum.GetValues(typeof(DataSource)); },
            },
            new MacroProperty()
            {
                name = IntegerProperties.result_source.ToString(),
                id = (int)IntegerProperties.result_source,
                type = PropertyType.integer,
                value = (int)DataSource.Self,
                readOnly = false,
                customOptions = () => { return Enum.GetValues(typeof(DataSource)); },
            },
        };

        public IntegerMacro() : base() { }
        public IntegerMacro(MacroType other) : base(other) { }

        public override Array GetProperties()
        {
            return Enum.GetValues(typeof(IntegerProperties));
        }
        public override Array GetShownProperties()
        {
            var allProperties = (IntegerProperties[])Enum.GetValues(typeof(IntegerProperties));
            List<IntegerProperties> shownProperties = new List<IntegerProperties>();
            for (int i = 0; i < allProperties.Length; i++)
            {
                if (!GetProperty((int)allProperties[i]).readOnly)
                    shownProperties.Add(allProperties[i]);
            }
            return shownProperties.ToArray();
        }
        public override Array GetActions()
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
        public override Task<int> Execute(System.Threading.CancellationToken cancelToken)
        {
            error = 0;
            errorMessage = null;
            try
            {
                var operation = (AlgebraicOperations)GetProperty((int)IntegerProperties.operation).value;
                var firstSource = (DataSource)GetProperty((int)IntegerProperties.first_source).value;
                var secondSource = (DataSource)GetProperty((int)IntegerProperties.second_source).value;
                var resultSource = (DataSource)GetProperty((int)IntegerProperties.result_source).value;
                object firstSourceId = GetProperty((int)IntegerProperties.first_source_id).value;
                object secondSourceId = GetProperty((int)IntegerProperties.second_source_id).value;
                object resultSourceId = GetProperty((int)IntegerProperties.result_source_id).value;
                int firstSourceMacroId = (int)GetProperty((int)IntegerProperties.first_source_macro_id).value;
                int secondSourceMacroId = (int)GetProperty((int)IntegerProperties.second_source_macro_id).value;
                int resultSourceMacroId = (int)GetProperty((int)IntegerProperties.result_source_macro_id).value;

                MacroType firstMacroSource = GetMacro(firstSourceMacroId);
                MacroType secondMacroSource = GetMacro(secondSourceMacroId);
                MacroType resultMacroSource = GetMacro(resultSourceMacroId);

                int firstValue = 0;
                if ((firstSource & DataSource.Self) != 0)
                    firstValue = (int)GetProperty((int)IntegerProperties.first_value).value;
                else if ((firstSource & DataSource.Macro) != 0)
                    firstValue = Convert.ToInt32(firstMacroSource.GetProperty((int)firstSourceId).value);
                else if ((firstSource & DataSource.Database) != 0)
                    firstValue = ValuesDatabase.GetInteger(firstSourceId);

                int secondValue = 0;
                if ((secondSource & DataSource.Self) != 0)
                    secondValue = (int)GetProperty((int)IntegerProperties.second_value).value;
                else if ((secondSource & DataSource.Macro) != 0)
                    secondValue = Convert.ToInt32(secondMacroSource.GetProperty((int)secondSourceId).value);
                else if ((secondSource & DataSource.Database) != 0)
                    secondValue = ValuesDatabase.GetInteger(secondSourceId);

                int resultValue = 0;
                switch (executedAction)
                {
                    case IntegerAction.operate:
                        switch (operation)
                        {
                            case AlgebraicOperations.add:
                                resultValue = firstValue + secondValue;
                                break;
                            case AlgebraicOperations.subtract:
                                resultValue = firstValue - secondValue;
                                break;
                            case AlgebraicOperations.multiply:
                                resultValue = firstValue * secondValue;
                                break;
                            case AlgebraicOperations.divide:
                                resultValue = firstValue / secondValue;
                                break;
                            case AlgebraicOperations.modulo:
                                resultValue = firstValue % secondValue;
                                break;
                        }
                        break;
                }

                if ((resultSource & DataSource.Self) != 0)
                    SetPropertyValue((int)IntegerProperties.result_value, resultValue);
                if ((resultSource & DataSource.Macro) != 0)
                    resultMacroSource.SetPropertyValue((int)resultSourceId, resultValue);
                if ((resultSource & DataSource.Database) != 0)
                    ValuesDatabase.SetInteger(resultSourceId, resultValue);
            }
            catch (Exception e) { error = 1; errorMessage = e.ToString(); }

            return Task.FromResult(error);
        }
    }
}
