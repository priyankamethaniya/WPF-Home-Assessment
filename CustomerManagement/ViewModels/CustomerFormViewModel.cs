using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.ViewModels
{
    public class CustomerFormViewModel : INotifyPropertyChanged
    {
        private string _firstName = string.Empty;
        private string _lastName = string.Empty;
        private string _email = string.Empty;
        private string _phone = string.Empty;
        private string _status = "Active";

        public string FirstName
        {
            get => _firstName;
            set
            {
                if (_firstName == value)
                    return;

                _firstName = value;
                OnPropertyChanged();
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                if (_lastName == value)
                    return;

                _lastName = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                if (_email == value)
                    return;

                _email = value;
                OnPropertyChanged();
            }
        }

        public string Phone
        {
            get => _phone;
            set
            {
                if (_phone == value)
                    return;

                _phone = value;
                OnPropertyChanged();
            }
        }

        public string Status
        {
            get => _status;
            set
            {
                if (_status == value)
                    return;

                _status = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(
            [CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(propertyName));
        }
    }
}
