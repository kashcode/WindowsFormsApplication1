using System;
using System.ComponentModel;

namespace WindowsFormsApplication1
{
    /// <summary>
    /// Persona
    /// </summary>
    public class Person : INotifyPropertyChanged
    {
        private string _name = string.Empty;
        public string Name {
            get
            {
                return _name;
            }
            set
            {
                if (value == _name) return;
                _name = value;
                Valid = _name == "Can";
                NotifyPropertyChanged("Name");
            }
        }

        private string _lastName = string.Empty;

        public string Lastname
        {
            get
            {
                return _lastName;
            }
            set
            {
                if (value == _lastName) return;
                _lastName = value;
                NotifyPropertyChanged("Lastname");
            }
        }

        private bool _valid;

        public bool Valid
        {
            get
            {
                return _valid;
            }
            set
            {
                if (value == _valid) return;
                _valid = value;
                NotifyPropertyChanged("Valid");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }
}
