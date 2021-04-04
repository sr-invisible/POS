using POS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.IRepository.IRepository
{
    public interface ISupplierRepository : IDisposable
    {
		void Delete(Supplier supplier);
		void Delete(int id);
		IEnumerable<Supplier> GetAll();
		Supplier GetById(int id);
		int Insert(Supplier supplier);
		void Update(Supplier supplier);



		Task<IEnumerable<Supplier>> GetAllAsync();
		Task<Supplier> GetByIdAsync(int id);
		Task<int> InsertAsync(Supplier supplier);
		Task UpdateAsync(Supplier supplier);
	}
}
