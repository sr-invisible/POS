using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ViewModel.SalesDetail
{
    public class SalesDetailDTO
    {

		public static POS.Data.SalesDetail ConvertToEntity(SalesDetailViewModel viewModel)
		{
			if (viewModel == null)
				return null;

			return new POS.Data.SalesDetail
			{
				Id = viewModel.Id,

				SalesId = viewModel.SalesId, 
				ProductId = viewModel.ProductId,
				BarCode = viewModel.BarCode,
				Quantity = viewModel.Quantity, 
				SalesRate = viewModel.SalesRate,
				Vat = viewModel.Vat,
				LineDiscount = viewModel.LineDiscount,

				DateCreated = viewModel.DateCreated ?? DateTime.Now,
				DateUpdated = viewModel.DateUpdated ?? DateTime.Now,
				CreatedByUserId = viewModel.CreatedByUserId,
				UpdatedByUserId = viewModel.UpdatedByUserId,
				IsActive = viewModel.IsActive
			};
		}

		public static SalesDetailViewModel ConvertToViewModel(POS.Data.SalesDetail dataEntity)
		{
			if (dataEntity == null)
				return null;

			return new SalesDetailViewModel
			{
				Id = dataEntity.Id,

				SalesId = dataEntity.SalesId,
				ProductId = dataEntity.ProductId,
				BarCode = dataEntity.BarCode,
				Quantity = dataEntity.Quantity,
				SalesRate = dataEntity.SalesRate,
				Vat = dataEntity.Vat,
				LineDiscount = dataEntity.LineDiscount,

				DateCreated = dataEntity.DateCreated,
				DateUpdated = dataEntity.DateUpdated,
				CreatedByUserId = dataEntity.CreatedByUserId,
				UpdatedByUserId = dataEntity.UpdatedByUserId,
				IsActive = dataEntity.IsActive

			};
		}

		public static IEnumerable<SalesDetailViewModel> ConvertToViewModelList(IEnumerable<POS.Data.SalesDetail> dataEntityList)
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
