using POS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.IRepository.IRepository
{
    public interface ISubCategoryRepository : IDisposable
    {
		void Delete(SubCategory subCategory);
		void Delete(int id);
		IEnumerable<SubCategory> GetAll();
		SubCategory GetById(int id);
		int Insert(SubCategory subCategory);
		void Update(SubCategory subCategory);

		Task<IEnumerable<SubCategory>> GetAllAsync();
		Task<SubCategory> GetByIdAsync(int id);
		Task<int> InsertAsync(SubCategory subCategory);
		Task UpdateAsync(SubCategory subCategory);
	}
}
