using System.Collections.Generic;
using System.Threading.Tasks;
using WiredBrainCoffee.CustomersApp.Models;

namespace WiredBrainCoffee.CustomersApp.Services.DataProviders
{
	public interface ICustomerDataProvider
    {
        Task<IEnumerable<Customer>?> GetAllAsync();
    }
	
	/// <summary>
	/// Class use to interact with Model data (From DB or API)
	/// </summary>
	class CustomerDataProvider : ICustomerDataProvider
	{
		/// <summary>
		/// Get all the Customers
		/// </summary>
		public async Task<IEnumerable<Customer>?> GetAllAsync()
		{
			await Task.Delay(100);

			return new List<Customer>
			{
				new Customer{ Id = 1, FirstName="John", LastName="Doe", IsDeveloper=true },
				new Customer{ Id = 2, FirstName="Jane", LastName="Doe" },
				new Customer{ Id = 3, FirstName="Joe", LastName="Doe", IsDeveloper=true },
				new Customer{ Id = 4, FirstName="Alex", LastName="Rider" },
				new Customer{ Id = 5, FirstName="Sarha", LastName="Collins" },
				new Customer{ Id = 6, FirstName="Ben", LastName="Rice" },
			};
		}
	}
}
