
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
    public class SectionRepository : CommonRepository, ISectionRepository
    {

        public void Delete(Section section)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Section> GetAll()
        { 
            //using (Connection)
            //{
                

            //}
            IList<Section> sections = new List<Section>();

            string query = ("Exec sp_GetAllSection");
            Command = new SqlCommand(query, Connection);

            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    Section section = new Section();

                    section.Id = Convert.ToInt32(reader["Id"]);

                    section.SectionTitle = reader["SectionTitle"].ToString();

                    section.DateCreated = reader["DateCreated"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["DateCreated"]);
                    section.DateUpdated = reader["DateUpdated"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["DateUpdated"]);

                    section.CreatedByUserId = reader["CreatedByUserId"] == DBNull.Value ? null : reader["CreatedByUserId"].ToString();
                    section.UpdatedByUserId = reader["UpdatedByUserId"] == DBNull.Value ? null : reader["UpdatedByUserId"].ToString();
                    section.IsActive = reader["IsActive"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsActive"]);

                    sections.Add(section);
                }
            }

            reader.Close();
            Connection.Close();
            return sections;

        }

        public Task<IEnumerable<Section>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Section GetById(int id)
        {
            using (Connection)
            {
                string query = ("Exec sp_SaveSection '" + id + "'");
                Command = new SqlCommand(query, Connection);

                Connection.Open();

                SqlDataReader reader = Command.ExecuteReader();
                Section section = new Section();

                while (reader.Read())
                {
                    section.Id = Convert.ToInt32(reader["Id"]);

                    section.SectionTitle = reader["SectionTitle"].ToString();

                    section.DateCreated = reader["DateCreated"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["DateCreated"]);
                    section.DateUpdated = reader["DateUpdated"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["DateUpdated"]);

                    section.CreatedByUserId = reader["CreatedByUserId"] == DBNull.Value ? null : reader["CreatedByUserId"].ToString();
                    section.UpdatedByUserId = reader["UpdatedByUserId"] == DBNull.Value ? null : reader["UpdatedByUserId"].ToString();

                    section.IsActive = reader["IsActive"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsActive"]);

                }
                reader.Close();
                Connection.Close();

                return section;
            }
        }

        public Task<Section> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(Section section)
        {
            int result = 0;
            using (Connection)
            {
                string query = ("Exec sp_SaveSection '" + section.SectionTitle + "','" + section.DateCreated + "','" + section.DateUpdated + "','" + section.CreatedByUserId + "','" + section.UpdatedByUserId + "','" + section.IsActive + "'");

                Command = new SqlCommand(query, Connection);
                Connection.Open();

                result = Command.ExecuteNonQuery();

                Connection.Close();

                return 0;

                //if (result > 0)
                //{
                //    return "Section Save Successsfully";
                //}
                //else
                //{
                //    return "Failed To Save Section !!!!!";
                //}
            }
        }
        public bool IsExists(Section viewModel)
        {

            int result = 0;
            using (Connection)
            {

                Command.Connection = Connection;

                Command.CommandText = "sp_UniqueCheckSection";
                Command.CommandType = CommandType.StoredProcedure;

                //Command.Parameters.AddWithValue("@ProductId", viewModel.ProductId);
                //Command.Parameters.AddWithValue("@ProductName", viewModel.ProductName);

                Connection.Open();
                result = (int)Command.ExecuteScalar();
                Connection.Close();
            }
            return result == -1;
        }
        public Task<int> InsertAsync(Section section)
        {
            throw new NotImplementedException();
        }

        public void Update(Section section)
        {
            int result = 0;
            using (Connection)
            {
                string query = ("Exec sp_UpdateSection '" + section.SectionTitle + "','" + section.DateCreated + "','" + section.DateUpdated + "','" + section.CreatedByUserId + "','" + section.UpdatedByUserId + "','" + section.IsActive + "'");

                Command = new SqlCommand(query, Connection);
                Connection.Open();

                result = Command.ExecuteNonQuery();

                Connection.Close();
            }
        }

        public Task UpdateAsync(Section section)
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

       
    }
}
