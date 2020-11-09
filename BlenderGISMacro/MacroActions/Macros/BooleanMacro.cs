using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MacroMan.MacroActions
{
    [Serializable]
    public class BooleanMacro : MacroType
    {
        /// <summary>
        /// This enum is used to identify the action this macro will do
        /// We can create an array of actions if we want for this enum,
        /// but I don't see why I would do that than just manually call the actions
        /// </summary>
        private enum BooleanAction
        {
            compare = 0,
        }
        /// <summary>
        /// This enum is used to identify and retrieve the variables stored within this
        /// macro. The variables can be found in the properties array.
        /// </summary>
        private enum BooleanProperties
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

        private BooleanAction executedAction;
        private MacroProperty[] properties = new MacroProperty[]
        {
            new MacroProperty()
            {
                name = BooleanProperties.operation.ToString(),
                id = (int)BooleanProperties.operation,
                type = PropertyType.integer,
                value = 0,
                readOnly = false,
                customOptions = () => { return Enum.GetValues(typeof(BooleanOperations)); },
            },
            new MacroProperty()
            {
                name = BooleanProperties.first_value.ToString(),
                id = (int)BooleanProperties.first_value,
                type = PropertyType.integer,
                value = 0,
                readOnly = false,
            },
            new MacroProperty()
            {
                name = BooleanProperties.first_source_macro_id.ToString(),
                id = (int)BooleanProperties.first_source_macro_id,
                type = PropertyType.integer,
                value = -1,
                readOnly = false,
            },
            new MacroProperty()
            {
                name = BooleanProperties.first_source_id.ToString(),
                id = (int)BooleanProperties.first_source_id,
                type = PropertyType.dynamic,
                value = string.Empty,
                readOnly = false,
            },
            new MacroProperty()
            {
                name = BooleanProperties.first_source.ToString(),
                id = (int)BooleanProperties.first_source,
                type = PropertyType.integer,
                value = (int)DataSource.Self,
                readOnly = false,
                customOptions = () => { return Enum.GetValues(typeof(DataSource)); },
            },
                        new MacroProperty()
            {
                name = BooleanProperties.second_value.ToString(),
                id = (int)BooleanProperties.second_value,
                type = PropertyType.integer,
                value = 0,
                readOnly = false,
            },
            new MacroProperty()
            {
                name = BooleanProperties.second_source_macro_id.ToString(),
                id = (int)BooleanProperties.second_source_macro_id,
                type = PropertyType.integer,
                value = -1,
                readOnly = false,
            },
            new MacroProperty()
            {
                name = BooleanProperties.second_source_id.ToString(),
                id = (int)BooleanProperties.second_source_id,
                type = PropertyType.dynamic,
                value = string.Empty,
                readOnly = false,
            },
            new MacroProperty()
            {
                name = BooleanProperties.second_source.ToString(),
                id = (int)BooleanProperties.second_source,
                type = PropertyType.integer,
                value = (int)DataSource.Self,
                readOnly = false,
                customOptions = () => { return Enum.GetValues(typeof(DataSource)); },
            },
            new MacroProperty()
            {
                name = BooleanProperties.result_value.ToString(),
                id = (int)BooleanProperties.result_value,
                type = PropertyType.integer,
                value = 0,
                readOnly = true,
            },
            new MacroProperty()
            {
                name = BooleanProperties.result_source_macro_id.ToString(),
                id = (int)BooleanProperties.result_source_macro_id,
                type = PropertyType.integer,
                value = -1,
                readOnly = false,
            },
            new MacroProperty()
            {
                name = BooleanProperties.result_source_id.ToString(),
                id = (int)BooleanProperties.result_source_id,
                type = PropertyType.dynamic,
                value = string.Empty,
                readOnly = false,
            },
            new MacroProperty()
            {
                name = BooleanProperties.result_source.ToString(),
                id = (int)BooleanProperties.result_source,
                type = PropertyType.integer,
                value = (int)DataSource.Self,
                readOnly = false,
                customOptions = () => { return Enum.GetValues(typeof(DataSource)); },
            },

        };

        public BooleanMacro() : base() { }
        public BooleanMacro(MacroType other) : base(other) { }

        public override Array GetProperties()
        {
            return Enum.GetValues(typeof(BooleanProperties));
        }
        public override Array GetShownProperties()
        {
            var allProperties = (BooleanProperties[])Enum.GetValues(typeof(BooleanProperties));
            List<BooleanProperties> shownProperties = new List<BooleanProperties>();
            for (int i = 0; i < allProperties.Length; i++)
            {
                if (!GetProperty((int)allProperties[i]).readOnly)
                    shownProperties.Add(allProperties[i]);
            }
            return shownProperties.ToArray();
        }
        public override Array GetActions()
        {
            return Enum.GetValues(typeof(BooleanAction));
        }
        public override void SetAction(int actionId)
        {
            executedAction = (BooleanAction)actionId;
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
                var operation = (BooleanOperations)GetProperty((int)BooleanProperties.operation).value;
                var firstSource = (DataSource)GetProperty((int)BooleanProperties.first_source).value;
                var secondSource = (DataSource)GetProperty((int)BooleanProperties.second_source).value;
                var resultSource = (DataSource)GetProperty((int)BooleanProperties.result_source).value;
                object firstSourceId = GetProperty((int)BooleanProperties.first_source_id).value;
                object secondSourceId = GetProperty((int)BooleanProperties.second_source_id).value;
                object resultSourceId = GetProperty((int)BooleanProperties.result_source_id).value;
                int firstSourceMacroId = (int)GetProperty((int)BooleanProperties.first_source_macro_id).value;
                int secondSourceMacroId = (int)GetProperty((int)BooleanProperties.second_source_macro_id).value;
                int resultSourceMacroId = (int)GetProperty((int)BooleanProperties.result_source_macro_id).value;

                MacroType firstMacroSource = GetMacro(firstSourceMacroId);
                MacroType secondMacroSource = GetMacro(secondSourceMacroId);
                MacroType resultMacroSource = GetMacro(resultSourceMacroId);

                IComparable firstValue = 0;
                if ((firstSource & DataSource.Self) != 0)
                    firstValue = (IComparable)GetProperty((int)BooleanProperties.first_value).value;
                else if ((firstSource & DataSource.Macro) != 0)
                    firstValue = (IComparable)firstMacroSource.GetProperty((int)firstSourceId).value;
                else if ((firstSource & DataSource.Database) != 0)
                    firstValue = (IComparable)ValuesDatabase.GetValue(firstSourceId);

                IComparable secondValue = 0;
                if ((secondSource & DataSource.Self) != 0)
                    secondValue = (IComparable)GetProperty((int)BooleanProperties.second_value).value;
                else if ((secondSource & DataSource.Macro) != 0)
                    secondValue = (IComparable)secondMacroSource.GetProperty((int)secondSourceId).value;
                else if ((secondSource & DataSource.Database) != 0)
                    secondValue = (IComparable)ValuesDatabase.GetValue(secondSourceId);

                bool resultValue = false;
                switch (executedAction)
                {
                    case BooleanAction.compare:
                        switch (operation)
                        {
                            case BooleanOperations.equal_to:
                                resultValue = firstValue.CompareTo(secondValue) == 0;
                                break;
                            case BooleanOperations.greater_than:
                                resultValue = firstValue.CompareTo(secondValue) > 0;
                                break;
                            case BooleanOperations.greater_than_or_equal_to:
                                resultValue = firstValue.CompareTo(secondValue) >= 0;
                                break;
                            case BooleanOperations.less_than:
                                resultValue = firstValue.CompareTo(secondValue) < 0;
                                break;
                            case BooleanOperations.less_than_or_equal_to:
                                resultValue = firstValue.CompareTo(secondValue) <= 0;
                                break;
                        }
                        break;
                }

                if ((resultSource & DataSource.Self) != 0)
                    SetPropertyValue((int)BooleanProperties.result_value, resultValue ? 1 : 0);
                if ((resultSource & DataSource.Macro) != 0)
                    resultMacroSource.SetPropertyValue((int)resultSourceId, resultValue ? 1 : 0);
                if ((resultSource & DataSource.Database) != 0)
                    ValuesDatabase.SetInteger(resultSourceId, resultValue ? 1 : 0);
            }
            catch (Exception e) { error = 1; errorMessage = e.ToString(); }

            return Task.FromResult(error);
        }
    }
}
