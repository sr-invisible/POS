using POS.ViewModel.SubCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service.IService
{
    public interface ISubCategoryService 
    {
		Task<IEnumerable<SubCategoryViewModel>> GetAll();
		Task<SubCategoryViewModel> GetById(int id);
		Task<int> Insert(SubCategoryViewModel viewModel);
		Task Update(SubCategoryViewModel viewModel);
		Task Delete(SubCategoryViewModel viewModel);
		Task Delete(int id);
	}
}
