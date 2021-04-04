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
    public class FinancialYearRepository : CommonRepository, IFinancialYearRepository
    {
        public void Delete(FinancialYear financialYear)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            string query = ("Exec sp_FinancialYearCRUD 'DELETE', '" + id + "'");

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

        public IEnumerable<FinancialYear> GetAll()
        {
            IList<FinancialYear> financialYears = new List<FinancialYear>();

            string query = ("Exec sp_FinancialYearCRUD 'SELECT'");
            Command = new SqlCommand(query, Connection);

            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    FinancialYear financialYear = new FinancialYear();

                    financialYear.Id = Convert.ToInt32(reader["Id"]);

                    financialYear.Name = reader["Name"].ToString();
                    financialYear.Description = reader["Description"].ToString();
                    financialYear.DateStart = Convert.ToDateTime(reader["DateStart"]);
                    financialYear.DateEnd = Convert.ToDateTime(reader["DateStart"]);


                    financialYear.DateCreated = reader["DateCreated"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["DateCreated"]);
                    financialYear.DateUpdated = reader["DateUpdated"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["DateUpdated"]);

                    financialYear.CreatedByUserId = reader["CreatedByUserId"] == DBNull.Value ? null : reader["CreatedByUserId"].ToString();
                    financialYear.UpdatedByUserId = reader["UpdatedByUserId"] == DBNull.Value ? null : reader["UpdatedByUserId"].ToString();
                    financialYear.IsActive = reader["IsActive"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsActive"]);

                    financialYears.Add(financialYear);
                }
            }

            reader.Close();
            Connection.Close();
            return financialYears;

        }

        public async Task<IEnumerable<FinancialYear>> GetAllAsync()
        {
            IList<FinancialYear> financialYears = new List<FinancialYear>();

            string query = ("Exec sp_FinancialYearCRUD 'SELECT'");
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();

            if (reader.HasRows)
            {
                while (await reader.ReadAsync())
                {
                    FinancialYear financialYear = new FinancialYear();

                    financialYear.Id = Convert.ToInt32(reader["Id"]);

                    financialYear.Name = reader["Name"].ToString();
                    financialYear.Description = reader["Description"].ToString();
                    financialYear.DateStart = Convert.ToDateTime(reader["DateStart"]);
                    financialYear.DateEnd = Convert.ToDateTime(reader["DateStart"]);

                    financialYear.DateCreated = reader["DateCreated"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["DateCreated"]);
                    financialYear.DateUpdated = reader["DateUpdated"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["DateUpdated"]);

                    financialYear.CreatedByUserId = reader["CreatedByUserId"] == DBNull.Value ? null : reader["CreatedByUserId"].ToString();
                    financialYear.UpdatedByUserId = reader["UpdatedByUserId"] == DBNull.Value ? null : reader["UpdatedByUserId"].ToString();
                    financialYear.IsActive = reader["IsActive"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsActive"]);

                    financialYears.Add(financialYear);
                }
            }
            reader.Close();
            Connection.Close();

            return financialYears;
        }

        public FinancialYear GetById(int id)
        {
            string query = ("Exec sp_FinancialYearCRUD 'SELECT', '" + id + "'");
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();

            FinancialYear financialYear = new FinancialYear();

            while (reader.Read())
            {
                financialYear.Id = Convert.ToInt32(reader["Id"]);

                financialYear.Name = reader["Name"].ToString();
                financialYear.Description = reader["Description"].ToString();
                financialYear.DateStart = Convert.ToDateTime(reader["DateStart"]);
                financialYear.DateEnd = Convert.ToDateTime(reader["DateStart"]);

                financialYear.DateCreated = reader["DateCreated"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["DateCreated"]);
                financialYear.DateUpdated = reader["DateUpdated"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["DateUpdated"]);

                financialYear.CreatedByUserId = reader["CreatedByUserId"] == DBNull.Value ? null : reader["CreatedByUserId"].ToString();
                financialYear.UpdatedByUserId = reader["UpdatedByUserId"] == DBNull.Value ? null : reader["UpdatedByUserId"].ToString();

                financialYear.IsActive = reader["IsActive"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsActive"]);
            }
            reader.Close();
            Connection.Close();

            return financialYear;
        }

        public async Task<FinancialYear> GetByIdAsync(int id)
        {
            string query = ("Exec sp_FinancialYearCRUD 'SELECT','" + id + "'");
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();

            FinancialYear financialYear = new FinancialYear();

            while (await reader.ReadAsync())
            {
                financialYear.Id = Convert.ToInt32(reader["Id"]);

                financialYear.Name = reader["Name"].ToString();
                financialYear.Description = reader["Description"].ToString();
                financialYear.DateStart = Convert.ToDateTime(reader["DateStart"]);
                financialYear.DateEnd = Convert.ToDateTime(reader["DateStart"]);

                financialYear.DateCreated = reader["DateCreated"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["DateCreated"]);
                financialYear.DateUpdated = reader["DateUpdated"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["DateUpdated"]);

                financialYear.CreatedByUserId = reader["CreatedByUserId"] == DBNull.Value ? null : reader["CreatedByUserId"].ToString();
                financialYear.UpdatedByUserId = reader["UpdatedByUserId"] == DBNull.Value ? null : reader["UpdatedByUserId"].ToString();

                financialYear.IsActive = reader["IsActive"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsActive"]);
            }
            reader.Close();
            Connection.Close();

            return financialYear;
        }

        public int Insert(FinancialYear financialYear)
        {
            int result = 0;
            string query = ("Exec sp_FinancialYearCRUD 'INSERT','" + financialYear.Id + "', '" + financialYear.Name + "','" + financialYear.Description + "','" + financialYear.DateStart + "','" + financialYear.DateEnd + "','" + financialYear.DateCreated + "','" + financialYear.DateUpdated + "','" + financialYear.CreatedByUserId + "','" + financialYear.UpdatedByUserId + "','" + financialYear.IsActive + "'");

            Command = new SqlCommand(query, Connection);
            Connection.Open();

            result = Command.ExecuteNonQuery();

            Connection.Close();

            return result;

            //if (result > 0)
            //{
            //    return "FinancialYear Save Successsfully";
            //}
            //else
            //{
            //    return "Failed To Save FinancialYear !!!!!";
            //}
        }
        public bool IsExists(FinancialYear financialYear)
        {
            int result = 0;
            string query = ("Exec sp_UniqueCheckCategory '" + financialYear.Name + "'");

            Command = new SqlCommand(query, Connection);
            Connection.Open();

            result = (int)Command.ExecuteScalar();
            Connection.Close();
            return result == -1;
        }
        public async Task<int> InsertAsync(FinancialYear financialYear)
        {
            int result = 0;
            string query = ("Exec sp_FinancialYearCRUD 'INSERT','" + financialYear.Id + "','" + financialYear.Name + "','" + financialYear.Description + "','" + financialYear.DateStart + "','" + financialYear.DateEnd + "','" + financialYear.DateCreated + "','" + financialYear.DateUpdated + "','" + financialYear.CreatedByUserId + "','" + financialYear.UpdatedByUserId + "','" + financialYear.IsActive + "'");
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            result = await Command.ExecuteNonQueryAsync();

            Connection.Close();

            return result;

            //if (result > 0)
            //{
            //    return "FinancialYear Save Successsfully";
            //}
            //else
            //{
            //    return "Failed To Save FinancialYear !!!!!";
            //}
        }

        public void Update(FinancialYear financialYear)
        {
            int result = 0;

            string query = ("Exec sp_FinancialYearCRUD 'UPDATE', '" + financialYear.Id + "','" + financialYear.Name + "','" + financialYear.Description + "','" + financialYear.DateStart + "','" + financialYear.DateEnd + "','" + financialYear.DateCreated + "','" + financialYear.DateUpdated + "','" + financialYear.CreatedByUserId + "','" + financialYear.UpdatedByUserId + "','" + financialYear.IsActive + "'");

            Command = new SqlCommand(query, Connection);
            Connection.Open();

            result = Command.ExecuteNonQuery();

            Connection.Close();
        }

        public async Task UpdateAsync(FinancialYear financialYear)
        {
            int result = 0;
            string query = ("Exec sp_FinancialYearCRUD 'UPDATE', '" + financialYear.Id + "'," + "'" + financialYear.Name + "','" + financialYear.Description + "','" + financialYear.DateStart + "','" + financialYear.DateEnd + "','" + financialYear.DateCreated + "'," + "'" + financialYear.DateUpdated + "'," + "'" + financialYear.CreatedByUserId + "'," + "'" + financialYear.UpdatedByUserId + "'," + "'" + financialYear.IsActive + "'");

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
