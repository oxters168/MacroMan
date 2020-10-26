using System.Threading.Tasks;

namespace MacroMan.MacroActions
{
    public class MacroExecutor
    {
        private MacroType action;
        //We need a condition type

        public async Task<bool> Execute()
        {
            //Over here there will be an optional conditional
            await action.Execute();
            return true; //This value will be dependant on an optional condition that the user has set which will sway what will be executed next
        }
    }
}
