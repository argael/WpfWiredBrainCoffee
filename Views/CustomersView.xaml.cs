using System.Windows;
using System.Windows.Controls;

namespace WiredBrainCoffee.CustomersApp.Views
{
	public partial class CustomersView : UserControl
    {
        public CustomersView()
        {
            InitializeComponent();
        }

		/// <summary>
		/// Event - Move the "Customer List" col on Left/Right
		/// </summary>
		private void OnClickMove(object sender, RoutedEventArgs e)
		{
			int finalCol = MainGrid.ColumnDefinitions.Count - 1;
			Grid.SetColumn(CustomerList, Grid.GetColumn(CustomerList) > 0 ? 0 : finalCol);
		}
	}
}
