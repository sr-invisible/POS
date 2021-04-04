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
    public class SubCategoryRepository : CommonRepository,ISubCategoryRepository
    {
        public void Delete(SubCategory subCategory)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            string query = ("Exec sp_SubCategoryCRUD DELETE '" + id + "'");

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

        public IEnumerable<SubCategory> GetAll()
        {
            IList<SubCategory> subCategorys = new List<SubCategory>();

            string query = ("Exec sp_SubCategoryCRUD 'SELECT'");
            Command = new SqlCommand(query, Connection);

            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    SubCategory subCategory = new SubCategory();

                    subCategory.Id = Convert.ToInt32(reader["Id"]);

                    subCategory.Name = reader["Name"].ToString();
                    subCategory.Description = reader["Description"].ToString();
                    subCategory.ImagePath = reader["ImagePath"].ToString();
                    subCategory.CategoryId = Convert.ToInt32(reader["CategoryId"]);


                    subCategory.DateCreated = reader["DateCreated"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["DateCreated"]);
                    subCategory.DateUpdated = reader["DateUpdated"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["DateUpdated"]);

                    subCategory.CreatedByUserId = reader["CreatedByUserId"] == DBNull.Value ? null : reader["CreatedByUserId"].ToString();
                    subCategory.UpdatedByUserId = reader["UpdatedByUserId"] == DBNull.Value ? null : reader["UpdatedByUserId"].ToString();
                    subCategory.IsActive = reader["IsActive"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsActive"]);

                    subCategorys.Add(subCategory);
                }
            }

            reader.Close();
            Connection.Close();
            return subCategorys;

        }

        public async Task<IEnumerable<SubCategory>> GetAllAsync()
        {
            IList<SubCategory> subCategorys = new List<SubCategory>();

            string query = ("Exec sp_SubCategoryCRUD 'SELECT'");
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();

            if (reader.HasRows)
            {
                while (await reader.ReadAsync())
                {
                    SubCategory subCategory = new SubCategory();

                    subCategory.Id = Convert.ToInt32(reader["Id"]);

                    subCategory.Name = reader["Name"].ToString();
                    subCategory.Description = reader["Description"].ToString();
                    subCategory.ImagePath = reader["ImagePath"].ToString();
                    subCategory.CategoryId = Convert.ToInt32(reader["CategoryId"]);

                    subCategory.DateCreated = reader["DateCreated"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["DateCreated"]);
                    subCategory.DateUpdated = reader["DateUpdated"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["DateUpdated"]);

                    subCategory.CreatedByUserId = reader["CreatedByUserId"] == DBNull.Value ? null : reader["CreatedByUserId"].ToString();
                    subCategory.UpdatedByUserId = reader["UpdatedByUserId"] == DBNull.Value ? null : reader["UpdatedByUserId"].ToString();
                    subCategory.IsActive = reader["IsActive"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsActive"]);

                    subCategorys.Add(subCategory);
                }
            }
            reader.Close();
            Connection.Close();

            return subCategorys;
        }

        public SubCategory GetById(int id)
        {
            string query = ("Exec sp_SubCategoryCRUD 'SELECT', '" + id + "'");
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();

            SubCategory subCategory = new SubCategory();

            while (reader.Read())
            {
                subCategory.Id = Convert.ToInt32(reader["Id"]);

                subCategory.Name = reader["Name"].ToString();
                subCategory.Description = reader["Description"].ToString();
                subCategory.ImagePath = reader["ImagePath"].ToString();
                subCategory.CategoryId = Convert.ToInt32(reader["CategoryId"]);

                subCategory.DateCreated = reader["DateCreated"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["DateCreated"]);
                subCategory.DateUpdated = reader["DateUpdated"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["DateUpdated"]);

                subCategory.CreatedByUserId = reader["CreatedByUserId"] == DBNull.Value ? null : reader["CreatedByUserId"].ToString();
                subCategory.UpdatedByUserId = reader["UpdatedByUserId"] == DBNull.Value ? null : reader["UpdatedByUserId"].ToString();

                subCategory.IsActive = reader["IsActive"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsActive"]);
            }
            reader.Close();
            Connection.Close();

            return subCategory;
        }

        public async Task<SubCategory> GetByIdAsync(int id)
        {
            string query = ("Exec sp_SubCategoryCRUD 'SELECT','" + id + "'");
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();

            SubCategory subCategory = new SubCategory();

            while (await reader.ReadAsync())
            {
                subCategory.Id = Convert.ToInt32(reader["Id"]);

                subCategory.Name = reader["Name"].ToString();
                subCategory.Description = reader["Description"].ToString();
                subCategory.ImagePath = reader["ImagePath"].ToString();
                subCategory.CategoryId = Convert.ToInt32(reader["CategoryId"]);

                subCategory.DateCreated = reader["DateCreated"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["DateCreated"]);
                subCategory.DateUpdated = reader["DateUpdated"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["DateUpdated"]);

                subCategory.CreatedByUserId = reader["CreatedByUserId"] == DBNull.Value ? null : reader["CreatedByUserId"].ToString();
                subCategory.UpdatedByUserId = reader["UpdatedByUserId"] == DBNull.Value ? null : reader["UpdatedByUserId"].ToString();

                subCategory.IsActive = reader["IsActive"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsActive"]);
            }
            reader.Close();
            Connection.Close();

            return subCategory;
        }

        public int Insert(SubCategory subCategory)
        {
            int result = 0;
            string query = ("Exec sp_SubCategoryCRUD 'INSERT','" + subCategory.Id + "','" + subCategory.Name + "','" + subCategory.Description + "','" + subCategory.ImagePath + "','" + subCategory.CategoryId + "','" + subCategory.DateCreated + "','" + subCategory.DateUpdated + "','" + subCategory.CreatedByUserId + "','" + subCategory.UpdatedByUserId + "','" + subCategory.IsActive + "'");

            Command = new SqlCommand(query, Connection);
            Connection.Open();

            result = Command.ExecuteNonQuery();

            Connection.Close();

            return result;

            //if (result > 0)
            //{
            //    return "SubCategory Save Successsfully";
            //}
            //else
            //{
            //    return "Failed To Save SubCategory !!!!!";
            //}
        }
        public bool IsExists(SubCategory subCategory)
        {
            int result = 0;
            string query = ("Exec sp_UniqueCheckCategory '" + subCategory.Name + "'");

            Command = new SqlCommand(query, Connection);
            Connection.Open();

            result = (int)Command.ExecuteScalar();
            Connection.Close();
            return result == -1;
        }
        public async Task<int> InsertAsync(SubCategory subCategory)
        {
            int result = 0;
            string query = ("Exec sp_SubCategoryCRUD 'INSERT','" + subCategory.Id + "','" + subCategory.Name + "','" + subCategory.Description + "','" + subCategory.ImagePath + "','" + subCategory.CategoryId + "','" + subCategory.DateCreated + "','" + subCategory.DateUpdated + "','" + subCategory.CreatedByUserId + "','" + subCategory.UpdatedByUserId + "','" + subCategory.IsActive + "'");
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            result = await Command.ExecuteNonQueryAsync();

            Connection.Close();

            return result;

            //if (result > 0)
            //{
            //    return "SubCategory Save Successsfully";
            //}
            //else
            //{
            //    return "Failed To Save SubCategory !!!!!";
            //}
        }

        public void Update(SubCategory subCategory)
        {
            int result = 0;

            string query = ("Exec sp_SubCategoryCRUD 'UPDATE', '" + subCategory.Id + "','" + subCategory.Name + "','" + subCategory.Description + "','" + subCategory.ImagePath + "','" + subCategory.CategoryId + "','" + subCategory.DateCreated + "','" + subCategory.DateUpdated + "','" + subCategory.CreatedByUserId + "','" + subCategory.UpdatedByUserId + "','" + subCategory.IsActive + "'");

            Command = new SqlCommand(query, Connection);
            Connection.Open();

            result = Command.ExecuteNonQuery();

            Connection.Close();
        }

        public async Task UpdateAsync(SubCategory subCategory)
        {
            int result = 0;
            string query = ("Exec sp_SubCategoryCRUD 'UPDATE', '" + subCategory.Id + "'," + "'" + subCategory.Name + "'," + "'" + subCategory.Description + "'," + "'" + subCategory.ImagePath + "','" + subCategory.CategoryId + "'," +
               "'" + subCategory.DateCreated + "'," + "'" + subCategory.DateUpdated + "'," + "'" + subCategory.CreatedByUserId + "'," + "'" + subCategory.UpdatedByUserId + "'," + "'" + subCategory.IsActive + "'");

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
