using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ViewModel.RoleBaseMenuPermission
{
    public class RoleBaseMenuPermissionDTO
    {
		public static POS.Data.RoleBaseMenuPermission ConvertToEntity(RoleBaseMenuPermissionViewModel viewModel)
		{
			if (viewModel == null)
				return null;

			return new POS.Data.RoleBaseMenuPermission
			{
				Id = viewModel.Id,

				RoleId = viewModel.RoleId,
				AsideId = viewModel.AsideId,

				DateCreated = viewModel.DateCreated ?? DateTime.Now,
				DateUpdated = viewModel.DateUpdated ?? DateTime.Now,
				CreatedByUserId = viewModel.CreatedByUserId,
				UpdatedByUserId = viewModel.UpdatedByUserId,
				IsActive = viewModel.IsActive
			};
		}

		public static RoleBaseMenuPermissionViewModel ConvertToViewModel(POS.Data.RoleBaseMenuPermission dataEntity)
		{
			if (dataEntity == null)
				return null;

			return new RoleBaseMenuPermissionViewModel
			{
				Id = dataEntity.Id,

				RoleId = dataEntity.RoleId,
				AsideId = dataEntity.AsideId,

				DateCreated = dataEntity.DateCreated,
				DateUpdated = dataEntity.DateUpdated,
				CreatedByUserId = dataEntity.CreatedByUserId,
				UpdatedByUserId = dataEntity.UpdatedByUserId,
				IsActive = dataEntity.IsActive

			};
		}

		public static IEnumerable<RoleBaseMenuPermissionViewModel> ConvertToViewModelList(IEnumerable<POS.Data.RoleBaseMenuPermission> dataEntityList)
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
