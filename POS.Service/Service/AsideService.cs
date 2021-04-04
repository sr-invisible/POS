using POS.Data;
using POS.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.IRepository.IRepository;
using POS.ViewModel.Aside;

namespace POS.Service.Service
{
    public class AsideService : IAsideService
    {

        private readonly IAsideRepository _asideRepository;
        public AsideService(IAsideRepository asideRepository)
        {
            this._asideRepository = asideRepository;
        }
        public AsideService()
        {

        }
        public void Delete(AsideViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AsideViewModel> GetAll()
        {
            return AsideDTO.ConvertToViewModelList(this._asideRepository.GetAll());
        }

        public Task<IEnumerable<AsideViewModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public AsideViewModel GetById(int id)
        {
            return AsideDTO.ConvertToViewModel(this._asideRepository.GetById(id));
        }

        public Task<AsideViewModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(AsideViewModel viewModel)
        {
            int id = 0;
            try
            {
                id = this._asideRepository.Insert(AsideDTO.ConvertToEntity(viewModel));
                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(AsideViewModel viewModel)
        {
            try
            {
                this._asideRepository.Update(AsideDTO.ConvertToEntity(viewModel));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<AsideViewModel> GetAllParentsByParentIdAndIsParent()
        {
            IList<AsideViewModel> ParentList = new List<AsideViewModel>();

            var Parents = AsideDTO.ConvertToViewModelList(this._asideRepository.GetAll());

            foreach (var item in Parents)
            {
                if (item.ParentId == 0 && item.IsParent == false)
                {
                    ParentList.Add(item);
                }
            }

            return ParentList;
        }
        public IEnumerable<AsideViewModel> GetUniqueOptionNameByArea(string optionName)
        {
            IList<AsideViewModel> ParentList = new List<AsideViewModel>();

            var Parents = AsideDTO.ConvertToViewModelList(this._asideRepository.GetAll());

            foreach (var item in Parents)
            {
                if (item.OptionName == optionName)
                {
                    ParentList.Add(item);
                }
            }

            return ParentList;
        }
    }
}
