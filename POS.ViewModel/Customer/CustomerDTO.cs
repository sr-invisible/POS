using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ViewModel.Customer
{
    public class CustomerDTO
    {

		public static POS.Data.Customer ConvertToEntity(CustomerViewModel viewModel)
		{
			if (viewModel == null)
				return null;

			return new POS.Data.Customer
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

		public static CustomerViewModel ConvertToViewModel(POS.Data.Customer dataEntity)
		{
			if (dataEntity == null)
				return null;

			return new CustomerViewModel
			{
				Id = dataEntity.Id,

				Name = dataEntity.Name,
				Phone = dataEntity.Phone,
        		Email = dataEntity.Email,
        		Address = dataEntity.Address,

				DateCreated = dataEntity.DateCreated,
				DateUpdated = dataEntity.DateUpdated,
				CreatedByUserId = dataEntity.CreatedByUserId,
				UpdatedByUserId = dataEntity.UpdatedByUserId,
				IsActive = dataEntity.IsActive

			};
		}

		public static IEnumerable<CustomerViewModel> ConvertToViewModelList(IEnumerable<POS.Data.Customer> dataEntityList)
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
