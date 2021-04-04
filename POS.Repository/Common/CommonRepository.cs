using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace POS.IRepository.Common
{
    public class CommonRepository
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public SqlConnection Connection { set; get; }
        public SqlCommand Command { set; get; }
        public SqlDataReader Reader { set; get; }
        public string Query { set; get; }

        public CommonRepository()
        {
            Connection = new SqlConnection(connectionString);
            Command = new SqlCommand();
        }
    }
}
