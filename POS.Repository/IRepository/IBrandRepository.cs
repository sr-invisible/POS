using POS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.IRepository.IRepository
{
    public interface IBrandRepository : IDisposable
    {
		void Delete(Brand brand);
		void Delete(int id);
		IEnumerable<Brand> GetAll();
		Brand GetById(int id);
		int Insert(Brand brand);
		void Update(Brand brand);



		Task<IEnumerable<Brand>> GetAllAsync();
		Task<Brand> GetByIdAsync(int id);
		Task<int> InsertAsync(Brand brand);
		Task UpdateAsync(Brand brand);
	}
}
