using POS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.IRepository.IRepository
{
    public interface IShopRepository : IDisposable
    {
		void Delete(Shop shop);
		void Delete(int id);
		IEnumerable<Shop> GetAll();
		Shop GetById(int id);
		int Insert(Shop shop);
		void Update(Shop shop);

		Task<IEnumerable<Shop>> GetAllAsync();
		Task<Shop> GetByIdAsync(int id);
		Task<int> InsertAsync(Shop shop);
		Task UpdateAsync(Shop shop);
	}
}
