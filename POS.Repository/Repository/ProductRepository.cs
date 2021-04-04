using POS.Data;
using POS.IRepository.Common;
using POS.IRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace POS.IRepository.Repository
{
    public class ProductRepository : CommonRepository, IProductRepository
    {
       
        public void Delete(Product product)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAll()
        { 
            using (Connection)
            {
                ICollection<Product> products = new Collection<Product>();

                Command.Connection = Connection;

                Command.CommandText = "sp_Get_All_Product";
                Command.CommandType = CommandType.StoredProcedure;


                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        Product product = new Product();

                        product.Id = Convert.ToInt32(reader["Id"]);
                        //product.ProductId = reader["ProductId"].ToString();
                        //product.ProductName = reader["ProductName"].ToString();
                        //product.ProductCategory = reader["ProductCategory"].ToString();
                        //product.ProductSubCategory = reader["ProductSubCategory"].ToString();
                        //product.CompanyName = reader["CompanyName"].ToString();
                        //product.Quantity = Convert.ToInt32(reader["Quantity"]);
                        //product.ProductPrice = (decimal)Convert.ToDouble(reader["ProductPrice"]);
                        //product.ProductSize = reader["ProductSize"].ToString();

                        product.DateCreated = reader["DateCreated"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["DateCreated"]);
                        product.DateUpdated = reader["DateUpdated"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["DateUpdated"]);

                        product.CreatedByUserId = reader["CreatedByUserId"] == DBNull.Value ? null : reader["CreatedByUserId"].ToString();
                        product.UpdatedByUserId = reader["UpdatedByUserId"] == DBNull.Value ? null : reader["UpdatedByUserId"].ToString();
                        product.IsActive = reader["IsActive"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsActive"]);

                        products.Add(product);
                    }
                }
    
                reader.Close();
                Connection.Close();
                return products;

            }

        }

        public Task<IEnumerable<Product>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Product GetById(int id)
        {
            using (Connection)
            {
                IList<Product> products = new List<Product>();
                Command.Connection = Connection;

                Command.CommandText = "sp_GetProductById";
                Command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameterId = new SqlParameter("@Id", id);
                Command.Parameters.Add(parameterId);
                Connection.Open();

                SqlDataReader reader = Command.ExecuteReader();
                Product product = new Product();

                while (reader.Read())
                {
                    product.Id = Convert.ToInt32(reader["Id"]);
                    //product.ProductId = reader["ProductId"].ToString();
                    //product.ProductName = reader["ProductName"].ToString();
                    //product.ProductCategory = reader["ProductCategory"].ToString();
                    //product.ProductSubCategory = reader["ProductSubCategory"].ToString();
                    //product.CompanyName = reader["CompanyName"].ToString();
                    //product.Quantity = Convert.ToInt32(reader["Quantity"]);
                    //product.ProductPrice = (decimal)Convert.ToDouble(reader["ProductPrice"]);
                    //product.ProductSize = reader["ProductSize"].ToString();

                    product.DateCreated = reader["DateCreated"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["DateCreated"]);
                    product.DateUpdated = reader["DateUpdated"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["DateUpdated"]);

                    product.CreatedByUserId = reader["CreatedByUserId"] == DBNull.Value ? null : reader["CreatedByUserId"].ToString();
                    product.UpdatedByUserId = reader["UpdatedByUserId"] == DBNull.Value ? null : reader["UpdatedByUserId"].ToString();

                    //product.IsActive = reader["IsActive"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsActive"]);

                    //products.Add(product);
                }
                reader.Close();
                Connection.Close();

                return product;
            }
        }

        public Task<Product> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(Product product)
        {
            int result = 0;
            using (Connection)
            {
                Command.Connection = Connection;

                Command.CommandText = "sp_SaveProduct";
                Command.CommandType = CommandType.StoredProcedure;

                //Command.Parameters.AddWithValue("@ProductId", product.ProductId);
                //Command.Parameters.AddWithValue("@ProductName", product.ProductName);
                //Command.Parameters.AddWithValue("@ProductCategory", product.ProductCategory);
                //Command.Parameters.AddWithValue("@ProductSubCategory", product.ProductSubCategory);
                //Command.Parameters.AddWithValue("@CompanyName", product.CompanyName);
                //Command.Parameters.AddWithValue("@Quantity", product.Quantity);
                //Command.Parameters.AddWithValue("@ProductPrice", product.ProductPrice);
                //Command.Parameters.AddWithValue("@ProductSize", product.ProductSize);
                Command.Parameters.AddWithValue("@DateCreated", product.DateCreated);
                Command.Parameters.AddWithValue("@DateUpdated", product.DateUpdated);
                Command.Parameters.AddWithValue("@CreatedByUserId", product.CreatedByUserId);
                Command.Parameters.AddWithValue("@UpdatedByUserId", product.UpdatedByUserId);
                Command.Parameters.AddWithValue("@IsActive", product.IsActive);

                Connection.Open();

                result = Command.ExecuteNonQuery();

                Connection.Close();

                return 0;

                //if (result > 0)
                //{
                //    return "Product Save Successsfully";
                //}
                //else
                //{
                //    return "Failed To Save Product !!!!!";
                //}
            }
        }
        public bool IsExists(Product viewModel)
        {

            int result = 0;
            using (Connection)
            {

                Command.Connection = Connection;

                Command.CommandText = "sp_checkUniqueProduct";
                Command.CommandType = CommandType.StoredProcedure;

                //Command.Parameters.AddWithValue("@ProductId", viewModel.ProductId);
                //Command.Parameters.AddWithValue("@ProductName", viewModel.ProductName);

                Connection.Open();
                result = (int)Command.ExecuteScalar();
                Connection.Close();
            }
            return result == -1;
        }
        public Task<int> InsertAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Product product)
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
