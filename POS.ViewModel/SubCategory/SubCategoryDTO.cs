using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ViewModel.SubCategory
{
    public class SubCategoryDTO
    {

		public static POS.Data.SubCategory ConvertToEntity(SubCategoryViewModel viewModel)
		{
			if (viewModel == null)
				return null;

			return new POS.Data.SubCategory
			{
				Id = viewModel.Id,

				Name = viewModel.Name,
				Description = viewModel.Description,
				ImagePath = viewModel.ImagePath,
				CategoryId = viewModel.CategoryId,

				DateCreated = viewModel.DateCreated ?? DateTime.Now,
				DateUpdated = viewModel.DateUpdated ?? DateTime.Now,
				CreatedByUserId = viewModel.CreatedByUserId,
				UpdatedByUserId = viewModel.UpdatedByUserId,
				IsActive = viewModel.IsActive
			};
		}

		public static SubCategoryViewModel ConvertToViewModel(POS.Data.SubCategory dataEntity)
		{
			if (dataEntity == null)
				return null;

			return new SubCategoryViewModel
			{
				Id = dataEntity.Id,

				Name = dataEntity.Name,
				Description = dataEntity.Description,
				ImagePath = dataEntity.ImagePath,
				CategoryId = dataEntity.CategoryId,

				DateCreated = dataEntity.DateCreated,
				DateUpdated = dataEntity.DateUpdated,
				CreatedByUserId = dataEntity.CreatedByUserId,
				UpdatedByUserId = dataEntity.UpdatedByUserId,
				IsActive = dataEntity.IsActive

			};
		}

		public static IEnumerable<SubCategoryViewModel> ConvertToViewModelList(IEnumerable<POS.Data.SubCategory> dataEntityList)
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
