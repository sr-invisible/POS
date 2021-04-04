using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS.ViewModels.User
{
    public class UserDTO
    {

		public static POS.Models.ApplicationUser ConvertToEntity(UserViewModel viewModel)
		{
			if (viewModel == null)
				return null;

			return new POS.Models.ApplicationUser
			{
				Id = viewModel.Id,

				FirstName = viewModel.FirstName,
				LastName = viewModel.LastName,
				Email = viewModel.Email,
				PhoneNumber = viewModel.PhoneNumber,
				Status = viewModel.Status,

				DateCreated = viewModel.DateCreated,
				DateUpdated = viewModel.DateUpdated,

				IsActive = viewModel.IsActive
			};
		}

		public static UserViewModel ConvertToViewModel(POS.Models.ApplicationUser dataEntity)
		{
			if (dataEntity == null)
				return null;

			return new UserViewModel
			{
				Id = dataEntity.Id,

				FirstName = dataEntity.FirstName,
				LastName = dataEntity.LastName,
				Email = dataEntity.Email,
				PhoneNumber = dataEntity.PhoneNumber,
				Status = dataEntity.Status,

				DateCreated = dataEntity.DateCreated,
				DateUpdated = dataEntity.DateUpdated,
				IsActive = dataEntity.IsActive

			};
		}

		public static IEnumerable<UserViewModel> ConvertToViewModelList(IEnumerable<POS.Models.ApplicationUser> dataEntityList)
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