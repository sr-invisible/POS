using POS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.IRepository.IRepository
{
    public interface ISalesDetailRepository : IDisposable
    {
		void Delete(SalesDetail salesDetail);
		void Delete(int id);
		IEnumerable<SalesDetail> GetAll();
		SalesDetail GetById(int id);
		int Insert(SalesDetail salesDetail);
		void Update(SalesDetail salesDetail);



		Task<IEnumerable<SalesDetail>> GetAllAsync();
		Task<SalesDetail> GetByIdAsync(int id);
		Task<int> InsertAsync(SalesDetail salesDetail);
		Task UpdateAsync(SalesDetail salesDetail);
	}
}
