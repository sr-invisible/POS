using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ViewModel.Aside
{
    public class AsideDTO
    {

		public static POS.Data.Aside ConvertToEntity(AsideViewModel viewModel)
		{
			if (viewModel == null)
				return null;

			return new POS.Data.Aside
			{
				Id = viewModel.Id,
				SectionId = viewModel.SectionId,
				OptionName = viewModel.OptionName,
       			Controller = viewModel.Controller,
        		Action = viewModel.Action,
        		Area = viewModel.Area,
        		Status = viewModel.Status,
        		ParentId = viewModel.ParentId,
        		IsParent = viewModel.IsParent,
        		HasChild= viewModel.HasChild,
				Icon = viewModel.Icon,
		
				DateCreated = viewModel.DateCreated ?? DateTime.Now,
				DateUpdated = viewModel.DateUpdated ?? DateTime.Now,
				CreatedByUserId = viewModel.CreatedByUserId,
				UpdatedByUserId = viewModel.UpdatedByUserId,
				IsActive = viewModel.IsActive
			};
		}

		public static AsideViewModel ConvertToViewModel(POS.Data.Aside dataEntity)
		{
			if (dataEntity == null)
				return null;

			return new AsideViewModel
			{
				Id = dataEntity.Id,
				SectionId = dataEntity.SectionId,
				OptionName = dataEntity.OptionName,
				Controller = dataEntity.Controller,
				Action = dataEntity.Action,
				Area = dataEntity.Area,
				Status = dataEntity.Status,
				ParentId = dataEntity.ParentId,
				IsParent = dataEntity.IsParent,
				HasChild = dataEntity.HasChild,
				Icon = dataEntity.Icon,

				DateCreated = dataEntity.DateCreated,
				DateUpdated = dataEntity.DateUpdated,
				CreatedByUserId = dataEntity.CreatedByUserId,
				UpdatedByUserId = dataEntity.UpdatedByUserId,
				IsActive = dataEntity.IsActive

			};
		}

		public static IEnumerable<AsideViewModel> ConvertToViewModelList(IEnumerable<POS.Data.Aside> dataEntityList)
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
