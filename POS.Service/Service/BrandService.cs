using POS.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.ViewModel.Brand;
using POS.IRepository.IRepository;

namespace POS.Service.Service
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;
        public BrandService() { }
        public BrandService(IBrandRepository brandRepository)
        {
            this._brandRepository = brandRepository;
        }
        
        public async Task Delete(BrandViewModel viewModel)
        {
            this._brandRepository.Delete(BrandDTO.ConvertToEntity(viewModel));
            await Task.FromResult(0);
        }

        public async Task Delete(int id)
        {
            this._brandRepository.Delete(id);
            await Task.FromResult(id);
        }

        public async Task<IEnumerable<BrandViewModel>> GetAll()
        {
            return BrandDTO.ConvertToViewModelList(await this._brandRepository.GetAllAsync());
        }

        public async Task<BrandViewModel> GetById(int id)
        {
            return BrandDTO.ConvertToViewModel(await this._brandRepository.GetByIdAsync(id));
        }

        public async Task<int> Insert(BrandViewModel viewModel)
        {
            int id = 0;
            try
            {
                id = await this._brandRepository.InsertAsync(BrandDTO.ConvertToEntity(viewModel));
                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Update(BrandViewModel viewModel)
        {
            try
            {
                await this._brandRepository.UpdateAsync(BrandDTO.ConvertToEntity(viewModel));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
