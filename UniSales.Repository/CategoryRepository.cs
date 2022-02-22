using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniSales.Repository.Entity;

namespace UniSales.Repository
{
    public interface ICategoryRepository
    {
        void Create(Category cate);
        void Delete(int id);
        void Update(int id);
        Category Get(int Id);
        List<Category> GetCategory();
    }
    public class CategoryRepository : ICategoryRepository
    {
        public void Create(Category cate)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "LAPTOP-BTBN3PVI\\PHUONGNLT";
            builder.UserID = "sa";
            builder.Password = "12345phuong";
            builder.InitialCatalog = "ProductData";
            using (SqlConnection con = new SqlConnection(builder.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Insert into Category (Name,Description) values (@Name,@Description)", con);
                cmd.Parameters.AddWithValue("@Name", cate.Name);
                cmd.Parameters.AddWithValue("@Description", cate.Description);
                con.Open();
                cmd.ExecuteNonQuery(); //đang thực thi câu lệnh ko lấy dữ liệu ra -> insert, update, delete xài
                con.Close();
            }
        }

        public void Delete(int id)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "LAPTOP-BTBN3PVI\\PHUONGNLT";
            builder.UserID = "sa";
            builder.Password = "12345phuong";
            builder.InitialCatalog = "ProductData";
            using (SqlConnection con = new SqlConnection(builder.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Delete from Category where Id=@Id", con);
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                cmd.ExecuteNonQuery(); //đang thực thi câu lệnh ko lấy dữ liệu ra -> insert, update, delete xài
                con.Close();
            }
        }

        public Category Get(int Id)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "LAPTOP-BTBN3PVI\\PHUONGNLT";
            builder.UserID = "sa";
            builder.Password = "12345phuong";
            builder.InitialCatalog = "ProductData";
            List<Category> Category = new List<Category>();
            using (SqlConnection con = new SqlConnection(builder.ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * From Category Where Id=@Id", con);
                cmd.Parameters.AddWithValue("@Id", Id);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Category cate = new Category()
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Description = reader.GetString(3),
                    };
                    return cate;
                }
                con.Close();
                return null;
            }
        }
        public List<Category> GetCategory()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "LAPTOP-BTBN3PVI\\PHUONGNLT";
            builder.UserID = "sa";
            builder.Password = "12345phuong";
            builder.InitialCatalog = "ProductData";
            List<Category> category = new List<Category>();
            using (SqlConnection con = new SqlConnection(builder.ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * From Category", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Category cate = new Category()
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Description = reader.GetString(2),
                    };
                    category.Add(cate);
                }
                con.Close();
                return category;
            }
        }

        public void Update(int id)
        {
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "LAPTOP-BTBN3PVI\\PHUONGNLT";
                builder.UserID = "sa";
                builder.Password = "12345phuong";
                builder.InitialCatalog = "ProductData";
                using (SqlConnection con = new SqlConnection(builder.ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("Update Category set Name = @Name, Description = @Description where Id = @Id", con);
                    cmd.Parameters.AddWithValue("@Id", id);
                    con.Open();
                    cmd.ExecuteNonQuery(); //đang thực thi câu lệnh ko lấy dữ liệu ra -> insert, update, delete xài
                    con.Close();
                }
            }
        }
    }
}
