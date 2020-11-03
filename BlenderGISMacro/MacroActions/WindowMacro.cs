using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MacroMan.MacroActions
{
    public class WindowMacro : MacroType
    {
        /// <summary>
        /// This enum is used to identify the action this macro will do
        /// We can create an array of actions if we want for this enum,
        /// but I don't see why I would do that than just manually call the actions
        /// </summary>
        private enum WindowAction
        {
            bring_to_front = 0,
            maximize = 1,
            unmaximize = 2,
            minimize = 3,
            unminimize = 4,
            set_pos = 5,
            set_size = 6,
            get_minimized = 7,
            get_maximized = 8,
            get_pos = 9,
            get_size = 10,
        }
        /// <summary>
        /// This enum is used to identify and retrieve the variables stored within this
        /// macro. The variables can be found in the properties array.
        /// </summary>
        private enum WindowProperties
        {
            pid = 0,
            windowName = 1,
            x_pos = 2,
            y_pos = 3,
            width = 4,
            height = 5,
            is_minimized = 6,
            is_maximized = 7,
        }

        public string errorMessage { get; private set; }
        public int error { get; private set; }

        private WindowAction executedAction;
        private MacroProperty[] properties = new MacroProperty[]
        {
            /*new MacroProperty()
            {
                name = WindowProperties.window.ToString(),
                id = (int)WindowProperties.window,
                type = PropertyType.integer,
                value = 0,
                readOnly = false,
                customOptions = () => { return Process.GetProcesses().Distinct(new ProcessMainHandlerComparer()).ToArray(); },
            },*/
            new MacroProperty()
            {
                name = WindowProperties.pid.ToString(),
                id = (int)WindowProperties.pid,
                type = PropertyType.integer,
                value = 0,
                readOnly = false,
            },
            new MacroProperty()
            {
                name = WindowProperties.windowName.ToString(),
                id = (int)WindowProperties.windowName,
                type = PropertyType.stringed_value,
                value = string.Empty,
                readOnly = false,
            },
            new MacroProperty()
            {
                name = WindowProperties.x_pos.ToString(),
                id = (int)WindowProperties.x_pos,
                type = PropertyType.integer,
                value = 0,
                readOnly = false,
            },
            new MacroProperty()
            {
                name = WindowProperties.y_pos.ToString(),
                id = (int)WindowProperties.y_pos,
                type = PropertyType.integer,
                value = 0,
                readOnly = false,
            },
                        new MacroProperty()
            {
                name = WindowProperties.width.ToString(),
                id = (int)WindowProperties.width,
                type = PropertyType.integer,
                value = 0,
                readOnly = false,
            },
            new MacroProperty()
            {
                name = WindowProperties.height.ToString(),
                id = (int)WindowProperties.height,
                type = PropertyType.integer,
                value = 0,
                readOnly = false,
            },
            new MacroProperty()
            {
                name = WindowProperties.is_maximized.ToString(),
                id = (int)WindowProperties.is_maximized,
                type = PropertyType.boolean,
                value = 0,
                readOnly = true,
            },
            new MacroProperty()
            {
                name = WindowProperties.is_minimized.ToString(),
                id = (int)WindowProperties.is_minimized,
                type = PropertyType.boolean,
                value = 0,
                readOnly = true,
            },
        };

        public WindowMacro() : base() { }
        public WindowMacro(MacroType other) : base(other) { }

        public override Array GetProperties()
        {
            return Enum.GetValues(typeof(WindowProperties));
        }
        public override Array GetShownProperties()
        {
            var allProperties = (WindowProperties[])Enum.GetValues(typeof(WindowProperties));
            List<WindowProperties> shownProperties = new List<WindowProperties>();
            for (int i = 0; i < allProperties.Length; i++)
            {
                if (!GetProperty((int)allProperties[i]).readOnly)
                    shownProperties.Add(allProperties[i]);
            }
            return shownProperties.ToArray();
        }
        public override Array GetActions()
        {
            return Enum.GetValues(typeof(WindowAction));
        }
        public override void SetAction(int actionId)
        {
            executedAction = (WindowAction)actionId;
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
                string processName = (string)GetProperty((int)WindowProperties.windowName).value;
                Process target;
                if (!string.IsNullOrEmpty(processName))
                    target = Process.GetProcesses().First(process => process.ProcessName.ToLower().Contains((processName).ToLower()));
                else
                    target = Process.GetProcesses().First(process => process.Id == (int)GetProperty((int)WindowProperties.pid).value);
                
                switch (executedAction)
                {
                    case WindowAction.bring_to_front:
                        WindowOperations.BringToFront(target.MainWindowHandle);
                        break;
                    case WindowAction.maximize:
                        WindowOperations.ShowMaximized(target.MainWindowHandle);
                        break;
                    case WindowAction.minimize:
                        WindowOperations.Minimize(target.MainWindowHandle);
                        break;
                    case WindowAction.set_pos:
                        WindowOperations.SetPos(target.MainWindowHandle, (int)GetProperty((int)WindowProperties.x_pos).value, (int)GetProperty((int)WindowProperties.y_pos).value);
                        break;
                    case WindowAction.set_size:
                        WindowOperations.SetSize(target.MainWindowHandle, (int)GetProperty((int)WindowProperties.width).value, (int)GetProperty((int)WindowProperties.height).value);
                        break;
                    case WindowAction.unmaximize:
                        WindowOperations.ShowNormal(target.MainWindowHandle);
                        break;
                    case WindowAction.unminimize:
                        WindowOperations.Unminimize(target.MainWindowHandle);
                        break;
                    case WindowAction.get_maximized:
                        SetPropertyValue((int)WindowProperties.is_maximized, WindowOperations.IsMaximized(target.MainWindowHandle) ? 1 : 0);
                        break;
                    case WindowAction.get_minimized:
                        SetPropertyValue((int)WindowProperties.is_minimized, WindowOperations.IsMinimized(target.MainWindowHandle) ? 1 : 0);
                        break;
                    case WindowAction.get_pos:
                        var pos = WindowOperations.GetPlacement(target.MainWindowHandle);
                        SetPropertyValue((int)WindowProperties.x_pos, pos.rcNormalPosition.X);
                        SetPropertyValue((int)WindowProperties.y_pos, pos.rcNormalPosition.Y);
                        break;
                    case WindowAction.get_size:
                        var size = WindowOperations.GetPlacement(target.MainWindowHandle);
                        SetPropertyValue((int)WindowProperties.width, size.rcNormalPosition.Width);
                        SetPropertyValue((int)WindowProperties.height, size.rcNormalPosition.Height);
                        break;
                }
            }
            catch (Exception e) { error = 1; errorMessage = e.ToString(); }

            return Task.FromResult(error);
        }

        /*private class ProcessMainHandlerComparer : IEqualityComparer<Process>
        {
            public bool Equals(Process x, Process y)
            {
                return x.MainWindowHandle == y.MainWindowHandle;
            }

            public int GetHashCode(Process obj)
            {
                return obj.MainWindowHandle.GetHashCode();
            }
        }*/
    }
}
