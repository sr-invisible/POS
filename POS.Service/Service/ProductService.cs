using POS.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.IRepository.IRepository;
using POS.ViewModel.Product;

namespace POS.Service.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }
        public ProductService()
        {

        }
        public void Delete(ProductViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductViewModel> GetAll()
        {
            return ProductDTO.ConvertToViewModelList(this._productRepository.GetAll());
        }

        public Task<IEnumerable<ProductViewModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public ProductViewModel GetById(int id)
        {
            return ProductDTO.ConvertToViewModel(this._productRepository.GetById(id));
        }

        public Task<ProductViewModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(ProductViewModel viewModel)
        {
            int id = 0;
            try
            {
                id = this._productRepository.Insert(ProductDTO.ConvertToEntity(viewModel));
                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(ProductViewModel viewModel)
        {
            throw new NotImplementedException();
        }

       
    }
}
