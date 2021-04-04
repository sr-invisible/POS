using POS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.IRepository.IRepository
{
    public interface IProductRepository : IDisposable
	{
		void Delete(Product product);
		void Delete(int id);
		IEnumerable<Product> GetAll();
		Product GetById(int id);
		int Insert(Product product);
		void Update(Product product);

		Task<IEnumerable<Product>> GetAllAsync();
		Task<Product> GetByIdAsync(int id);
		Task<int> InsertAsync(Product product);
		Task UpdateAsync(Product product);
	}
}
