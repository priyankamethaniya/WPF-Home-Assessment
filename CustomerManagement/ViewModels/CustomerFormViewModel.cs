using CustomerManagement.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace CustomerManagement.ViewModels
{
    public class CustomerFormViewModel : INotifyPropertyChanged
    {
        private static readonly Regex EmailRegex = new(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled);
        private static readonly Regex PhoneRegex = new(@"^[0-9+\-\s()]{7,20}$", RegexOptions.Compiled);

        private string _firstName = string.Empty;
        private string _lastName = string.Empty;
        private string _email = string.Empty;
        private string _phone = string.Empty;
        private string _status = "Active";

        private string _firstNameError = string.Empty;
        private string _lastNameError = string.Empty;
        private string _emailError = string.Empty;
        private string _phoneError = string.Empty;
        private string _statusError = string.Empty;
        private bool _isValid;

        public CustomerFormViewModel()
        {
            Validate();
        }

        public CustomerFormViewModel(Customer customer)
        {
            Id = customer.Id;
            _firstName = customer.FirstName;
            _lastName = customer.LastName;
            _email = customer.Email;
            _phone = customer.Phone;
            _status = customer.Status;
            Validate();
        }

        public int Id { get; }

        public bool IsEditMode => Id != 0;

        public IReadOnlyList<string> StatusOptions { get; } = new[] { "Active", "Inactive" };

        public string Title => IsEditMode ? "Edit Customer" : "Add Customer";

        public string FirstName
        {
            get => _firstName;
            set
            {
                if (_firstName == value)
                    return;

                _firstName = value;
                OnPropertyChanged();
                Validate();
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
                Validate();
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
                Validate();
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
                Validate();
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
                Validate();
            }
        }

        public string FirstNameError
        {
            get => _firstNameError;
            private set { if (_firstNameError != value) { _firstNameError = value; OnPropertyChanged(); } }
        }

        public string LastNameError
        {
            get => _lastNameError;
            private set { if (_lastNameError != value) { _lastNameError = value; OnPropertyChanged(); } }
        }

        public string EmailError
        {
            get => _emailError;
            private set { if (_emailError != value) { _emailError = value; OnPropertyChanged(); } }
        }

        public string PhoneError
        {
            get => _phoneError;
            private set { if (_phoneError != value) { _phoneError = value; OnPropertyChanged(); } }
        }

        public string StatusError
        {
            get => _statusError;
            private set { if (_statusError != value) { _statusError = value; OnPropertyChanged(); } }
        }

        public bool IsValid
        {
            get => _isValid;
            private set { if (_isValid != value) { _isValid = value; OnPropertyChanged(); } }
        }

        public Customer ToCustomer() => new()
        {
            Id = Id,
            FirstName = FirstName.Trim(),
            LastName = LastName.Trim(),
            Email = Email.Trim(),
            Phone = Phone.Trim(),
            Status = Status
        };

        private void Validate()
        {
            FirstNameError = string.IsNullOrWhiteSpace(FirstName)
                ? "First name is required."
                : string.Empty;

            LastNameError = string.IsNullOrWhiteSpace(LastName)
                ? "Last name is required."
                : string.Empty;

            if (string.IsNullOrWhiteSpace(Email))
                EmailError = "Email is required.";
            else if (!EmailRegex.IsMatch(Email))
                EmailError = "Enter a valid email address.";
            else
                EmailError = string.Empty;

            if (string.IsNullOrWhiteSpace(Phone))
                PhoneError = "Phone number is required.";
            else if (!PhoneRegex.IsMatch(Phone))
                PhoneError = "Enter a valid phone number.";
            else
                PhoneError = string.Empty;

            StatusError = string.IsNullOrWhiteSpace(Status)
                ? "Status is required."
                : string.Empty;

            IsValid = string.IsNullOrEmpty(FirstNameError)
                && string.IsNullOrEmpty(LastNameError)
                && string.IsNullOrEmpty(EmailError)
                && string.IsNullOrEmpty(PhoneError)
                && string.IsNullOrEmpty(StatusError);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(propertyName));
        }
    }
}
