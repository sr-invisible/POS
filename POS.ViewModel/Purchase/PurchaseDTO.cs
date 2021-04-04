using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ViewModel.Purchase
{
    public class PurchaseDTO
    {

		public static POS.Data.Purchase ConvertToEntity(PurchaseViewModel viewModel)
		{
			if (viewModel == null)
				return null;

			return new POS.Data.Purchase
			{
				Id = viewModel.Id,

        		InvoiceNo = viewModel.InvoiceNo,
        		DatePurchase = viewModel.DatePurchase,
        		SupplierId = viewModel.SupplierId,
        		Remarks = viewModel.Remarks,
        		PaidAmount = viewModel.PaidAmount,
        		DueAmount = viewModel.DueAmount,

				DateCreated = viewModel.DateCreated ?? DateTime.Now,
				DateUpdated = viewModel.DateUpdated ?? DateTime.Now,
				CreatedByUserId = viewModel.CreatedByUserId,
				UpdatedByUserId = viewModel.UpdatedByUserId,
				IsActive = viewModel.IsActive
			};
		}

		public static PurchaseViewModel ConvertToViewModel(POS.Data.Purchase dataEntity)
		{
			if (dataEntity == null)
				return null;

			return new PurchaseViewModel
			{
				Id = dataEntity.Id,

				InvoiceNo = dataEntity.InvoiceNo,
        		DatePurchase = dataEntity.DatePurchase,
        		SupplierId = dataEntity.SupplierId,
        		Remarks = dataEntity.Remarks,
        		PaidAmount = dataEntity.PaidAmount,
        		DueAmount = dataEntity.DueAmount,

				DateCreated = dataEntity.DateCreated,
				DateUpdated = dataEntity.DateUpdated,
				CreatedByUserId = dataEntity.CreatedByUserId,
				UpdatedByUserId = dataEntity.UpdatedByUserId,
				IsActive = dataEntity.IsActive

			};
		}

		public static IEnumerable<PurchaseViewModel> ConvertToViewModelList(IEnumerable<POS.Data.Purchase> dataEntityList)
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
