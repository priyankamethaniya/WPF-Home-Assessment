using CustomerManagement.Commands;
using CustomerManagement.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace CustomerManagement.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly ICollectionView _customersView;

        private string _searchText = string.Empty;
        private string _statusFilter = "All";

        public ObservableCollection<Customer> Customers { get; }

        public ICollectionView CustomersView => _customersView;

        public IReadOnlyList<string> StatusOptions { get; } = new[] { "All", "Active", "Inactive" };

        public ICommand AddCommand { get; }

        public ICommand EditCommand { get; }

        public ICommand DeleteCommand { get; }

        public string SearchText
        {
            get => _searchText;
            set
            {
                if (_searchText == value)
                    return;

                _searchText = value;
                OnPropertyChanged();
                _customersView.Refresh();
                OnPropertyChanged(nameof(HasResults));
            }
        }

        public string StatusFilter
        {
            get => _statusFilter;
            set
            {
                if (_statusFilter == value)
                    return;

                _statusFilter = value;
                OnPropertyChanged();
                _customersView.Refresh();
                OnPropertyChanged(nameof(HasResults));
            }
        }

        public bool HasResults => _customersView.Cast<object>().Any();

        public MainViewModel()
        {
            Customers = new ObservableCollection<Customer>
            {
                new Customer
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Smith",
                    Email = "john.smith@example.com",
                    Phone = "555-0101",
                    Status = "Active"
                },

                new Customer
                {
                    Id = 2,
                    FirstName = "Sarah",
                    LastName = "Johnson",
                    Email = "sarah.johnson@example.com",
                    Phone = "555-0102",
                    Status = "Active"
                },

                new Customer
                {
                    Id = 3,
                    FirstName = "Michael",
                    LastName = "Brown",
                    Email = "michael.brown@example.com",
                    Phone = "555-0103",
                    Status = "Inactive"
                }
            };

            _customersView = CollectionViewSource.GetDefaultView(Customers);
            _customersView.Filter = FilterCustomer;

            AddCommand = new RelayCommand(_ => AddCustomer());

            EditCommand = new RelayCommand(
                parameter => EditCustomer(parameter as Customer),
                parameter => parameter is Customer);

            DeleteCommand = new RelayCommand(
                parameter => DeleteCustomer(parameter as Customer),
                parameter => parameter is Customer);
        }

        private bool FilterCustomer(object item)
        {
            if (item is not Customer customer)
                return false;

            bool matchesStatus = StatusFilter == "All" || customer.Status == StatusFilter;

            bool matchesSearch = string.IsNullOrWhiteSpace(SearchText)
                || Matches(customer.FirstName, SearchText)
                || Matches(customer.LastName, SearchText)
                || Matches(customer.Email, SearchText);

            return matchesStatus && matchesSearch;
        }

        private static bool Matches(string value, string searchText) =>
            value.Contains(searchText, System.StringComparison.OrdinalIgnoreCase);

        private void AddCustomer()
        {
            var formViewModel = new CustomerFormViewModel();

            if (ShowCustomerForm(formViewModel))
            {
                var newCustomer = formViewModel.ToCustomer();
                newCustomer.Id = GetNextId();

                Customers.Add(newCustomer);
                OnPropertyChanged(nameof(HasResults));
            }
        }

        private void EditCustomer(Customer? customer)
        {
            if (customer == null)
                return;

            var formViewModel = new CustomerFormViewModel(customer);

            if (ShowCustomerForm(formViewModel))
            {
                customer.FirstName = formViewModel.FirstName.Trim();
                customer.LastName = formViewModel.LastName.Trim();
                customer.Email = formViewModel.Email.Trim();
                customer.Phone = formViewModel.Phone.Trim();
                customer.Status = formViewModel.Status;

                _customersView.Refresh();
            }
        }

        private void DeleteCustomer(Customer? customer)
        {
            if (customer == null)
                return;

            var result = MessageBox.Show(
                $"Are you sure you want to delete {customer.FirstName} {customer.LastName}?",
                "Confirm Delete",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (result != MessageBoxResult.Yes)
                return;

            Customers.Remove(customer);
            OnPropertyChanged(nameof(HasResults));
        }

        private static bool ShowCustomerForm(CustomerFormViewModel formViewModel)
        {
            var window = new Views.CustomerWindow
            {
                DataContext = formViewModel,
                Owner = Application.Current.MainWindow
            };

            return window.ShowDialog() == true;
        }

        private int GetNextId()
        {
            if (Customers.Count == 0)
                return 1;

            return Customers.Max(x => x.Id) + 1;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
