using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniSales.Repository.Entity;

namespace UniSales.Repository
{
    public interface IOrderRepository
    {
        void Create(Order order);
        void Delete(int id);
        void Update(Order order);
        Order Get(int id);
        List<Order> GetOrders();
    }
    public class OrderRepository : IOrderRepository
    {
        public void Create(Order order)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "LAPTOP-BTBN3PVI\\PHUONGNLT";
            builder.UserID = "sa";
            builder.Password = "12345phuong";
            builder.InitialCatalog = "ProductData";
            using (SqlConnection con = new SqlConnection(builder.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Insert into [dbo].[Order] (CustomerName,Address,CreateDate,Status) values (@CustomerName,@Address,@CreateDate,@Status)", con);
                cmd.Parameters.AddWithValue("@CustomerName", order.CustomerName);
                cmd.Parameters.AddWithValue("@Address", order.Address);
                cmd.Parameters.AddWithValue("@CreateDate", order.CreateDate);
                cmd.Parameters.AddWithValue("@Status", order.Status);
                con.Open();
                cmd.ExecuteNonQuery();
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
                SqlCommand cmd = new SqlCommand("Delete from [dbo].[Order] where Id=@Id", con);
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                cmd.ExecuteNonQuery(); //đang thực thi câu lệnh ko lấy dữ liệu ra -> insert, update, delete xài
                con.Close();
            }
        }

        public Order Get(int id)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "LAPTOP-BTBN3PVI\\PHUONGNLT";
            builder.UserID = "sa";
            builder.Password = "12345phuong";
            builder.InitialCatalog = "ProductData";
            List<Order> orders = new List<Order>();
            using (SqlConnection con = new SqlConnection(builder.ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * From [dbo].[Order] Where Id=@Id", con);
                cmd.Parameters.AddWithValue("@Id", id);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Order order = new Order()
                    {
                        Id = reader.GetInt32(0),
                        CustomerName = reader.GetString(1),
                        Address = reader.GetString(2),
                        CreateDate = reader.GetDateTime(3),
                        Status = reader.GetInt32(4)
                    };
                    return order;
                }
                con.Close();
                return null;
            }
        }

        public List<Order> GetOrders()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "LAPTOP-BTBN3PVI\\PHUONGNLT";
            builder.UserID = "sa";
            builder.Password = "12345phuong";
            builder.InitialCatalog = "ProductData";
            List<Order> orders = new List<Order>();
            using (SqlConnection con = new SqlConnection(builder.ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * From [dbo].[Order]", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Order ord = new Order()
                    {
                        Id = reader.GetInt32(0),
                        CustomerName = reader.GetString(1),
                        Address = reader.GetString(2),
                        CreateDate = reader.GetDateTime(3),
                        Status = reader.GetInt32(4)
                    };
                    orders.Add(ord);
                }
                con.Close();
                return orders;
            }
        }

        public void Update(Order order)
        {
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "LAPTOP-BTBN3PVI\\PHUONGNLT";
                builder.UserID = "sa";
                builder.Password = "12345phuong";
                builder.InitialCatalog = "ProductData";
                using (SqlConnection con = new SqlConnection(builder.ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("Update [dbo].[Order] set CustomerName=@CustomerName,Address=@Address,CreateDate=@CreateDate,Status=@Status where Id=2", con);
                    cmd.Parameters.AddWithValue("@CustomerName", order.CustomerName);
                    cmd.Parameters.AddWithValue("@Address", order.Address);
                    cmd.Parameters.AddWithValue("@CreateDate", order.CreateDate);
                    cmd.Parameters.AddWithValue("@Status", order.Status);
                    con.Open();
                    cmd.ExecuteNonQuery(); //đang thực thi câu lệnh ko lấy dữ liệu ra -> insert, update, delete xài
                    con.Close();
                }
            }
        }
    }
}
