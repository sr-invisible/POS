using POS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.IRepository.IRepository
{
    public interface IStockRepository : IDisposable
    {
		void Delete(Stock stock);
		void Delete(int id);
		IEnumerable<Stock> GetAll();
		Stock GetById(int id);
		int Insert(Stock stock);
		void Update(Stock stock);



		Task<IEnumerable<Stock>> GetAllAsync();
		Task<Stock> GetByIdAsync(int id);
		Task<int> InsertAsync(Stock stock);
		Task UpdateAsync(Stock stock);
	}
}
