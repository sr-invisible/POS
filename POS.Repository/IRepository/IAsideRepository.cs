using POS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.IRepository.IRepository
{
    public interface IAsideRepository : IDisposable
    {
		void Delete(Aside aside);
		void Delete(int id);
		IEnumerable<Aside> GetAll();
		Aside GetById(int id);
		int Insert(Aside aside);
		void Update(Aside aside);

		

		Task<IEnumerable<Aside>> GetAllAsync();
		Task<Aside> GetByIdAsync(int id);
		Task<int> InsertAsync(Aside aside);
		Task UpdateAsync(Aside aside);
	}
}
