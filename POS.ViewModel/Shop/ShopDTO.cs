using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ViewModel.Shop
{
    public class ShopDTO
    {

		public static POS.Data.Shop ConvertToEntity(ShopViewModel viewModel)
		{
			if (viewModel == null)
				return null;

			return new POS.Data.Shop
			{
				Id = viewModel.Id,

				Name = viewModel.Name,
				Address = viewModel.Address, 
				Email = viewModel.Email,
				WebAddress = viewModel.WebAddress,
				Phone = viewModel.Phone,
				FinancialYearId = viewModel.FinancialYearId,

				DateCreated = viewModel.DateCreated ?? DateTime.Now,
				DateUpdated = viewModel.DateUpdated ?? DateTime.Now,
				CreatedByUserId = viewModel.CreatedByUserId,
				UpdatedByUserId = viewModel.UpdatedByUserId,
				IsActive = viewModel.IsActive
			};
		}

		public static ShopViewModel ConvertToViewModel(POS.Data.Shop dataEntity)
		{
			if (dataEntity == null)
				return null;

			return new ShopViewModel
			{
				Id = dataEntity.Id,

				Name = dataEntity.Name,
				Address = dataEntity.Address,
				Email = dataEntity.Email,
				WebAddress = dataEntity.WebAddress,
				Phone = dataEntity.Phone,
				FinancialYearId = dataEntity.FinancialYearId,

				DateCreated = dataEntity.DateCreated,
				DateUpdated = dataEntity.DateUpdated,
				CreatedByUserId = dataEntity.CreatedByUserId,
				UpdatedByUserId = dataEntity.UpdatedByUserId,
				IsActive = dataEntity.IsActive

			};
		}

		public static IEnumerable<ShopViewModel> ConvertToViewModelList(IEnumerable<POS.Data.Shop> dataEntityList)
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
