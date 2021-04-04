using POS.IRepository.IRepository;
using POS.Service.IService;
using POS.ViewModel.FinancialYear;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service.Service
{
    public class FinancialYearService : IFinancialYearService
    {
        private readonly IFinancialYearRepository _financialYearRepository;
        public FinancialYearService() { }
        public FinancialYearService(IFinancialYearRepository financialYearRepository)
        {
            this._financialYearRepository = financialYearRepository;
        }

        public async Task Delete(FinancialYearViewModel viewModel)
        {
            this._financialYearRepository.Delete(FinancialYearDTO.ConvertToEntity(viewModel));
            await Task.FromResult(0);
        }

        public async Task Delete(int id)
        {
            this._financialYearRepository.Delete(id);
            await Task.FromResult(id);
        }

        public async Task<IEnumerable<FinancialYearViewModel>> GetAll()
        {
            return FinancialYearDTO.ConvertToViewModelList(await this._financialYearRepository.GetAllAsync());
        }

        public async Task<FinancialYearViewModel> GetById(int id)
        {
            return FinancialYearDTO.ConvertToViewModel(await this._financialYearRepository.GetByIdAsync(id));
        }

        public async Task<int> Insert(FinancialYearViewModel viewModel)
        {
            int id = 0;
            try
            {
                id = await this._financialYearRepository.InsertAsync(FinancialYearDTO.ConvertToEntity(viewModel));
                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Update(FinancialYearViewModel viewModel)
        {
            try
            {
                await this._financialYearRepository.UpdateAsync(FinancialYearDTO.ConvertToEntity(viewModel));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
