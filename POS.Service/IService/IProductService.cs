using POS.ViewModel.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace POS.Service.IService
{
    public interface IProductService 
    {
		void Delete(ProductViewModel viewModel);
		void Delete(int id);
		IEnumerable<ProductViewModel> GetAll();
		ProductViewModel GetById(int id);
		int Insert(ProductViewModel viewModel);
		void Update(ProductViewModel viewModel);

		Task<IEnumerable<ProductViewModel>> GetAllAsync();
		Task<ProductViewModel> GetByIdAsync(int id);

	}
}
