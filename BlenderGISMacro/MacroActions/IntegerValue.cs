using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MacroMan.MacroActions
{
    public struct IntegerValue : INotifyPropertyChanged
    {
        public int value { get { return _value; } set { set = true; _value = value; NotifyPropertyChanged(); } }
        private int _value;
        public string name { get { return _name; } set { set = true; _name = value; NotifyPropertyChanged(); } }
        private string _name;

        internal bool set { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;
        // This method is called by the Set accessor of each property.
        // The CallerMemberName attribute that is applied to the optional propertyName
        // parameter causes the property name of the caller to be substituted as an argument.
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
