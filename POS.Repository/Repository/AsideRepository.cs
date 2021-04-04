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
    public class AsideRepository : CommonRepository, IAsideRepository
    {
        public void Delete(Aside aside)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Aside> GetAll()
        {
            IList<Aside> asides = new List<Aside>();

            string query = ("Exec sp_GetAllAside");
            Command = new SqlCommand(query, Connection);

            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Aside aside = new Aside();

                    aside.Id = Convert.ToInt32(reader["Id"]);

                    aside.SectionId = Convert.ToInt32(reader["SectionId"]);
                    aside.OptionName = reader["OptionName"].ToString();
                    aside.Area = reader["Area"].ToString();
                    aside.Controller = reader["Controller"].ToString();
                    aside.Action = reader["Action"].ToString();
                    aside.Status = reader["Status"] == DBNull.Value ? false : Convert.ToBoolean(reader["Status"]);
                    aside.ParentId = Convert.ToInt32(reader["ParentId"]);
                    aside.IsParent = reader["IsParent"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsParent"]);
                    aside.HasChild = reader["HasChild"] == DBNull.Value ? false : Convert.ToBoolean(reader["HasChild"]);
                    aside.Icon = reader["Icon"].ToString();

                    aside.DateCreated = reader["DateCreated"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["DateCreated"]);
                    aside.DateUpdated = reader["DateUpdated"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["DateUpdated"]);

                    aside.CreatedByUserId = reader["CreatedByUserId"] == DBNull.Value ? null : reader["CreatedByUserId"].ToString();
                    aside.UpdatedByUserId = reader["UpdatedByUserId"] == DBNull.Value ? null : reader["UpdatedByUserId"].ToString();
                    aside.IsActive = reader["IsActive"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsActive"]);

                    asides.Add(aside);
                }
            }

            reader.Close();
            Connection.Close();
            return asides;

        }

        public Task<IEnumerable<Aside>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Aside GetById(int id)
        {
            using (Connection)
            {
                string query = ("Exec sp_GetAsideById '" + id + "'");
                Command = new SqlCommand(query, Connection);

                Connection.Open();

                SqlDataReader reader = Command.ExecuteReader();
                Aside aside = new Aside();

                while (reader.Read())
                {
                    aside.Id = Convert.ToInt32(reader["Id"]);

                    aside.SectionId = Convert.ToInt32(reader["SectionId"]);
                    aside.OptionName = reader["OptionName"].ToString();
                    aside.Area = reader["Area"].ToString();
                    aside.Controller = reader["Controller"].ToString();
                    aside.Action = reader["Action"].ToString();
                    aside.Status = reader["Status"] == DBNull.Value ? false : Convert.ToBoolean(reader["Status"]);
                    aside.ParentId = Convert.ToInt32(reader["ParentId"]);
                    aside.IsParent = reader["IsParent"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsParent"]);
                    aside.HasChild = reader["HasChild"] == DBNull.Value ? false : Convert.ToBoolean(reader["HasChild"]);
                    aside.Icon = reader["Icon"].ToString();

                    aside.DateCreated = reader["DateCreated"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["DateCreated"]);
                    aside.DateUpdated = reader["DateUpdated"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["DateUpdated"]);

                    aside.CreatedByUserId = reader["CreatedByUserId"] == DBNull.Value ? null : reader["CreatedByUserId"].ToString();
                    aside.UpdatedByUserId = reader["UpdatedByUserId"] == DBNull.Value ? null : reader["UpdatedByUserId"].ToString();

                    aside.IsActive = reader["IsActive"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsActive"]);

                }
                reader.Close();
                Connection.Close();

                return aside;
            }
        }

        public Task<Aside> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(Aside aside)
        {
            int result = 0;
            using (Connection)
            {
               string query = ("Exec sp_SaveAside '" + aside.SectionId + "','" + aside.OptionName + "','" + aside.Controller + "','" + aside.Action + "','" + aside.Area + "','" + aside.Status + "','" + aside.ParentId + "','" + aside.IsParent + "','" + aside.HasChild + "','" + aside.Icon + "','" + aside.DateCreated + "','" + aside.DateUpdated + "','" + aside.CreatedByUserId + "','" + aside.UpdatedByUserId + "','" + aside.IsActive + "'");

                Command = new SqlCommand(query, Connection);
                Connection.Open();

                result = Command.ExecuteNonQuery();

                Connection.Close();

                return 0;

                //if (result > 0)
                //{
                //    return "Aside Save Successsfully";
                //}
                //else
                //{
                //    return "Failed To Save Aside !!!!!";
                //}
            }
        }
        public bool IsExists(Aside viewModel)
        {
            int result = 0;
            using (Connection)
            {

                Command.Connection = Connection;

                Command.CommandText = "exce sp_UniqueCheckAside";
                Command.CommandType = CommandType.StoredProcedure;

                //Command.Parameters.AddWithValue("@ProductId", viewModel.ProductId);
                //Command.Parameters.AddWithValue("@ProductName", viewModel.ProductName);

                Connection.Open();
                result = (int)Command.ExecuteScalar();
                Connection.Close();
            }
            return result == -1;
        }
        public Task<int> InsertAsync(Aside aside)
        {
            throw new NotImplementedException();
        }

        public void Update(Aside aside)
        {
            int result = 0;
            using (Connection)
            {
                string query = ("Exec sp_UpdateAside '" + aside.SectionId + "','" + aside.OptionName + "','" + aside.Controller + "','" + aside.Action + "','" + aside.Area + "','" + aside.Status + "','" + aside.ParentId + "','" + aside.IsParent + "','" + aside.HasChild + "','" + aside.Icon + "','" + aside.DateCreated + "','" + aside.DateUpdated + "','" + aside.CreatedByUserId + "','" + aside.UpdatedByUserId + "','" + aside.IsActive + "'");
               
                Command = new SqlCommand(query, Connection);
                Connection.Open();

                result = Command.ExecuteNonQuery();

                Connection.Close();
            }
        }

        public Task UpdateAsync(Aside aside)
        {
            throw new NotImplementedException();
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


        public IEnumerable<Aside> GetAllAsideAndSection()
        {
            IList<Aside> asides = new List<Aside>();

            string query = ("Exec sp_GetAllAsideAndSection");
            Command = new SqlCommand(query, Connection);

            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    Aside aside = new Aside();

                    aside.Id = Convert.ToInt32(reader["Id"]);

                    aside.SectionId = Convert.ToInt32(reader["SectionId"]);
                    aside.OptionName = reader["OptionName"].ToString();
                    aside.Area = reader["Area"].ToString();
                    aside.Controller = reader["Controller"].ToString();
                    aside.Action = reader["Action"].ToString();
                    aside.Status = reader["Status"] == DBNull.Value ? false : Convert.ToBoolean(reader["Status"]);
                    aside.ParentId = Convert.ToInt32(reader["ParentId"]);
                    aside.IsParent = reader["IsParent"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsParent"]);
                    aside.HasChild = reader["HasChild"] == DBNull.Value ? false : Convert.ToBoolean(reader["HasChild"]);
                    aside.Icon = reader["Icon"].ToString();

                    aside.DateCreated = reader["DateCreated"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["DateCreated"]);
                    aside.DateUpdated = reader["DateUpdated"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["DateUpdated"]);

                    aside.CreatedByUserId = reader["CreatedByUserId"] == DBNull.Value ? null : reader["CreatedByUserId"].ToString();
                    aside.UpdatedByUserId = reader["UpdatedByUserId"] == DBNull.Value ? null : reader["UpdatedByUserId"].ToString();
                    aside.IsActive = reader["IsActive"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsActive"]);


                    asides.Add(aside);
                }
            }

            reader.Close();
            Connection.Close();
            return asides;

        }


    }
}
