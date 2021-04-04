using POS.Data;
using POS.IRepository.Common;
using POS.IRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.IRepository.Repository
{
    public class BrandRepository : CommonRepository, IBrandRepository
    {
        public void Delete(Brand brand)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            string query = ("Exec sp_DeleteBrand '" + id + "'");

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

        public IEnumerable<Brand> GetAll()
        {
            IList<Brand> brands = new List<Brand>();

            string query = ("Exec sp_GetAllBrand");
            Command = new SqlCommand(query, Connection);

            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Brand brand = new Brand();

                    brand.Id = Convert.ToInt32(reader["Id"]);

                    brand.Name = reader["Name"].ToString();
                    brand.Description = reader["Description"].ToString();
                    brand.ImagePath = reader["ImagePath"].ToString();
                   

                    brand.DateCreated = reader["DateCreated"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["DateCreated"]);
                    brand.DateUpdated = reader["DateUpdated"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["DateUpdated"]);

                    brand.CreatedByUserId = reader["CreatedByUserId"] == DBNull.Value ? null : reader["CreatedByUserId"].ToString();
                    brand.UpdatedByUserId = reader["UpdatedByUserId"] == DBNull.Value ? null : reader["UpdatedByUserId"].ToString();
                    brand.IsActive = reader["IsActive"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsActive"]);

                    brands.Add(brand);
                }
            }

            reader.Close();
            Connection.Close();
            return brands;

        }

        public async Task<IEnumerable<Brand>> GetAllAsync()
        {
            IList<Brand> brands = new List<Brand>();

            string query = ("Exec sp_GetAllBrand");
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();

            if (reader.HasRows)
            {
                while (await reader.ReadAsync())
                {
                    Brand brand = new Brand();

                    brand.Id = Convert.ToInt32(reader["Id"]);

                    brand.Name = reader["Name"].ToString();
                    brand.Description = reader["Description"].ToString();
                    brand.ImagePath = reader["ImagePath"].ToString();

                    brand.DateCreated = reader["DateCreated"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["DateCreated"]);
                    brand.DateUpdated = reader["DateUpdated"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["DateUpdated"]);

                    brand.CreatedByUserId = reader["CreatedByUserId"] == DBNull.Value ? null : reader["CreatedByUserId"].ToString();
                    brand.UpdatedByUserId = reader["UpdatedByUserId"] == DBNull.Value ? null : reader["UpdatedByUserId"].ToString();
                    brand.IsActive = reader["IsActive"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsActive"]);

                    brands.Add(brand);
                }
            }
            reader.Close();
            Connection.Close();

            return brands;
        }

        public Brand GetById(int id)
        {
            string query = ("Exec sp_GetBrandById '" + id + "'");
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();

            Brand brand = new Brand();

            while (reader.Read())
            {
                brand.Id = Convert.ToInt32(reader["Id"]);

                brand.Name = reader["Name"].ToString();
                brand.Description = reader["Description"].ToString();
                brand.ImagePath = reader["ImagePath"].ToString();

                brand.DateCreated = reader["DateCreated"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["DateCreated"]);
                brand.DateUpdated = reader["DateUpdated"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["DateUpdated"]);

                brand.CreatedByUserId = reader["CreatedByUserId"] == DBNull.Value ? null : reader["CreatedByUserId"].ToString();
                brand.UpdatedByUserId = reader["UpdatedByUserId"] == DBNull.Value ? null : reader["UpdatedByUserId"].ToString();

                brand.IsActive = reader["IsActive"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsActive"]);
            }
            reader.Close();
            Connection.Close();

            return brand;
        }

        public async Task<Brand> GetByIdAsync(int id)
        {
            string query = ("Exec sp_GetBrandById '" + id + "'");
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();

            Brand brand = new Brand();

            while (await reader.ReadAsync())
            {
                brand.Id = Convert.ToInt32(reader["Id"]);

                brand.Name = reader["Name"].ToString();
                brand.Description = reader["Description"].ToString();
                brand.ImagePath = reader["ImagePath"].ToString();

                brand.DateCreated = reader["DateCreated"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["DateCreated"]);
                brand.DateUpdated = reader["DateUpdated"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["DateUpdated"]);

                brand.CreatedByUserId = reader["CreatedByUserId"] == DBNull.Value ? null : reader["CreatedByUserId"].ToString();
                brand.UpdatedByUserId = reader["UpdatedByUserId"] == DBNull.Value ? null : reader["UpdatedByUserId"].ToString();

                brand.IsActive = reader["IsActive"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsActive"]);
            }
            reader.Close();
            Connection.Close();

            return brand;
        }

        public int Insert(Brand brand)
        {
            int result = 0;
            string query = ("Exec sp_SaveBrand '" + brand.Name + "','" + brand.Description + "','" + brand.ImagePath + "','" + brand.DateCreated + "','" + brand.DateUpdated + "','" + brand.CreatedByUserId + "','" + brand.UpdatedByUserId + "','" + brand.IsActive + "'");

            Command = new SqlCommand(query, Connection);
            Connection.Open();

            result = Command.ExecuteNonQuery();

            Connection.Close();

            return 0;

            //if (result > 0)
            //{
            //    return "Brand Save Successsfully";
            //}
            //else
            //{
            //    return "Failed To Save Brand !!!!!";
            //}
        }
        public bool IsExists(Brand brand)
        {
            int result = 0;
            string query = ("Exec sp_UniqueCheckBrand '" + brand.Name + "'");

            Command = new SqlCommand(query, Connection);
            Connection.Open();

            result = (int)Command.ExecuteScalar();
            Connection.Close();
            return result == -1;
        }
        public async Task<int> InsertAsync(Brand brand)
        {
            int result = 0;

            string query = ("Exec sp_SaveBrand '" + brand.Name + "','" + brand.Description + "','" + brand.ImagePath + "','" + brand.DateCreated + "','" + brand.DateUpdated + "','" + brand.CreatedByUserId + "','" + brand.UpdatedByUserId + "','" + brand.IsActive + "'");
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            result = await Command.ExecuteNonQueryAsync();

            Connection.Close();

            return 0;

            //if (result > 0)
            //{
            //    return "Brand Save Successsfully";
            //}
            //else
            //{
            //    return "Failed To Save Brand !!!!!";
            //}
        }

        public void Update(Brand brand)
        {
            int result = 0;

            string query = ("Exec sp_UpdateBrand '" + brand.Name + "','" + brand.Description + "','" + brand.ImagePath + "','" + brand.DateCreated + "','" + brand.DateUpdated + "','" + brand.CreatedByUserId + "','" + brand.UpdatedByUserId + "','" + brand.IsActive + "'");

            Command = new SqlCommand(query, Connection);
            Connection.Open();

            result = Command.ExecuteNonQuery();

            Connection.Close();
        }

        public async Task UpdateAsync(Brand brand)
        {
            int result = 0;
            string query;
            if (brand.ImagePath != null)
            {
                query = ("Exec sp_UpdateBrand '" + brand.Id + "'," + "'" + brand.Name + "'," + "'" + brand.Description + "'," + "'" + brand.ImagePath + "'," +
               "'" + brand.DateCreated + "'," + "'" + brand.DateUpdated + "'," + "'" + brand.CreatedByUserId + "'," + "'" + brand.UpdatedByUserId + "'," + "'" + brand.IsActive + "'");
            }
            else
            {
                query = ("Exec sp_UpdateBrandWithoutImage '" + brand.Id + "'," + "'" + brand.Name + "'," + "'" + brand.Description + "'," + "'" + brand.DateCreated + "'," + 
               "'" + brand.DateUpdated + "'," + "'" + brand.CreatedByUserId + "'," + "'" + brand.UpdatedByUserId + "'," + "'" + brand.IsActive + "'");
            }
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
