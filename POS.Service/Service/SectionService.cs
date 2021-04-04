using POS.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.IRepository.IRepository;
using POS.ViewModel.Section;

namespace POS.Service.Service
{
    public class SectionService : ISectionService
    {

        private readonly ISectionRepository _sectionRepository;
        public SectionService(ISectionRepository sectionRepository)
        {
            this._sectionRepository = sectionRepository;
        }
        public SectionService()
        {

        }
        public void Delete(SectionViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SectionViewModel> GetAll()
        {
            return SectionDTO.ConvertToViewModelList(this._sectionRepository.GetAll());
        }

        public Task<IEnumerable<SectionViewModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public SectionViewModel GetById(int id)
        {
            return SectionDTO.ConvertToViewModel(this._sectionRepository.GetById(id));
        }

        public Task<SectionViewModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(SectionViewModel viewModel)
        {
            int id = 0;
            try
            {
                id = this._sectionRepository.Insert(SectionDTO.ConvertToEntity(viewModel));
                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(SectionViewModel viewModel)
        {
            try
            {
                this._sectionRepository.Update(SectionDTO.ConvertToEntity(viewModel));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public IEnumerable<SectionViewModel> GetAllParentsByParentIdAndIsParent()
        //{
        //    IList<SectionViewModel> ParentList = new List<SectionViewModel>();

        //    var Parents = SectionDTO.ConvertToViewModelList(this._p.GetAll());
        //    foreach (var item in Parents)
        //    {
        //        if (item. != true && item.parentId == 0)
        //        {
        //            ParentList.Add(item);
        //        }
        //    }

        //    return Parents;
        //}
    }
}
