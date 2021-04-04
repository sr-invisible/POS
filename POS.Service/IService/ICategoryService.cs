using POS.ViewModel.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service.IService
{
    public interface ICategoryService
    {
		Task<IEnumerable<CategoryViewModel>> GetAll();
		Task<CategoryViewModel> GetById(int id);
		Task<int> Insert(CategoryViewModel viewModel);
		Task Update(CategoryViewModel viewModel);
		Task Delete(CategoryViewModel viewModel);
		Task Delete(int id);
	}
}
