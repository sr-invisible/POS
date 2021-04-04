﻿using POS.ViewModel.RoleBaseMenuPermission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service.IService
{
    public interface IRoleBaseMenuPermissionService
    {
		Task<IEnumerable<RoleBaseMenuPermissionViewModel>> GetAll();
		Task<int> Insert(RoleBaseMenuPermissionViewModel viewModel);
		Task Update(RoleBaseMenuPermissionViewModel viewModel);
	}
}
