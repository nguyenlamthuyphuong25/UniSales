using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniSales.Repository.Entity;

namespace UniSales.Repository
{   
    public interface IProductRepository
    {
        void Create(Product product);
        void Delete(Product product);
        void Update(Product product);
        Product Get(int Id);
        List<Product> GetProducts();
    }
    public class ProductRepository: IProductRepository
    {
        public void Create(Product product)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "LAPTOP-BTBN3PVI\\PHUONGNLT";
            builder.UserID = "sa";
            builder.Password = "12345phuong";
            builder.InitialCatalog = "ProductData";
            using (SqlConnection con = new SqlConnection(builder.ConnectionString))
            {
                
                SqlCommand cmd = new SqlCommand("Insert into Product (Name,Price,Description,Status,CatId) values (@Name,@Price,@Description,@Status,@CatId)", con);
                cmd.Parameters.AddWithValue("@Name", product.Name);
                cmd.Parameters.AddWithValue("@Price", product.Price);
                cmd.Parameters.AddWithValue("@Description", product.Description);
                cmd.Parameters.AddWithValue("@Status", product.Status);
                cmd.Parameters.AddWithValue("@CatId", product.CatId);
                con.Open();
                cmd.ExecuteNonQuery(); //đang thực thi câu lệnh ko lấy dữ liệu ra -> insert, update, delete xài
                con.Close();
            }
        }


            public void Delete(Product product)
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "LAPTOP-BTBN3PVI\\PHUONGNLT";
                builder.UserID = "sa";
                builder.Password = "12345phuong";
                builder.InitialCatalog = "ProductData";
                using (SqlConnection con = new SqlConnection(builder.ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("Delete from Product where Id=5", con);
                    con.Open();
                    cmd.ExecuteNonQuery(); //đang thực thi câu lệnh ko lấy dữ liệu ra -> insert, update, delete xài
                    con.Close();
                }
        }

            public Product Get(int Id)
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "LAPTOP-BTBN3PVI\\PHUONGNLT";
                builder.UserID = "sa";
                builder.Password = "12345phuong";
                builder.InitialCatalog = "ProductData";
                List<Product> products = new List<Product>();
                using (SqlConnection con = new SqlConnection(builder.ConnectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Select * FROM Product where Id=@Id", con);
                    cmd.Parameters.AddWithValue("Id", Id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Product pro = new Product()
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Price = reader.GetInt32(2),
                            Description = reader.GetString(3),
                            Status = reader.GetInt32(4),
                            CatId = reader.GetInt32(5)
                        };
                        return pro;
                    }
                    con.Close();
                    return null;
                }
            }

        public List<Product> GetProducts()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "LAPTOP-BTBN3PVI\\PHUONGNLT";
            builder.UserID = "sa";
            builder.Password = "12345phuong";
            builder.InitialCatalog = "ProductData";
            List<Product> products = new List<Product>();
            using (SqlConnection con = new SqlConnection(builder.ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * From Product", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Product pro = new Product()
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Price = reader.GetInt32(2),
                        Description = reader.GetString(3),
                        Status = reader.GetInt32(4),
                        CatId = reader.GetInt32(5)
                    };
                    products.Add(pro);
                }
                con.Close();
                return products;
            }
        }

        public void Update(Product product)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "LAPTOP-BTBN3PVI\\PHUONGNLT";
            builder.UserID = "sa";
            builder.Password = "12345phuong";
            builder.InitialCatalog = "ProductData";
            using (SqlConnection con = new SqlConnection(builder.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Update Product set Name=@Name,Price=@Price,Description=@Description,Status=@Status,CatId=@CatId where Id=2", con);
                cmd.Parameters.AddWithValue("@Name", product.Name);
                cmd.Parameters.AddWithValue("@Price", product.Price);
                cmd.Parameters.AddWithValue("@Description", product.Description);
                cmd.Parameters.AddWithValue("@Status", product.Status);
                cmd.Parameters.AddWithValue("@CatId", product.CatId);
                con.Open();
                cmd.ExecuteNonQuery(); //đang thực thi câu lệnh ko lấy dữ liệu ra -> insert, update, delete xài
                con.Close();
            }
        }
    }
}
