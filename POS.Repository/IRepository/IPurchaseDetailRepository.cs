using POS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.IRepository.IRepository
{
    public interface IPurchaseDetailRepository : IDisposable
    {
		void Delete(PurchaseDetail aside);
		void Delete(int id);
		IEnumerable<PurchaseDetail> GetAll();
		PurchaseDetail GetById(int id);
		int Insert(PurchaseDetail aside);
		void Update(PurchaseDetail aside);



		Task<IEnumerable<PurchaseDetail>> GetAllAsync();
		Task<PurchaseDetail> GetByIdAsync(int id);
		Task<int> InsertAsync(PurchaseDetail aside);
		Task UpdateAsync(PurchaseDetail aside);
	}
}
