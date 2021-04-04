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
    public class CategoryRepository : CommonRepository, ICategoryRepository
    {
        public void Delete(Category category)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            string query = "Exec sp_CategoryCRUD 'DELETE', '" + id + "'";

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

        public IEnumerable<Category> GetAll()
        {
            IList<Category> brands = new List<Category>();

            string query = "Exec sp_CategoryCRUD 'SELECT'";
            Command = new SqlCommand(query, Connection);

            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Category category = new Category();

                    category.Id = Convert.ToInt32(reader["Id"]);

                    category.Name = reader["Name"].ToString();
                    category.Description = reader["Description"].ToString();
                    category.ImagePath = reader["ImagePath"].ToString();


                    category.DateCreated = reader["DateCreated"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["DateCreated"]);
                    category.DateUpdated = reader["DateUpdated"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["DateUpdated"]);

                    category.CreatedByUserId = reader["CreatedByUserId"] == DBNull.Value ? null : reader["CreatedByUserId"].ToString();
                    category.UpdatedByUserId = reader["UpdatedByUserId"] == DBNull.Value ? null : reader["UpdatedByUserId"].ToString();
                    category.IsActive = reader["IsActive"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsActive"]);

                    brands.Add(category);
                }
            }

            reader.Close();
            Connection.Close();
            return brands;

        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            IList<Category> brands = new List<Category>();

            string query = "Exec sp_CategoryCRUD 'SELECT'";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();

            if (reader.HasRows)
            {
                while (await reader.ReadAsync())
                {
                    Category category = new Category();

                    category.Id = Convert.ToInt32(reader["Id"]);

                    category.Name = reader["Name"].ToString();
                    category.Description = reader["Description"].ToString();
                    category.ImagePath = reader["ImagePath"].ToString();

                    category.DateCreated = reader["DateCreated"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["DateCreated"]);
                    category.DateUpdated = reader["DateUpdated"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["DateUpdated"]);

                    category.CreatedByUserId = reader["CreatedByUserId"] == DBNull.Value ? null : reader["CreatedByUserId"].ToString();
                    category.UpdatedByUserId = reader["UpdatedByUserId"] == DBNull.Value ? null : reader["UpdatedByUserId"].ToString();
                    category.IsActive = reader["IsActive"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsActive"]);

                    brands.Add(category);
                }
            }
            reader.Close();
            Connection.Close();

            return brands;
        }

        public Category GetById(int id)
        {
            string query = "Exec sp_CategoryCRUD 'SELECT', '" + id + "'";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();

            Category category = new Category();

            while (reader.Read())
            {
                category.Id = Convert.ToInt32(reader["Id"]);

                category.Name = reader["Name"].ToString();
                category.Description = reader["Description"].ToString();
                category.ImagePath = reader["ImagePath"].ToString();

                category.DateCreated = reader["DateCreated"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["DateCreated"]);
                category.DateUpdated = reader["DateUpdated"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["DateUpdated"]);

                category.CreatedByUserId = reader["CreatedByUserId"] == DBNull.Value ? null : reader["CreatedByUserId"].ToString();
                category.UpdatedByUserId = reader["UpdatedByUserId"] == DBNull.Value ? null : reader["UpdatedByUserId"].ToString();

                category.IsActive = reader["IsActive"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsActive"]);
            }
            reader.Close();
            Connection.Close();

            return category;
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            string query = "Exec sp_CategoryCRUD 'SELECT','" + id + "'";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();

            Category category = new Category();

            while (await reader.ReadAsync())
            {
                category.Id = Convert.ToInt32(reader["Id"]);

                category.Name = reader["Name"].ToString();
                category.Description = reader["Description"].ToString();
                category.ImagePath = reader["ImagePath"].ToString();

                category.DateCreated = reader["DateCreated"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["DateCreated"]);
                category.DateUpdated = reader["DateUpdated"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["DateUpdated"]);

                category.CreatedByUserId = reader["CreatedByUserId"] == DBNull.Value ? null : reader["CreatedByUserId"].ToString();
                category.UpdatedByUserId = reader["UpdatedByUserId"] == DBNull.Value ? null : reader["UpdatedByUserId"].ToString();

                category.IsActive = reader["IsActive"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsActive"]);
            }
            reader.Close();
            Connection.Close();

            return category;
        }

        public int Insert(Category category)
        {
            int result = 0;
            string query = ("Exec sp_CategoryCRUD 'INSERT','" + category.Id + "', '" + category.Name + "','" + category.Description + "','" + category.ImagePath + "','" + category.DateCreated + "','" + category.DateUpdated + "','" + category.CreatedByUserId + "','" + category.UpdatedByUserId + "','" + category.IsActive + "'");

            Command = new SqlCommand(query, Connection);
            Connection.Open();

            result = Command.ExecuteNonQuery();

            Connection.Close();

            return result;

            //if (result > 0)
            //{
            //    return "Category Save Successsfully";
            //}
            //else
            //{
            //    return "Failed To Save Category !!!!!";
            //}
        }
        public bool IsExists(Category category)
        {
            int result = 0;
            string query = "Exec sp_UniqueCheckCategory '" + category.Name + "'";

            Command = new SqlCommand(query, Connection);
            Connection.Open();

            result = (int)Command.ExecuteScalar();
            Connection.Close();
            return result == -1;
        }
        public async Task<int> InsertAsync(Category category)
        {
            int result = 0;
            string query = "Exec sp_CategoryCRUD 'INSERT','" + category.Id + "','" + category.Name + "','" + category.Description + "','" + category.ImagePath + "','" + category.DateCreated + "','" + category.DateUpdated + "','" + category.CreatedByUserId + "','" + category.UpdatedByUserId + "','" + category.IsActive + "'";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            result = await Command.ExecuteNonQueryAsync();

            Connection.Close();

            return result;

            //if (result > 0)
            //{
            //    return "Category Save Successsfully";
            //}
            //else
            //{
            //    return "Failed To Save Category !!!!!";
            //}
        }

        public void Update(Category category)
        {
            int result = 0;

            string query = "Exec sp_CategoryCRUD 'UPDATE', '" + category.Id + "','" + category.Name + "','" + category.Description + "','" + category.ImagePath + "','" + category.DateCreated + "','" + category.DateUpdated + "','" + category.CreatedByUserId + "','" + category.UpdatedByUserId + "','" + category.IsActive + "'";

            Command = new SqlCommand(query, Connection);
            Connection.Open();

            result = Command.ExecuteNonQuery();

            Connection.Close();
        }

        public async Task UpdateAsync(Category category)
        {
            int result = 0;
            string query = "Exec sp_CategoryCRUD 'UPDATE', '" + category.Id + "','" + category.Name + "','" + category.Description + "','" + category.ImagePath + "','" + category.DateCreated + "','" + category.DateUpdated + "','" + category.CreatedByUserId + "','" + category.UpdatedByUserId + "','" + category.IsActive + "'";

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
