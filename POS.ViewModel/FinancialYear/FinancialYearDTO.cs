using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ViewModel.FinancialYear
{
    public class FinancialYearDTO
    {

		public static POS.Data.FinancialYear ConvertToEntity(FinancialYearViewModel viewModel)
		{
			if (viewModel == null)
				return null;

			return new POS.Data.FinancialYear
			{
				Id = viewModel.Id,

				Name = viewModel.Name,
				Description = viewModel.Description,
        		DateStart = viewModel.DateStart,
        		DateEnd = viewModel.DateEnd,

				DateCreated = viewModel.DateCreated ?? DateTime.Now,
				DateUpdated = viewModel.DateUpdated ?? DateTime.Now,
				CreatedByUserId = viewModel.CreatedByUserId,
				UpdatedByUserId = viewModel.UpdatedByUserId,
				IsActive = viewModel.IsActive
			};
		}

		public static FinancialYearViewModel ConvertToViewModel(POS.Data.FinancialYear dataEntity)
		{
			if (dataEntity == null)
				return null;

			return new FinancialYearViewModel
			{
				Id = dataEntity.Id,

				Name = dataEntity.Name,
				Description = dataEntity.Description,
        		DateStart = dataEntity.DateStart,
        		DateEnd = dataEntity.DateEnd,

				DateCreated = dataEntity.DateCreated,
				DateUpdated = dataEntity.DateUpdated,
				CreatedByUserId = dataEntity.CreatedByUserId,
				UpdatedByUserId = dataEntity.UpdatedByUserId,
				IsActive = dataEntity.IsActive

			};
		}

		public static IEnumerable<FinancialYearViewModel> ConvertToViewModelList(IEnumerable<POS.Data.FinancialYear> dataEntityList)
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
