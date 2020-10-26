using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MacroMan.MacroActions
{
    public class IntegerMacro : MacroType
    {
        // Available actions include key down, key up, key press, toggle key, is key down, is key up, is key toggled
        // Available properties include virtual key code

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
        };

        //public KeyboardMacro()
        //{
        //    int propertyCount = Enum.GetValues(typeof(KeyboardProperties)).Length;
        //    properties = new object[propertyCount];
        //}

        public override Dictionary<int, string> GetProperties()
        {
            //return EnumToDictionary(typeof(KeyboardProperties));
            return PropsToDictionary(properties);
        }
        public override Dictionary<int, string> GetActions()
        {
            return EnumToDictionary(typeof(IntegerAction));
        }
        public override void SetAction(int actionId)
        {
            executedAction = (IntegerAction)actionId;
        }
        public override int GetAction()
        {
            return (int)executedAction;
        }
        internal override MacroProperty GetProperty(int propertyId)
        {
            return properties.First(property => property.id == propertyId);
        }
        public override void SetPropertyValue(int propertyId, object value)
        {
            //properties[propertyId] = value;
            //GetProperty(propertyId).value = value;

            //Since MacroProperty is a struct
            for (int i = 0; i < properties.Length; i++)
            {
                if (properties[i].id == propertyId)
                {
                    properties[i].value = value;
                    break;
                }
            }
        }
        public override object GetPropertyValue(int propertyId)
        {
            return GetProperty(propertyId).value;
        }
        public override int GetPropertyType(int propertyId)
        {
            return (int)GetProperty(propertyId).type;
        }
        public override bool IsPropertyReadOnly(int propertyId)
        {
            return GetProperty(propertyId).readOnly;
        }
        public override async Task<int> Execute()
        {
            error = 0;
            errorMessage = null;
            try
            {
                var firstSource = (DataSource)GetPropertyValue((int)IntegerProperties.first_source);
                int firstSourceId = (int)GetPropertyValue((int)IntegerProperties.first_source_id);
                var secondSource = (DataSource)GetPropertyValue((int)IntegerProperties.second_source);
                int secondSourceId = (int)GetPropertyValue((int)IntegerProperties.first_source_id);
                var resultSource = (DataSource)GetPropertyValue((int)IntegerProperties.result_source);
                int resultSourceId = (int)GetPropertyValue((int)IntegerProperties.first_source_id);

                switch ((IntegerAction)executedAction)
                {
                    case IntegerAction.add:
                        SetPropertyValue((int)IntegerProperties.result_value, (int)GetPropertyValue((int)IntegerProperties.first_value) + (int)GetPropertyValue((int)IntegerProperties.second_value));
                        break;
                    case IntegerAction.subtract:
                        break;
                    case IntegerAction.multiply:
                        break;
                    case IntegerAction.divide:
                        break;
                    case IntegerAction.modulo:
                        break;
                }
            }
            catch (Exception e) { error = 1; errorMessage = e.ToString(); }

            return error;
        }
    }
}
