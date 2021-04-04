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
    public class RoleBaseMenuPermissionRepository : CommonRepository, IRoleBaseMenuPermissionRepository
    {
        public IEnumerable<RoleBaseMenuPermission> GetAll()
        {
            IList<RoleBaseMenuPermission> roleBaseMenuPermissions = new List<RoleBaseMenuPermission>();

            string query = "Exec sp_RoleBaseMenuPermissionCRUD 'SELECT'";
            Command = new SqlCommand(query, Connection);

            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    RoleBaseMenuPermission roleBaseMenuPermission = new RoleBaseMenuPermission();

                    roleBaseMenuPermission.Id = Convert.ToInt32(reader["Id"]);

                    roleBaseMenuPermission.RoleId = reader["RoleId"].ToString();
                    roleBaseMenuPermission.AsideId = Convert.ToInt32(reader["AsideId"]);

                    roleBaseMenuPermission.DateCreated = reader["DateCreated"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["DateCreated"]);
                    roleBaseMenuPermission.DateUpdated = reader["DateUpdated"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["DateUpdated"]);

                    roleBaseMenuPermission.CreatedByUserId = reader["CreatedByUserId"] == DBNull.Value ? null : reader["CreatedByUserId"].ToString();
                    roleBaseMenuPermission.UpdatedByUserId = reader["UpdatedByUserId"] == DBNull.Value ? null : reader["UpdatedByUserId"].ToString();
                    roleBaseMenuPermission.IsActive = reader["IsActive"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsActive"]);

                    roleBaseMenuPermissions.Add(roleBaseMenuPermission);
                }
            }

            reader.Close();
            Connection.Close();
            return roleBaseMenuPermissions;

        }

        public async Task<IEnumerable<RoleBaseMenuPermission>> GetAllAsync()
        {
            IList<RoleBaseMenuPermission> roleBaseMenuPermissions = new List<RoleBaseMenuPermission>();

            string query = "Exec sp_RoleBaseMenuPermissionCRUD 'SELECT'";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();

            if (reader.HasRows)
            {
                while (await reader.ReadAsync())
                {
                    RoleBaseMenuPermission roleBaseMenuPermission = new RoleBaseMenuPermission();

                    roleBaseMenuPermission.Id = Convert.ToInt32(reader["Id"]);

                    roleBaseMenuPermission.RoleId = reader["RoleId"].ToString();
                    roleBaseMenuPermission.AsideId = Convert.ToInt32(reader["AsideId"]);

                    roleBaseMenuPermission.DateCreated = reader["DateCreated"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["DateCreated"]);
                    roleBaseMenuPermission.DateUpdated = reader["DateUpdated"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["DateUpdated"]);

                    roleBaseMenuPermission.CreatedByUserId = reader["CreatedByUserId"] == DBNull.Value ? null : reader["CreatedByUserId"].ToString();
                    roleBaseMenuPermission.UpdatedByUserId = reader["UpdatedByUserId"] == DBNull.Value ? null : reader["UpdatedByUserId"].ToString();
                    roleBaseMenuPermission.IsActive = reader["IsActive"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsActive"]);

                    roleBaseMenuPermissions.Add(roleBaseMenuPermission);
                }
            }
            reader.Close();
            Connection.Close();

            return roleBaseMenuPermissions;
        }

        public int Insert(RoleBaseMenuPermission roleBaseMenuPermission)
        {
            int result = 0;
            string query = "Exec sp_RoleBaseMenuPermissionCRUD 'INSERT','" + roleBaseMenuPermission.Id + "','" + roleBaseMenuPermission.RoleId + "','" + roleBaseMenuPermission.AsideId + "','" + roleBaseMenuPermission.DateCreated + "','" + roleBaseMenuPermission.DateUpdated + "','" + roleBaseMenuPermission.CreatedByUserId + "','" + roleBaseMenuPermission.UpdatedByUserId + "','" + roleBaseMenuPermission.IsActive + "'";

            Command = new SqlCommand(query, Connection);
            Connection.Open();

            result = Command.ExecuteNonQuery();

            Connection.Close();

            return result;

            //if (result > 0)
            //{
            //    return "RoleBaseMenuPermission Save Successsfully";
            //}
            //else
            //{
            //    return "Failed To Save RoleBaseMenuPermission !!!!!";
            //}
        }
       
        public async Task<int> InsertAsync(RoleBaseMenuPermission roleBaseMenuPermission)
        {
            int result = 0;
            string query = "Exec sp_RoleBaseMenuPermissionCRUD 'INSERT','" + roleBaseMenuPermission.Id + "','" + roleBaseMenuPermission.RoleId + "','" + roleBaseMenuPermission.AsideId + "','" + roleBaseMenuPermission.DateCreated + "','" + roleBaseMenuPermission.DateUpdated + "','" + roleBaseMenuPermission.CreatedByUserId + "','" + roleBaseMenuPermission.UpdatedByUserId + "','" + roleBaseMenuPermission.IsActive + "'";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            result = await Command.ExecuteNonQueryAsync();

            Connection.Close();

            return result;

            //if (result > 0)
            //{
            //    return "RoleBaseMenuPermission Save Successsfully";
            //}
            //else
            //{
            //    return "Failed To Save RoleBaseMenuPermission !!!!!";
            //}
        }

        public void Update(RoleBaseMenuPermission roleBaseMenuPermission)
        {
            int result = 0;

            string query = "Exec sp_RoleBaseMenuPermissionCRUD 'UPDATE', '" + roleBaseMenuPermission.Id + "','" + roleBaseMenuPermission.RoleId + "','" + roleBaseMenuPermission.AsideId + "','" + roleBaseMenuPermission.DateCreated + "','" + roleBaseMenuPermission.DateUpdated + "','" + roleBaseMenuPermission.CreatedByUserId + "','" + roleBaseMenuPermission.UpdatedByUserId + "','" + roleBaseMenuPermission.IsActive + "'";

            Command = new SqlCommand(query, Connection);
            Connection.Open();

            result = Command.ExecuteNonQuery();

            Connection.Close();
        }

        public async Task UpdateAsync(RoleBaseMenuPermission roleBaseMenuPermission)
        {
            int result = 0;
            string query = "Exec sp_RoleBaseMenuPermissionCRUD 'UPDATE', '" + roleBaseMenuPermission.Id + "','" + roleBaseMenuPermission.RoleId + "','" + roleBaseMenuPermission.AsideId + "','" + roleBaseMenuPermission.DateCreated + "','" + roleBaseMenuPermission.DateUpdated + "','" + roleBaseMenuPermission.CreatedByUserId + "','" + roleBaseMenuPermission.UpdatedByUserId + "','" + roleBaseMenuPermission.IsActive + "'";

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
