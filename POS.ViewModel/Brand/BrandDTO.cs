using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ViewModel.Brand
{
    public class BrandDTO
    {
		public static POS.Data.Brand ConvertToEntity(BrandViewModel viewModel)
		{
			if (viewModel == null)
				return null;

			return new POS.Data.Brand
			{
				Id = viewModel.Id,

				Name = viewModel.Name,
				Description = viewModel.Description,
        		ImagePath = viewModel.ImagePath,

				DateCreated = viewModel.DateCreated ?? DateTime.Now,
				DateUpdated = viewModel.DateUpdated ?? DateTime.Now,
				CreatedByUserId = viewModel.CreatedByUserId,
				UpdatedByUserId = viewModel.UpdatedByUserId,
				IsActive = viewModel.IsActive
			};
		}

		public static BrandViewModel ConvertToViewModel(POS.Data.Brand dataEntity)
		{
			if (dataEntity == null)
				return null;

			return new BrandViewModel
			{
				Id = dataEntity.Id,

				Name = dataEntity.Name,
				Description = dataEntity.Description,
        		ImagePath = dataEntity.ImagePath,

				DateCreated = dataEntity.DateCreated,
				DateUpdated = dataEntity.DateUpdated,
				CreatedByUserId = dataEntity.CreatedByUserId,
				UpdatedByUserId = dataEntity.UpdatedByUserId,
				IsActive = dataEntity.IsActive

			};
		}

		public static IEnumerable<BrandViewModel> ConvertToViewModelList(IEnumerable<POS.Data.Brand> dataEntityList)
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
