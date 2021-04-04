using POS.IRepository.IRepository;
using POS.Service.IService;
using POS.ViewModel.SubCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service.Service
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly ISubCategoryRepository _subCategoryRepository;
        public SubCategoryService() { }
        public SubCategoryService(ISubCategoryRepository subCategoryRepository)
        {
            this._subCategoryRepository = subCategoryRepository;
        }

        public async Task Delete(SubCategoryViewModel viewModel)
        {
            this._subCategoryRepository.Delete(SubCategoryDTO.ConvertToEntity(viewModel));
            await Task.FromResult(0);
        }

        public async Task Delete(int id)
        {
            this._subCategoryRepository.Delete(id);
            await Task.FromResult(id);
        }

        public async Task<IEnumerable<SubCategoryViewModel>> GetAll()
        {
            return SubCategoryDTO.ConvertToViewModelList(await this._subCategoryRepository.GetAllAsync());
        }

        public async Task<SubCategoryViewModel> GetById(int id)
        {
            return SubCategoryDTO.ConvertToViewModel(await this._subCategoryRepository.GetByIdAsync(id));
        }

        public async Task<int> Insert(SubCategoryViewModel viewModel)
        {
            int id = 0;
            try
            {
                id = await this._subCategoryRepository.InsertAsync(SubCategoryDTO.ConvertToEntity(viewModel));
                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Update(SubCategoryViewModel viewModel)
        {
            try
            {
                await this._subCategoryRepository.UpdateAsync(SubCategoryDTO.ConvertToEntity(viewModel));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
