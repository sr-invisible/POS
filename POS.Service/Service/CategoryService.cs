using POS.IRepository.IRepository;
using POS.Service.IService;
using POS.ViewModel.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService() { }
        public CategoryService(ICategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }

        public async Task Delete(CategoryViewModel viewModel)
        {
            this._categoryRepository.Delete(CategoryDTO.ConvertToEntity(viewModel));
            await Task.FromResult(0);
        }

        public async Task Delete(int id)
        {
            this._categoryRepository.Delete(id);
            await Task.FromResult(id);
        }

        public async Task<IEnumerable<CategoryViewModel>> GetAll()
        {
            return CategoryDTO.ConvertToViewModelList(await this._categoryRepository.GetAllAsync());
        }

        public async Task<CategoryViewModel> GetById(int id)
        {
            return CategoryDTO.ConvertToViewModel(await this._categoryRepository.GetByIdAsync(id));
        }

        public async Task<int> Insert(CategoryViewModel viewModel)
        {
            int id = 0;
            try
            {
                id = await this._categoryRepository.InsertAsync(CategoryDTO.ConvertToEntity(viewModel));
                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Update(CategoryViewModel viewModel)
        {
            try
            {
                await this._categoryRepository.UpdateAsync(CategoryDTO.ConvertToEntity(viewModel));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
