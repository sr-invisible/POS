using POS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.IRepository.IRepository
{
    public interface ISectionRepository : IDisposable
    {
		void Delete(Section section);
		void Delete(int id);
		IEnumerable<Section> GetAll();
		Section GetById(int id);
		int Insert(Section section);
		void Update(Section section);

		Task<IEnumerable<Section>> GetAllAsync();
		Task<Section> GetByIdAsync(int id);
		Task<int> InsertAsync(Section section);
		Task UpdateAsync(Section section);
	}
}
