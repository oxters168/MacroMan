using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MacroMan.MacroActions
{
    public class KeyboardMacro : MacroType
    {
        // Available actions include key down, key up, key press, toggle key, is key down, is key up, is key toggled
        // Available properties include virtual key code

        /// <summary>
        /// This enum is used to identify the action this macro will do
        /// We can create an array of actions if we want for this enum,
        /// but I don't see why I would do that than just manually call the actions
        /// </summary>
        private enum KeyboardAction
        {
            key_down = 0,
            key_up = 1,
            key_press = 2,
            key_toggle = 3,
            get_state = 4,
        }
        /// <summary>
        /// This enum is used to identify and retrieve the variables stored within this
        /// macro. The variables can be found in the properties array.
        /// </summary>
        private enum KeyboardProperties
        {
            key_code = 0,
            is_down = 1,
            is_up = 2,
            is_toggled = 3,
        }
        /*
        /// <summary>
        /// This array should match the properties enum
        /// </summary>
        private PropertyType[] propertyTypes = new PropertyType[]
        {
            PropertyType.integer,
        };
        private object[] properties;
        // If we cange the properties to their own property type, each property would have a name,
        // an id, a type, a stored value, and the possible values. The possible values will be used
        // as a way of knowing if a textbox should be displayed or a dropdown. So if what's returned
        // from possible values is empty or null, it will be a textbox. If what's returned is not
        // empty or null, then it should be a dropdown of those possible values.
        */

        public string errorMessage { get; private set; }
        public int error { get; private set; }

        private KeyboardAction executedAction;
        private MacroProperty[] properties = new MacroProperty[]
        {
            new MacroProperty()
            {
                name = KeyboardProperties.key_code.ToString(),
                id = (int)KeyboardProperties.key_code,
                type = PropertyType.integer,
                value = -1,
                readOnly = false,
            },
            new MacroProperty()
            {
                name = KeyboardProperties.is_down.ToString(),
                id = (int)KeyboardProperties.is_down,
                type = PropertyType.boolean,
                value = false,
                readOnly = true,
            },
            new MacroProperty()
            {
                name = KeyboardProperties.is_up.ToString(),
                id = (int)KeyboardProperties.is_up,
                type = PropertyType.boolean,
                value = false,
                readOnly = true,
            },
            new MacroProperty()
            {
                name = KeyboardProperties.is_toggled.ToString(),
                id = (int)KeyboardProperties.is_toggled,
                type = PropertyType.boolean,
                value = false,
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
            return EnumToDictionary(typeof(KeyboardAction));
        }
        public override void SetAction(int actionId)
        {
            executedAction = (KeyboardAction)actionId;
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
                switch ((KeyboardAction)executedAction)
                {
                    case KeyboardAction.key_down:
                        KeyboardOperations.KeyDown((VirtualKey)GetPropertyValue((int)KeyboardProperties.key_code));
                        break;
                    case KeyboardAction.key_up:
                        break;
                    case KeyboardAction.key_press:
                        break;
                    case KeyboardAction.key_toggle:
                        break;
                    case KeyboardAction.get_state:
                        break;
                }
            }
            catch (Exception e) { error = 1; errorMessage = e.ToString(); }

            return error;
        }
    }
}
