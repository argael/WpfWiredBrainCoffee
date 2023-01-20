using System.Windows;
using System.Windows.Controls;
using WiredBrainCoffee.CustomersApp.Services.DataProviders;
using WiredBrainCoffee.CustomersApp.ViewModels;

namespace WiredBrainCoffee.CustomersApp.Views
{
	/// <summary>
	/// Class with the "Code Behind" for the XAML View.
	/// </summary>
	/// <remarks>
	/// This code drive the view behaviour, not the data
	/// </remarks>
	public partial class CustomersView : UserControl
    {
		private CustomersViewModel _viewModel;

		public CustomersView()
        {
            InitializeComponent();

			_viewModel = new CustomersViewModel(new CustomerDataProvider());
			DataContext = _viewModel;

			Loaded += OnLoadedCustomersView; // Add an event handler to the "Loaded" event on the view
        }

		/// <summary>
		/// Event Handler - Triggered When the view is loaded, it will load the customer from the ViewModel
		/// </summary>
		private async void OnLoadedCustomersView(object sender, RoutedEventArgs e)
		{
			await _viewModel.LoadAsync();
		}

		/// <summary>
		/// Event Handler - Move the "Customer List" col on Left/Right
		/// </summary>
		private void OnClickMove(object sender, RoutedEventArgs e)
		{
			//int finalCol = MainGrid.ColumnDefinitions.Count - 1;
			//Grid.SetColumn(CustomerList, Grid.GetColumn(CustomerList) > 0 ? 0 : finalCol);

			_viewModel.MoveNavigation();
		}

		private void OnCustomerAdd(object sender, RoutedEventArgs e)
		{
			_viewModel.Add();
		}
	}
}
