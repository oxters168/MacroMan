using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MacroMan.MacroActions
{
    public class KeyboardMacro : MacroType
    {
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
            toggle_state = 1,
            is_pressed = 2,
            is_toggled = 3,
        }

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
                customOptions = () => { return Enum.GetValues(typeof(VirtualKey)); },
            },
            new MacroProperty()
            {
                name = KeyboardProperties.toggle_state.ToString(),
                id = (int)KeyboardProperties.toggle_state,
                type = PropertyType.boolean,
                value = 0,
                readOnly = false,
            },
            new MacroProperty()
            {
                name = KeyboardProperties.is_pressed.ToString(),
                id = (int)KeyboardProperties.is_pressed,
                type = PropertyType.boolean,
                value = 0,
                readOnly = true,
            },
            new MacroProperty()
            {
                name = KeyboardProperties.is_toggled.ToString(),
                id = (int)KeyboardProperties.is_toggled,
                type = PropertyType.boolean,
                value = 0,
                readOnly = true,
            },
        };

        public KeyboardMacro() : base() { }
        public KeyboardMacro(MacroType other) : base(other) { }

        public override Array GetProperties()
        {
            return Enum.GetValues(typeof(KeyboardProperties));
        }
        public override Array GetShownProperties()
        {
            var allProperties = (KeyboardProperties[])Enum.GetValues(typeof(KeyboardProperties));
            List<KeyboardProperties> shownProperties = new List<KeyboardProperties>();
            for (int i = 0; i < allProperties.Length; i++)
            {
                if (!GetProperty((int)allProperties[i]).readOnly)
                    shownProperties.Add(allProperties[i]);
            }
            return shownProperties.ToArray();
        }
        public override Array GetActions()
        {
            return Enum.GetValues(typeof(KeyboardAction));
        }
        public override void SetAction(int actionId)
        {
            executedAction = (KeyboardAction)actionId;
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
                switch (executedAction)
                {
                    case KeyboardAction.key_down:
                        KeyboardOperations.KeyDown((VirtualKey)GetProperty((int)KeyboardProperties.key_code).value);
                        break;
                    case KeyboardAction.key_up:
                        KeyboardOperations.KeyUp((VirtualKey)GetProperty((int)KeyboardProperties.key_code).value);
                        break;
                    case KeyboardAction.key_press:
                        KeyboardOperations.KeyPress((VirtualKey)GetProperty((int)KeyboardProperties.key_code).value);
                        break;
                    case KeyboardAction.key_toggle:
                        KeyboardOperations.SetToggleState((VirtualKey)GetProperty((int)KeyboardProperties.key_code).value, (bool)GetProperty((int)KeyboardProperties.toggle_state).value);
                        break;
                    case KeyboardAction.get_state:
                        SetPropertyValue((int)KeyboardProperties.is_pressed, KeyboardOperations.IsKeyPressed((VirtualKey)GetProperty((int)KeyboardProperties.key_code).value));
                        SetPropertyValue((int)KeyboardProperties.is_toggled, KeyboardOperations.IsKeyToggled((VirtualKey)GetProperty((int)KeyboardProperties.key_code).value));
                        break;
                }
            }
            catch (Exception e) { error = 1; errorMessage = e.ToString(); }

            return Task.FromResult(error);
        }
    }
}
