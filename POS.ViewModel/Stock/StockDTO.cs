using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ViewModel.Stock
{
    public class StockDTO
    {

		public static POS.Data.Stock ConvertToEntity(StockViewModel viewModel)
		{
			if (viewModel == null)
				return null;

			return new POS.Data.Stock
			{
				Id = viewModel.Id,

				Price= viewModel.Price,
				Sale = viewModel.Sale,
				Purchase = viewModel.Purchase,
				AvailableStock = viewModel.AvailableStock,
				SellValue = viewModel.SellValue,

				DateCreated = viewModel.DateCreated ?? DateTime.Now,
				DateUpdated = viewModel.DateUpdated ?? DateTime.Now,
				CreatedByUserId = viewModel.CreatedByUserId,
				UpdatedByUserId = viewModel.UpdatedByUserId,
				IsActive = viewModel.IsActive
			};
		}

		public static StockViewModel ConvertToViewModel(POS.Data.Stock dataEntity)
		{
			if (dataEntity == null)
				return null;

			return new StockViewModel
			{
				Id = dataEntity.Id,

				Price = dataEntity.Price,
				Sale = dataEntity.Sale,
				Purchase = dataEntity.Purchase,
				AvailableStock = dataEntity.AvailableStock,
				SellValue = dataEntity.SellValue,

				DateCreated = dataEntity.DateCreated,
				DateUpdated = dataEntity.DateUpdated,
				CreatedByUserId = dataEntity.CreatedByUserId,
				UpdatedByUserId = dataEntity.UpdatedByUserId,
				IsActive = dataEntity.IsActive

			};
		}

		public static IEnumerable<StockViewModel> ConvertToViewModelList(IEnumerable<POS.Data.Stock> dataEntityList)
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
