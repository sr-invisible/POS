using POS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.IRepository.IRepository
{
    public interface ICustomerRepository : IDisposable
    {
		void Delete(Customer customer);
		void Delete(int id);
		IEnumerable<Customer> GetAll();
		Customer GetById(int id);
		int Insert(Customer customer);
		void Update(Customer customer);



		Task<IEnumerable<Customer>> GetAllAsync();
		Task<Customer> GetByIdAsync(int id);
		Task<int> InsertAsync(Customer customer);
		Task UpdateAsync(Customer customer);
	}
}
