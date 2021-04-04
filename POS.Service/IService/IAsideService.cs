using POS.ViewModel.Aside;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service.IService
{
    public interface IAsideService
    {
		void Delete(AsideViewModel viewModel);
		void Delete(int id);
		IEnumerable<AsideViewModel> GetAll();
		AsideViewModel GetById(int id);
		int Insert(AsideViewModel viewModel);
		void Update(AsideViewModel viewModel);

		Task<IEnumerable<AsideViewModel>> GetAllAsync();
		Task<AsideViewModel> GetByIdAsync(int id);
        IEnumerable<AsideViewModel> GetAllParentsByParentIdAndIsParent();
    }
}
