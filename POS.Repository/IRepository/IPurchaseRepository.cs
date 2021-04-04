using POS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.IRepository.IRepository
{
    public interface IPurchaseRepository : IDisposable
    {
		void Delete(Purchase purchase);
		void Delete(int id);
		IEnumerable<Purchase> GetAll();
		Purchase GetById(int id);
		int Insert(Purchase purchase);
		void Update(Purchase purchase);



		Task<IEnumerable<Purchase>> GetAllAsync();
		Task<Purchase> GetByIdAsync(int id);
		Task<int> InsertAsync(Purchase purchase);
		Task UpdateAsync(Purchase purchase);
	}
}
