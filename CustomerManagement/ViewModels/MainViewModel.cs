using CustomerManagement.Commands;
using CustomerManagement.Models;
using System;
using System.Windows;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CustomerManagement.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<Customer> Customers { get; }

        public ICommand AddCommand { get; }

        public ICommand DeleteCommand { get; }

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

            AddCommand = new RelayCommand(_ => AddCustomer());

            DeleteCommand = new RelayCommand(
                parameter => DeleteCustomer(parameter as Customer),
                parameter => parameter is Customer);
        }

        private void AddCustomer()
        {
            var formViewModel = new CustomerFormViewModel();

            var window = new Views.CustomerWindow
            {
                DataContext = formViewModel,
                Owner = Application.Current.MainWindow
            };

            if (window.ShowDialog() == true)
            {
                var newCustomer = new Customer
                {
                    Id = GetNextId(),
                    FirstName = formViewModel.FirstName,
                    LastName = formViewModel.LastName,
                    Email = formViewModel.Email,
                    Phone = formViewModel.Phone,
                    Status = formViewModel.Status
                };

                Customers.Add(newCustomer);
            }
        }

        private void DeleteCustomer(Customer? customer)
        {
            if (customer == null)
                return;

            Customers.Remove(customer);
        }

        private int GetNextId()
        {
            if (Customers.Count == 0)
                return 1;

            return Customers.Max(x => x.Id) + 1;
        }
    }
}
