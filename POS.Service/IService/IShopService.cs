using POS.ViewModel.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service.IService
{
    public interface IShopService 
    {
		Task<IEnumerable<ShopViewModel>> GetAll();
		Task<ShopViewModel> GetById(int id);
		Task<int> Insert(ShopViewModel viewModel);
		Task Update(ShopViewModel viewModel);
		Task Delete(ShopViewModel viewModel);
		Task Delete(int id);
	}
}
