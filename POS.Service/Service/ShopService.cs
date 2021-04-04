using POS.IRepository.IRepository;
using POS.Service.IService;
using POS.ViewModel.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service.Service
{
    public class ShopService : IShopService
    {
        private readonly IShopRepository _shopRepository;
        public ShopService() { }
        public ShopService(IShopRepository shopRepository)
        {
            this._shopRepository = shopRepository;
        }

        public async Task Delete(ShopViewModel viewModel)
        {
            this._shopRepository.Delete(ShopDTO.ConvertToEntity(viewModel));
            await Task.FromResult(0);
        }

        public async Task Delete(int id)
        {
            this._shopRepository.Delete(id);
            await Task.FromResult(id);
        }

        public async Task<IEnumerable<ShopViewModel>> GetAll()
        {
            return ShopDTO.ConvertToViewModelList(await this._shopRepository.GetAllAsync());
        }

        public async Task<ShopViewModel> GetById(int id)
        {
            return ShopDTO.ConvertToViewModel(await this._shopRepository.GetByIdAsync(id));
        }

        public async Task<int> Insert(ShopViewModel viewModel)
        {
            int id = 0;
            try
            {
                id = await this._shopRepository.InsertAsync(ShopDTO.ConvertToEntity(viewModel));
                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Update(ShopViewModel viewModel)
        {
            try
            {
                await this._shopRepository.UpdateAsync(ShopDTO.ConvertToEntity(viewModel));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
