using POS.ViewModel.Brand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service.IService
{
    public interface IBrandService 
    {
		Task<IEnumerable<BrandViewModel>> GetAll();
		Task<BrandViewModel> GetById(int id);
		Task<int> Insert(BrandViewModel viewModel);
		Task Update(BrandViewModel viewModel);
		Task Delete(BrandViewModel viewModel);
		Task Delete(int id);

		//Task<IEnumerable<BrandViewModel>> GetAllAsync();
		//Task<BrandViewModel> GetByIdAsync(int id);
	}
}
