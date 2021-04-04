using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ViewModel.Product
{
    public class ProductDTO
    {
		public static POS.Data.Product ConvertToEntity(ProductViewModel viewModel)
		{
			if (viewModel == null)
				return null;

			return new POS.Data.Product
			{
				Id = viewModel.Id,

				Name = viewModel.Name,
				Code = viewModel.Code,
				CategoryId = viewModel.CategoryId,
				SubCategoryId = viewModel.SubCategoryId,
				BrandId = viewModel.BrandId,
				OpeningStock = viewModel.OpeningStock,
				Price = viewModel.Price,
				Cost = viewModel.Cost,
				Description = viewModel.Description,
				Image = viewModel.Image,
				Stock = viewModel.Stock,
				ShopId = viewModel.ShopId,

				DateCreated = viewModel.DateCreated ?? DateTime.Now,
				DateUpdated = viewModel.DateUpdated ?? DateTime.Now,
				CreatedByUserId = viewModel.CreatedByUserId,
				UpdatedByUserId = viewModel.UpdatedByUserId,
				IsActive = viewModel.IsActive
			};
		}

		public static ProductViewModel ConvertToViewModel(POS.Data.Product dataEntity)
		{
			if (dataEntity == null)
				return null;

			return new ProductViewModel
			{
				Id = dataEntity.Id,

				Name = dataEntity.Name,
				Code = dataEntity.Code,
				CategoryId = dataEntity.CategoryId,
				SubCategoryId = dataEntity.SubCategoryId,
				BrandId = dataEntity.BrandId,
				OpeningStock = dataEntity.OpeningStock,
				Price = dataEntity.Price,
				Cost = dataEntity.Cost,
				Description = dataEntity.Description,
				Image = dataEntity.Image,
				Stock = dataEntity.Stock,
				ShopId = dataEntity.ShopId,

				DateCreated = dataEntity.DateCreated,
				DateUpdated = dataEntity.DateUpdated,
				CreatedByUserId = dataEntity.CreatedByUserId,
				UpdatedByUserId = dataEntity.UpdatedByUserId,
				IsActive = dataEntity.IsActive

	};
		}

		public static IEnumerable<ProductViewModel> ConvertToViewModelList(IEnumerable<POS.Data.Product> dataEntityList)
		{
			if (dataEntityList == null)
				yield break;

			foreach (var item in dataEntityList)
			{
				yield return ConvertToViewModel(item);
			}
		}
	}
}
