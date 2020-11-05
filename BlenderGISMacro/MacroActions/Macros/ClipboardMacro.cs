using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MacroMan.MacroActions
{
    [Serializable]
    public class ClipboardMacro : MacroType
    {
        /// <summary>
        /// This enum is used to identify the action this macro will do
        /// We can create an array of actions if we want for this enum,
        /// but I don't see why I would do that than just manually call the actions
        /// </summary>
        private enum ClipboardAction
        {
            copy = 0,
            cut = 1,
            paste = 2,
            clear = 3,
            contains_text = 4,
        }
        /// <summary>
        /// This enum is used to identify and retrieve the variables stored within this
        /// macro. The variables can be found in the properties array.
        /// </summary>
        private enum ClipboardProperties
        {
            dest_source = 0,
            value = 1,
            dest_source_macro_id = 2,
            dest_source_id = 3,
        }

        public string errorMessage { get; private set; }
        public int error { get; private set; }

        private ClipboardAction executedAction;
        private MacroProperty[] properties = new MacroProperty[]
        {
            new MacroProperty()
            {
                name = ClipboardProperties.dest_source.ToString(),
                id = (int)ClipboardProperties.dest_source,
                type = PropertyType.integer,
                value = DataSource.Self,
                readOnly = false,
                customOptions = () => { return Enum.GetValues(typeof(DataSource)); },
            },
            new MacroProperty()
            {
                name = ClipboardProperties.value.ToString(),
                id = (int)ClipboardProperties.value,
                type = PropertyType.stringed_value,
                value = string.Empty,
                readOnly = false,
            },
            new MacroProperty()
            {
                name = ClipboardProperties.dest_source_macro_id.ToString(),
                id = (int)ClipboardProperties.dest_source_macro_id,
                type = PropertyType.integer,
                value = -1,
                readOnly = false,
            },
            new MacroProperty()
            {
                name = ClipboardProperties.dest_source_id.ToString(),
                id = (int)ClipboardProperties.dest_source_id,
                type = PropertyType.dynamic,
                value = string.Empty,
                readOnly = false,
            },
        };

        public ClipboardMacro() : base() { }
        public ClipboardMacro(MacroType other) : base(other) { }

        public override Array GetProperties()
        {
            return Enum.GetValues(typeof(ClipboardProperties));
        }
        public override Array GetShownProperties()
        {
            var allProperties = (ClipboardProperties[])Enum.GetValues(typeof(ClipboardProperties));
            List<ClipboardProperties> shownProperties = new List<ClipboardProperties>();
            for (int i = 0; i < allProperties.Length; i++)
            {
                if (!GetProperty((int)allProperties[i]).readOnly)
                    shownProperties.Add(allProperties[i]);
            }
            return shownProperties.ToArray();
        }
        public override Array GetActions()
        {
            return Enum.GetValues(typeof(ClipboardAction));
        }
        public override void SetAction(int actionId)
        {
            executedAction = (ClipboardAction)actionId;
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
                var destSource = (DataSource)GetProperty((int)ClipboardProperties.dest_source).value;
                object destSourceId = GetProperty((int)ClipboardProperties.dest_source_id).value;
                int destSourceMacroId = (int)GetProperty((int)ClipboardProperties.dest_source_macro_id).value;

                MacroType destMacroSource = GetMacro(destSourceMacroId);
                switch (executedAction)
                {
                    case ClipboardAction.paste:
                        string value = string.Empty;
                        if ((destSource & DataSource.Self) != 0)
                            value = GetProperty((int)ClipboardProperties.value).value.ToString();
                        else if ((destSource & DataSource.Macro) != 0)
                            value = destMacroSource.GetProperty((int)destSourceId).value.ToString();
                        else if ((destSource & DataSource.Database) != 0)
                            value = ValuesDatabase.GetValue(destSourceId).ToString();

                        Clipboard.SetText(value);

                        KeyboardOperations.KeyDown(VirtualKey.LCONTROL);
                        KeyboardOperations.KeyPress(VirtualKey.V);
                        KeyboardOperations.KeyUp(VirtualKey.LCONTROL);
                        break;
                    case ClipboardAction.copy:
                        KeyboardOperations.KeyDown(VirtualKey.LCONTROL);
                        KeyboardOperations.KeyPress(VirtualKey.C);
                        KeyboardOperations.KeyUp(VirtualKey.LCONTROL);

                        string copiedText = Clipboard.GetText();

                        if ((destSource & DataSource.Self) != 0)
                            SetPropertyValue((int)ClipboardProperties.value, copiedText);
                        else if ((destSource & DataSource.Macro) != 0)
                            destMacroSource.SetPropertyValue((int)destSourceId, copiedText);
                        else if ((destSource & DataSource.Database) != 0)
                            ValuesDatabase.SetString(destSourceId, copiedText);
                        break;
                    case ClipboardAction.cut:
                        KeyboardOperations.KeyDown(VirtualKey.LCONTROL);
                        KeyboardOperations.KeyPress(VirtualKey.X);
                        KeyboardOperations.KeyUp(VirtualKey.LCONTROL);

                        string cutText = Clipboard.GetText();

                        if ((destSource & DataSource.Self) != 0)
                            SetPropertyValue((int)ClipboardProperties.value, cutText);
                        else if ((destSource & DataSource.Macro) != 0)
                            destMacroSource.SetPropertyValue((int)destSourceId, cutText);
                        else if ((destSource & DataSource.Database) != 0)
                            ValuesDatabase.SetString(destSourceId, cutText);
                        break;
                    case ClipboardAction.clear:
                        Clipboard.Clear();
                        break;
                    case ClipboardAction.contains_text:
                        bool containsText = Clipboard.ContainsText();

                        if ((destSource & DataSource.Self) != 0)
                            SetPropertyValue((int)ClipboardProperties.value, containsText ? 1 : 0);
                        else if ((destSource & DataSource.Macro) != 0)
                            destMacroSource.SetPropertyValue((int)destSourceId, containsText ? 1 : 0);
                        else if ((destSource & DataSource.Database) != 0)
                            ValuesDatabase.SetInteger(destSourceId, containsText ? 1 : 0);
                        break;
                }
            }
            catch (Exception e) { error = 1; errorMessage = e.ToString(); }

            return Task.FromResult(error);
        }
    }
}
