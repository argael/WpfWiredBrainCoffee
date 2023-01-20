using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using WiredBrainCoffee.CustomersApp.Models;
using WiredBrainCoffee.CustomersApp.Services.DataProviders;

namespace WiredBrainCoffee.CustomersApp.ViewModels
{
	/// <summary>
	/// Class used to bind the data from Models to the XAML View
	/// </summary>
	public class CustomersViewModel : INotifyPropertyChanged
	{
		private readonly ICustomerDataProvider _customerDataProvider;

		public event PropertyChangedEventHandler? PropertyChanged;

		/// <summary>
		/// This collection reflect (by event) the content from the DataProvider
		/// </summary>
		public ObservableCollection<Customer> Customers { get; } = new();

		private Customer? _selectedCustomer;
		public Customer? SelectedCustomer { 
			get => _selectedCustomer; 
			set { 
				_selectedCustomer = value;
				RaisePropertyChanged();
			} 
		}


		/// <summary>
		/// Constructor that use DI to register DataProvider
		/// </summary>
		public CustomersViewModel(ICustomerDataProvider customerDataProvider)
		{
			_customerDataProvider = customerDataProvider;
		}

		public async Task LoadAsync()
		{
			if (Customers.Any())
				return;

			IEnumerable<Customer>? customers = await _customerDataProvider.GetAllAsync();
			if (customers is null)
				return;

			foreach (Customer customer in customers)
			{
				Customers.Add(customer);
			}
		}

		internal void Add()
		{
			Customer customer = new() { FirstName = "new" };
			Customers.Add(customer);
			SelectedCustomer = customer;

			//RaisePropertyChanged(nameof(SelectedCustomer));
		}

		private void RaisePropertyChanged([CallerMemberName] string? propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
