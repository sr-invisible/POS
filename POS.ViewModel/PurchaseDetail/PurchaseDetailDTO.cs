using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ViewModel.PurchaseDetail
{
    public class PurchaseDetailDTO
    {
        public static POS.Data.PurchaseDetail ConvertToEntity(PurchaseDetailViewModel viewModel)
		{
			if (viewModel == null)
				return null;

			return new POS.Data.PurchaseDetail
			{
				Id = viewModel.Id,

		        PurchaseId = viewModel.PurchaseId,
                ProductId = viewModel.ProductId,
                Name = viewModel.Name,
                BarCode = viewModel.BarCode,
                BarcodeImage = viewModel.BarcodeImage,
                ImageUrl = viewModel.ImageUrl,
                Quantity = viewModel.Quantity,
                StockQuantity = viewModel.StockQuantity,
				PurchaseRate = viewModel.PurchaseRate,
                SaleRate = viewModel.SaleRate,
                Vat = viewModel.Vat,
                Discount = viewModel.Discount,

				DateCreated = viewModel.DateCreated ?? DateTime.Now,
				DateUpdated = viewModel.DateUpdated ?? DateTime.Now,
				CreatedByUserId = viewModel.CreatedByUserId,
				UpdatedByUserId = viewModel.UpdatedByUserId,
				IsActive = viewModel.IsActive
			};
		}

		public static PurchaseDetailViewModel ConvertToViewModel(POS.Data.PurchaseDetail dataEntity)
		{
			if (dataEntity == null)
				return null;

			return new PurchaseDetailViewModel
			{
				Id = dataEntity.Id,

				PurchaseId = dataEntity.PurchaseId,
                ProductId = dataEntity.ProductId,
                Name = dataEntity.Name,
                BarCode = dataEntity.BarCode,
                BarcodeImage = dataEntity.BarcodeImage,
                ImageUrl = dataEntity.ImageUrl,
                Quantity = dataEntity.Quantity,
                StockQuantity = dataEntity.StockQuantity,
				PurchaseRate = dataEntity.PurchaseRate,
                SaleRate = dataEntity.SaleRate,
                Vat = dataEntity.Vat,
                Discount = dataEntity.Discount,

				DateCreated = dataEntity.DateCreated,
				DateUpdated = dataEntity.DateUpdated,
				CreatedByUserId = dataEntity.CreatedByUserId,
				UpdatedByUserId = dataEntity.UpdatedByUserId,
				IsActive = dataEntity.IsActive

			};
		}

		public static IEnumerable<PurchaseDetailViewModel> ConvertToViewModelList(IEnumerable<POS.Data.PurchaseDetail> dataEntityList)
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
