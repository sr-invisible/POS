using POS.Data;
using POS.IRepository.Common;
using POS.IRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.IRepository.Repository
{
    public class ShopRepository : CommonRepository, IShopRepository
    {
        public void Delete(Shop shop)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            string query = "Exec sp_ShopCRUD 'DELETE', '" + id + "'";

            Command = new SqlCommand(query, Connection);
            Connection.Open();

            string message = null;
            if (Command.ExecuteNonQuery() == 1)
            {
                message = "Deleted Successfully!";
            }
            else
            {
                message = "Invalid Input";
            }

            Connection.Close();
        }

        public IEnumerable<Shop> GetAll()
        {
            IList<Shop> brands = new List<Shop>();

            string query = "Exec sp_ShopCRUD 'SELECT'";
            Command = new SqlCommand(query, Connection);

            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Shop shop = new Shop();

                    shop.Id = Convert.ToInt32(reader["Id"]);

                    shop.Name = reader["Name"].ToString();
                    shop.Email = reader["Email"].ToString();
                    shop.Address = reader["Address"].ToString();
                    shop.WebAddress = reader["WebAddress"].ToString();
                    shop.Phone = reader["Phone"].ToString();
                    shop.FinancialYearId = Convert.ToInt32(reader["FinancialYearId"]); 


                    shop.DateCreated = reader["DateCreated"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["DateCreated"]);
                    shop.DateUpdated = reader["DateUpdated"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["DateUpdated"]);

                    shop.CreatedByUserId = reader["CreatedByUserId"] == DBNull.Value ? null : reader["CreatedByUserId"].ToString();
                    shop.UpdatedByUserId = reader["UpdatedByUserId"] == DBNull.Value ? null : reader["UpdatedByUserId"].ToString();
                    shop.IsActive = reader["IsActive"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsActive"]);

                    brands.Add(shop);
                }
            }

            reader.Close();
            Connection.Close();
            return brands;

        }

        public async Task<IEnumerable<Shop>> GetAllAsync()
        {
            IList<Shop> brands = new List<Shop>();

            string query = "Exec sp_ShopCRUD 'SELECT'";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();

            if (reader.HasRows)
            {
                while (await reader.ReadAsync())
                {
                    Shop shop = new Shop();

                    shop.Id = Convert.ToInt32(reader["Id"]);

                    shop.Name = reader["Name"].ToString();
                    shop.Email = reader["Email"].ToString();
                    shop.Address = reader["Address"].ToString();
                    shop.WebAddress = reader["WebAddress"].ToString();
                    shop.Phone = reader["Phone"].ToString();
                    shop.FinancialYearId = Convert.ToInt32(reader["FinancialYearId"]);

                    shop.DateCreated = reader["DateCreated"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["DateCreated"]);
                    shop.DateUpdated = reader["DateUpdated"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["DateUpdated"]);

                    shop.CreatedByUserId = reader["CreatedByUserId"] == DBNull.Value ? null : reader["CreatedByUserId"].ToString();
                    shop.UpdatedByUserId = reader["UpdatedByUserId"] == DBNull.Value ? null : reader["UpdatedByUserId"].ToString();
                    shop.IsActive = reader["IsActive"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsActive"]);

                    brands.Add(shop);
                }
            }
            reader.Close();
            Connection.Close();

            return brands;
        }

        public Shop GetById(int id)
        {
            string query = "Exec sp_ShopCRUD 'SELECT', '" + id + "'";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();

            Shop shop = new Shop();

            while (reader.Read())
            {
                shop.Id = Convert.ToInt32(reader["Id"]);

                shop.Name = reader["Name"].ToString();
                shop.Email = reader["Email"].ToString();
                shop.Address = reader["Address"].ToString();
                shop.WebAddress = reader["WebAddress"].ToString();
                shop.Phone = reader["Phone"].ToString();
                shop.FinancialYearId = Convert.ToInt32(reader["FinancialYearId"]);

                shop.DateCreated = reader["DateCreated"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["DateCreated"]);
                shop.DateUpdated = reader["DateUpdated"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["DateUpdated"]);

                shop.CreatedByUserId = reader["CreatedByUserId"] == DBNull.Value ? null : reader["CreatedByUserId"].ToString();
                shop.UpdatedByUserId = reader["UpdatedByUserId"] == DBNull.Value ? null : reader["UpdatedByUserId"].ToString();

                shop.IsActive = reader["IsActive"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsActive"]);
            }
            reader.Close();
            Connection.Close();

            return shop;
        }

        public async Task<Shop> GetByIdAsync(int id)
        {
            string query = "Exec sp_ShopCRUD 'SELECT','" + id + "'";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();

            Shop shop = new Shop();

            while (await reader.ReadAsync())
            {
                shop.Id = Convert.ToInt32(reader["Id"]);

                shop.Name = reader["Name"].ToString();
                    shop.Email = reader["Email"].ToString();
                    shop.Address = reader["Address"].ToString();
                    shop.WebAddress = reader["WebAddress"].ToString();
                    shop.Phone = reader["Phone"].ToString();
                    shop.FinancialYearId = Convert.ToInt32(reader["FinancialYearId"]); 

                shop.DateCreated = reader["DateCreated"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["DateCreated"]);
                shop.DateUpdated = reader["DateUpdated"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["DateUpdated"]);

                shop.CreatedByUserId = reader["CreatedByUserId"] == DBNull.Value ? null : reader["CreatedByUserId"].ToString();
                shop.UpdatedByUserId = reader["UpdatedByUserId"] == DBNull.Value ? null : reader["UpdatedByUserId"].ToString();

                shop.IsActive = reader["IsActive"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsActive"]);
            }
            reader.Close();
            Connection.Close();

            return shop;
        }

        public int Insert(Shop shop)
        {
            int result = 0;
            string query = "Exec sp_ShopCRUD 'INSERT','" + shop.Id + "', '" + shop.Name + "','" + shop.Email + "','" + shop.Address + "', '" + shop.WebAddress + "','" + shop.Phone + "','" + shop.FinancialYearId + "','" + shop.DateCreated + "','" + shop.DateUpdated + "','" + shop.CreatedByUserId + "','" + shop.UpdatedByUserId + "','" + shop.IsActive + "'";

            Command = new SqlCommand(query, Connection);
            Connection.Open();

            result = Command.ExecuteNonQuery();

            Connection.Close();

            return result;

            //if (result > 0)
            //{
            //    return "Shop Save Successsfully";
            //}
            //else
            //{
            //    return "Failed To Save Shop !!!!!";
            //}
        }
        public bool IsExists(Shop shop)
        {
            int result = 0;
            string query = "Exec sp_UniqueCheckCategory '" + shop.Name + "'";

            Command = new SqlCommand(query, Connection);
            Connection.Open();

            result = (int)Command.ExecuteScalar();
            Connection.Close();
            return result == -1;
        }
        public async Task<int> InsertAsync(Shop shop)
        {
            int result = 0;
            string query = "Exec sp_ShopCRUD 'INSERT','" + shop.Id + "', '" + shop.Name + "','" + shop.Email + "','" + shop.Address + "', '" + shop.WebAddress + "','" + shop.Phone + "','" + shop.FinancialYearId + "','" + shop.DateCreated + "','" + shop.DateUpdated + "','" + shop.CreatedByUserId + "','" + shop.UpdatedByUserId + "','" + shop.IsActive + "'";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            result = await Command.ExecuteNonQueryAsync();

            Connection.Close();

            return result;

            //if (result > 0)
            //{
            //    return "Shop Save Successsfully";
            //}
            //else
            //{
            //    return "Failed To Save Shop !!!!!";
            //}
        }

        public void Update(Shop shop)
        {
            int result = 0;

            string query = "Exec sp_ShopCRUD 'UPDATE', '" + shop.Id + "','" + shop.Name + "','" + shop.Email + "','" + shop.Address + "','" + shop.WebAddress + "','" + shop.Phone + "','" + shop.FinancialYearId + "','" + shop.DateCreated + "','" + shop.DateUpdated + "','" + shop.CreatedByUserId + "','" + shop.UpdatedByUserId + "','" + shop.IsActive + "'";

            Command = new SqlCommand(query, Connection);
            Connection.Open();

            result = Command.ExecuteNonQuery();

            Connection.Close();
        }

        public async Task UpdateAsync(Shop shop)
        {
            int result = 0;
            string query = "Exec sp_ShopCRUD 'UPDATE', '" + shop.Id + "','" + shop.Name + "','" + shop.Email + "','" + shop.Address + "','" + shop.WebAddress + "','" + shop.Phone + "','" + shop.FinancialYearId + "','" + shop.DateCreated + "','" + shop.DateUpdated + "','" + shop.CreatedByUserId + "','" + shop.UpdatedByUserId + "','" + shop.IsActive + "'";

            Command = new SqlCommand(query, Connection);
            Connection.Open();
            result = await Command.ExecuteNonQueryAsync();

            Connection.Close();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.Connection.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
