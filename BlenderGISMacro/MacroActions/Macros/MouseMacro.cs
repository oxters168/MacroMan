using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MacroMan.MacroActions
{
    [Serializable]
    public class MouseMacro : MacroType
    {
        /// <summary>
        /// This enum is used to identify the action this macro will do
        /// We can create an array of actions if we want for this enum,
        /// but I don't see why I would do that than just manually call the actions
        /// </summary>
        private enum MouseAction
        {
            set_pos = 0,
            button_click = 1,
            button_down = 2,
            button_up = 3,
            get_pos = 4,
            scroll_up = 5,
            scroll_down = 6,
            scroll_left = 7,
            scroll_right = 8,
            //get_pressed = 5,
        }
        /// <summary>
        /// This enum is used to identify and retrieve the variables stored within this
        /// macro. The variables can be found in the properties array.
        /// </summary>
        private enum MouseProperties
        {
            x_pos = 0,
            y_pos = 1,
            button = 2,
        }

        public string errorMessage { get; private set; }
        public int error { get; private set; }

        private MouseAction executedAction;
        private MacroProperty[] properties = new MacroProperty[]
        {
            new MacroProperty()
            {
                name = MouseProperties.x_pos.ToString(),
                id = (int)MouseProperties.x_pos,
                type = PropertyType.integer,
                value = 0,
                readOnly = false,
            },
            new MacroProperty()
            {
                name = MouseProperties.y_pos.ToString(),
                id = (int)MouseProperties.y_pos,
                type = PropertyType.integer,
                value = 0,
                readOnly = false,
            },
            new MacroProperty()
            {
                name = MouseProperties.button.ToString(),
                id = (int)MouseProperties.button,
                type = PropertyType.integer,
                value = 0,
                readOnly = false,
                customOptions = () => { return Enum.GetValues(typeof(MouseButton)); }
            },
        };

        public MouseMacro() : base() { }
        public MouseMacro(MacroType other) : base(other) { }

        public override Array GetProperties()
        {
            return Enum.GetValues(typeof(MouseProperties));
        }
        public override Array GetShownProperties()
        {
            var allProperties = (MouseProperties[])Enum.GetValues(typeof(MouseProperties));
            List<MouseProperties> shownProperties = new List<MouseProperties>();
            for (int i = 0; i < allProperties.Length; i++)
            {
                if (!GetProperty((int)allProperties[i]).readOnly)
                    shownProperties.Add(allProperties[i]);
            }
            return shownProperties.ToArray();
        }
        public override Array GetActions()
        {
            return Enum.GetValues(typeof(MouseAction));
        }
        public override void SetAction(int actionId)
        {
            executedAction = (MouseAction)actionId;
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
                MouseButton button = (MouseButton)GetProperty((int)MouseProperties.button).value;

                switch (executedAction)
                {
                    case MouseAction.set_pos:
                        MouseOperations.SetCursorPosition((int)GetProperty((int)MouseProperties.x_pos).value, (int)GetProperty((int)MouseProperties.y_pos).value);
                        //MouseOperations.SetPosition((int)GetProperty((int)MouseProperties.x_pos).value, (int)GetProperty((int)MouseProperties.y_pos).value);
                        break;
                    case MouseAction.button_click:
                        switch (button)
                        {
                            case MouseButton.left:
                                MouseOperations.LeftButtonDown();
                                MouseOperations.LeftButtonUp();
                                break;
                            case MouseButton.right:
                                MouseOperations.RightButtonDown();
                                MouseOperations.RightButtonUp();
                                break;
                            case MouseButton.middle:
                                MouseOperations.MiddleButtonDown();
                                MouseOperations.MiddleButtonUp();
                                break;
                        }
                        break;
                    case MouseAction.button_down:
                        switch (button)
                        {
                            case MouseButton.left:
                                MouseOperations.LeftButtonDown();
                                break;
                            case MouseButton.right:
                                MouseOperations.RightButtonDown();
                                break;
                            case MouseButton.middle:
                                MouseOperations.MiddleButtonDown();
                                break;
                        }
                        break;
                    case MouseAction.button_up:
                        switch (button)
                        {
                            case MouseButton.left:
                                MouseOperations.LeftButtonUp();
                                break;
                            case MouseButton.right:
                                MouseOperations.RightButtonUp();
                                break;
                            case MouseButton.middle:
                                MouseOperations.MiddleButtonUp();
                                break;
                        }
                        break;
                    case MouseAction.get_pos:
                        var pos = MouseOperations.GetCursorPosition();
                        SetPropertyValue((int)MouseProperties.x_pos, pos.X);
                        SetPropertyValue((int)MouseProperties.y_pos, pos.Y);
                        break;
                    case MouseAction.scroll_down:
                        MouseOperations.ScrollDown();
                        break;
                    case MouseAction.scroll_up:
                        MouseOperations.ScrollUp();
                        break;
                    case MouseAction.scroll_left:
                        MouseOperations.ScrollLeft();
                        break;
                    case MouseAction.scroll_right:
                        MouseOperations.ScrollRight();
                        break;
                }
            }
            catch (Exception e) { error = 1; errorMessage = e.ToString(); }

            return Task.FromResult(error);
        }
    }
}
