using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CustomerManagement.Models
{
    public class Customer : INotifyPropertyChanged
    {
        private string _firstName = string.Empty;
        private string _lastName = string.Empty;
        private string _email = string.Empty;
        private string _phone = string.Empty;
        private string _status = "Active";

        public int Id { get; set; }

        public string FirstName
        {
            get => _firstName;
            set => SetField(ref _firstName, value);
        }

        public string LastName
        {
            get => _lastName;
            set => SetField(ref _lastName, value);
        }

        public string Email
        {
            get => _email;
            set => SetField(ref _email, value);
        }

        public string Phone
        {
            get => _phone;
            set => SetField(ref _phone, value);
        }

        public string Status
        {
            get => _status;
            set => SetField(ref _status, value);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void SetField(ref string field, string value, [CallerMemberName] string? propertyName = null)
        {
            if (field == value)
                return;

            field = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
