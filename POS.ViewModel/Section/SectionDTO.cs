using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ViewModel.Section
{
    public class SectionDTO
    {
		public static POS.Data.Section ConvertToEntity(SectionViewModel viewModel)
		{
			if (viewModel == null)
				return null;

			return new POS.Data.Section
			{
				Id = viewModel.Id,

				SectionTitle = viewModel.SectionTitle,


				DateCreated = viewModel.DateCreated ?? DateTime.Now,
				DateUpdated = viewModel.DateUpdated ?? DateTime.Now,
				CreatedByUserId = viewModel.CreatedByUserId,
				UpdatedByUserId = viewModel.UpdatedByUserId,
				IsActive = viewModel.IsActive
			};
		}

		public static SectionViewModel ConvertToViewModel(POS.Data.Section dataEntity)
		{
			if (dataEntity == null)
				return null;

			return new SectionViewModel
			{
				Id = dataEntity.Id,

				SectionTitle = dataEntity.SectionTitle,

				DateCreated = dataEntity.DateCreated,
				DateUpdated = dataEntity.DateUpdated,
				CreatedByUserId = dataEntity.CreatedByUserId,
				UpdatedByUserId = dataEntity.UpdatedByUserId,
				IsActive = dataEntity.IsActive

			};
		}

		public static IEnumerable<SectionViewModel> ConvertToViewModelList(IEnumerable<POS.Data.Section> dataEntityList)
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
