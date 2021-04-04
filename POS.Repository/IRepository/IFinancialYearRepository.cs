using POS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.IRepository.IRepository
{
    public interface IFinancialYearRepository : IDisposable
    {
		void Delete(FinancialYear financialYear);
		void Delete(int id);
		IEnumerable<FinancialYear> GetAll();
		FinancialYear GetById(int id);
		int Insert(FinancialYear financialYear);
		void Update(FinancialYear financialYear);

		Task<IEnumerable<FinancialYear>> GetAllAsync();
		Task<FinancialYear> GetByIdAsync(int id);
		Task<int> InsertAsync(FinancialYear financialYear);
		Task UpdateAsync(FinancialYear financialYear);
	}
}
