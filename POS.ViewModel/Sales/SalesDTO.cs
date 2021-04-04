using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ViewModel.Sales
{
    public class SalesDTO 
    {

		public static POS.Data.Sales ConvertToEntity(SalesViewModel viewModel)
		{
			if (viewModel == null)
				return null;

			return new POS.Data.Sales
			{
				Id = viewModel.Id,

				SalesInvoiceNo = viewModel.SalesInvoiceNo,
        		CustomerId = viewModel.CustomerId,
        		Remarks	= viewModel.Remarks,
        		OverallDiscount	= viewModel.OverallDiscount,

				DateCreated = viewModel.DateCreated ?? DateTime.Now,
				DateUpdated = viewModel.DateUpdated ?? DateTime.Now,
				CreatedByUserId = viewModel.CreatedByUserId,
				UpdatedByUserId = viewModel.UpdatedByUserId,
				IsActive = viewModel.IsActive
			};
		}

		public static SalesViewModel ConvertToViewModel(POS.Data.Sales dataEntity)
		{
			if (dataEntity == null)
				return null;

			return new SalesViewModel
			{
				Id = dataEntity.Id,

				SalesInvoiceNo = dataEntity.SalesInvoiceNo,
        		CustomerId = dataEntity.CustomerId,
        		Remarks	= dataEntity.Remarks,
        		OverallDiscount	= dataEntity.OverallDiscount,

				DateCreated = dataEntity.DateCreated,
				DateUpdated = dataEntity.DateUpdated,
				CreatedByUserId = dataEntity.CreatedByUserId,
				UpdatedByUserId = dataEntity.UpdatedByUserId,
				IsActive = dataEntity.IsActive

			};
		}

		public static IEnumerable<SalesViewModel> ConvertToViewModelList(IEnumerable<POS.Data.Sales> dataEntityList)
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
