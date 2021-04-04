using POS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.IRepository.IRepository
{
    public interface ICategoryRepository : IDisposable
    {
		void Delete(Category category);
		void Delete(int id);
		IEnumerable<Category> GetAll();
		Category GetById(int id);
		int Insert(Category category);
		void Update(Category category);

		Task<IEnumerable<Category>> GetAllAsync();
		Task<Category> GetByIdAsync(int id);
		Task<int> InsertAsync(Category category);
		Task UpdateAsync(Category category);

	}
}
