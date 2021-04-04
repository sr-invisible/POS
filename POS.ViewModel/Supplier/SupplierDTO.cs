using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ViewModel.Supplier
{
    public class SupplierDTO
    {
		public static POS.Data.Supplier ConvertToEntity(SupplierViewModel viewModel)
		{
			if (viewModel == null)
				return null;

			return new POS.Data.Supplier
			{
				Id = viewModel.Id,

				Name = viewModel.Name,
				Phone = viewModel.Phone,
				Email = viewModel.Email,
				Address = viewModel.Address,

				DateCreated = viewModel.DateCreated ?? DateTime.Now,
				DateUpdated = viewModel.DateUpdated ?? DateTime.Now,
				CreatedByUserId = viewModel.CreatedByUserId,
				UpdatedByUserId = viewModel.UpdatedByUserId,
				IsActive = viewModel.IsActive
			};
		}

		public static SupplierViewModel ConvertToViewModel(POS.Data.Supplier dataEntity)
		{
			if (dataEntity == null)
				return null;

			return new SupplierViewModel
			{
				Id = dataEntity.Id,

				Name = dataEntity.Name,
				Phone = dataEntity.Phone,
				Email  = dataEntity.Email,
				Address = dataEntity.Address,

				DateCreated = dataEntity.DateCreated,
				DateUpdated = dataEntity.DateUpdated,
				CreatedByUserId = dataEntity.CreatedByUserId,
				UpdatedByUserId = dataEntity.UpdatedByUserId,
				IsActive = dataEntity.IsActive

			};
		}

		public static IEnumerable<SupplierViewModel> ConvertToViewModelList(IEnumerable<POS.Data.Supplier> dataEntityList)
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
