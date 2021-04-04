using POS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.IRepository.IRepository
{
    public interface ISalesRepository : IDisposable
    {
		void Delete(Sales sales);
		void Delete(int id);
		IEnumerable<Sales> GetAll();
		Sales GetById(int id);
		int Insert(Sales sales);
		void Update(Sales sales);



		Task<IEnumerable<Sales>> GetAllAsync();
		Task<Sales> GetByIdAsync(int id);
		Task<int> InsertAsync(Sales sales);
		Task UpdateAsync(Sales sales);
	}
}
