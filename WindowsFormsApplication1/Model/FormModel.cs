using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Model
{
    public class FormModel : INotifyPropertyChanged
    {
        private Person _person;

        public FormModel()
        {
            _person = new Person();
            _person.PropertyChanged += _person_PropertyChanged;
        }

        private void _person_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "Name")
            {
                CanSend = ((Person)sender).Name.Equals("Can");
            }
        }

        public Person Person
        {
            get { return _person; }
            set
            {
                if (value == _person) return;
                _person = value;
                NotifyPropertyChanged("Person");
            }
        }

        private bool _canSend;

        public bool CanSend
        {
            get
            {
                _canSend = Person.Valid;
                return _canSend;
            }
            set
            {
                if (value == _canSend) return;
                _canSend = value;
                NotifyPropertyChanged("CanSend");
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
