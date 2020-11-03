using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MacroMan.MacroActions
{
    public class TimeMacro : MacroType
    {
        /// <summary>
        /// This enum is used to identify the action this macro will do
        /// We can create an array of actions if we want for this enum,
        /// but I don't see why I would do that than just manually call the actions
        /// </summary>
        private enum TimeAction
        {
            wait = 0,
        }
        /// <summary>
        /// This enum is used to identify and retrieve the variables stored within this
        /// macro. The variables can be found in the properties array.
        /// </summary>
        private enum TimeProperties
        {
            milliseconds = 0,
        }

        public string errorMessage { get; private set; }
        public int error { get; private set; }

        private TimeAction executedAction;
        private MacroProperty[] properties = new MacroProperty[]
        {
            new MacroProperty()
            {
                name = TimeProperties.milliseconds.ToString(),
                id = (int)TimeProperties.milliseconds,
                type = PropertyType.integer,
                value = 0,
                readOnly = false,
            },
        };

        public TimeMacro() : base() { }
        public TimeMacro(MacroType other) : base(other) { }

        public override Array GetProperties()
        {
            return Enum.GetValues(typeof(TimeProperties));
        }
        public override Array GetShownProperties()
        {
            var allProperties = (TimeProperties[])Enum.GetValues(typeof(TimeProperties));
            List<TimeProperties> shownProperties = new List<TimeProperties>();
            for (int i = 0; i < allProperties.Length; i++)
            {
                if (!GetProperty((int)allProperties[i]).readOnly)
                    shownProperties.Add(allProperties[i]);
            }
            return shownProperties.ToArray();
        }
        public override Array GetActions()
        {
            return Enum.GetValues(typeof(TimeAction));
        }
        public override void SetAction(int actionId)
        {
            executedAction = (TimeAction)actionId;
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
        public async override Task<int> Execute(System.Threading.CancellationToken cancelToken)
        {
            error = 0;
            errorMessage = null;
            try
            {
                switch (executedAction)
                {
                    case TimeAction.wait:
                        await Task.Delay((int)GetProperty((int)TimeProperties.milliseconds).value, cancelToken);
                        break;
                }
            }
            catch (Exception e) { error = 1; errorMessage = e.ToString(); }

            return error;
        }
    }
}
