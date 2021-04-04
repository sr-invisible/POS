using POS.ViewModel.Section;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service.IService
{
    public interface ISectionService 
    {
		void Delete(SectionViewModel viewModel);
		void Delete(int id);
		IEnumerable<SectionViewModel> GetAll();
		SectionViewModel GetById(int id);
		int Insert(SectionViewModel viewModel);
		void Update(SectionViewModel viewModel);

		Task<IEnumerable<SectionViewModel>> GetAllAsync();
		Task<SectionViewModel> GetByIdAsync(int id);
		//IEnumerable<SectionViewModel> GetAllParentsByParentIdAndIsParent();
	}
}
