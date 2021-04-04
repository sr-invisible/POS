using POS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.IRepository.IRepository
{
    public interface IRoleBaseMenuPermissionRepository : IDisposable
    {
		
		IEnumerable<RoleBaseMenuPermission> GetAll();
		int Insert(RoleBaseMenuPermission roleBaseMenuPermission);
		void Update(RoleBaseMenuPermission roleBaseMenuPermission);

		Task<IEnumerable<RoleBaseMenuPermission>> GetAllAsync();
		Task<int> InsertAsync(RoleBaseMenuPermission roleBaseMenuPermission);
		Task UpdateAsync(RoleBaseMenuPermission roleBaseMenuPermission);

	}
}
