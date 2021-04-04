using POS.IRepository.IRepository;
using POS.Service.IService;
using POS.ViewModel.RoleBaseMenuPermission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service.Service
{
    public class RoleBaseMenuPermissionService : IRoleBaseMenuPermissionService
    {
        private readonly IRoleBaseMenuPermissionRepository _roleBaseMenuPermissionRepository;
        public RoleBaseMenuPermissionService(IRoleBaseMenuPermissionRepository roleBaseMenuPermissionRepository)
        {
            this._roleBaseMenuPermissionRepository = roleBaseMenuPermissionRepository;
        }

        public async Task<IEnumerable<RoleBaseMenuPermissionViewModel>> GetAll()
        {
            return RoleBaseMenuPermissionDTO.ConvertToViewModelList(await this._roleBaseMenuPermissionRepository.GetAllAsync());
        }

        public async Task<int> Insert(RoleBaseMenuPermissionViewModel viewModel)
        {
            int id = 0;
            try
            {
                id = await this._roleBaseMenuPermissionRepository.InsertAsync(RoleBaseMenuPermissionDTO.ConvertToEntity(viewModel));
                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Update(RoleBaseMenuPermissionViewModel viewModel)
        {
            try
            {
                await this._roleBaseMenuPermissionRepository.UpdateAsync(RoleBaseMenuPermissionDTO.ConvertToEntity(viewModel));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
