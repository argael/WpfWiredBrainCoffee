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
	public class CustomersViewModel : BaseViewModel
	{
		private readonly ICustomerDataProvider _customerDataProvider;

		/// <summary>
		/// The customer list
		/// </summary>
		/// <remarks>
		/// This collection reflect (by event) the content from the DataProvider
		/// </remarks>
		public ObservableCollection<CustomerItemViewModel> Customers { get; } = new();

		/// <summary>
		/// The Selected Item in the Customer List
		/// </summary>
		public CustomerItemViewModel? SelectedCustomer
		{
			get => _selectedCustomer;
			set { _selectedCustomer = value; RaisePropertyChanged(); }
		}
		private CustomerItemViewModel? _selectedCustomer;

		/// <summary>
		/// The column where place the "Navigation" panel
		/// </summary>
		public NavigationPosition NavigationPosition { get => _navigationPosition; private set { _navigationPosition = value; RaisePropertyChanged(); } }
		private NavigationPosition _navigationPosition;

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
				Customers.Add(new(customer));
		}

		// ==================================================================================================================

		internal void Add()
		{
			CustomerItemViewModel customer = new(new() { FirstName = "new" });
			Customers.Add(customer);
			SelectedCustomer = customer;
		}

		// ==================================================================================================================

		internal void MoveNavigation()
		{
			NavigationPosition = NavigationPosition == NavigationPosition.Left ? NavigationPosition.Right : NavigationPosition.Left;
		}
	}
}
