using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ViewModel.Category
{
    public class CategoryDTO
    {

		public static POS.Data.Category ConvertToEntity(CategoryViewModel viewModel)
		{
			if (viewModel == null)
				return null;

			return new POS.Data.Category
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

		public static CategoryViewModel ConvertToViewModel(POS.Data.Category dataEntity)
		{
			if (dataEntity == null)
				return null;

			return new CategoryViewModel
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

		public static IEnumerable<CategoryViewModel> ConvertToViewModelList(IEnumerable<POS.Data.Category> dataEntityList)
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
