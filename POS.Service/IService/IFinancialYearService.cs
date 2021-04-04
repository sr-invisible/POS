using POS.ViewModel.FinancialYear;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service.IService
{
    public interface IFinancialYearService
    {
		Task<IEnumerable<FinancialYearViewModel>> GetAll();
		Task<FinancialYearViewModel> GetById(int id);
		Task<int> Insert(FinancialYearViewModel viewModel);
		Task Update(FinancialYearViewModel viewModel);
		Task Delete(FinancialYearViewModel viewModel);
		Task Delete(int id);
	}
}
