using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniSales.Repository.Entity;

namespace UniSales.Repository
{
    public interface IOrderDetailRepository
    {
        void Create(OrderDetail orderDetail);
        void Delete(int id);
        void Update(int id);
        OrderDetail Get(int id);
        List<OrderDetail> GetOrderDetails();
    }
    public class OderDetailRepository : IOrderDetailRepository
    {
        public void Create(OrderDetail orderDetail)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "LAPTOP-BTBN3PVI\\PHUONGNLT";
            builder.UserID = "sa";
            builder.Password = "12345phuong";
            builder.InitialCatalog = "ProductData";
            using (SqlConnection con = new SqlConnection(builder.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("Insert into OrderDetail (ProductId,OrderId,Price,Quantity) values (@ProductId,@OrderId,@Price,@Quantity)", con);
                cmd.Parameters.AddWithValue("@ProductId", orderDetail.ProductId);
                cmd.Parameters.AddWithValue("@OrderId", orderDetail.OrderId);
                cmd.Parameters.AddWithValue("@Price", orderDetail.Price);
                cmd.Parameters.AddWithValue("@Quantity", orderDetail.Quantity);

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
                SqlCommand cmd = new SqlCommand("Delete from OrderDetail where Id=@Id", con);
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                cmd.ExecuteNonQuery(); //đang thực thi câu lệnh ko lấy dữ liệu ra -> insert, update, delete xài
                con.Close();
            }
        }

        public OrderDetail Get(int id)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "LAPTOP-BTBN3PVI\\PHUONGNLT";
            builder.UserID = "sa";
            builder.Password = "12345phuong";
            builder.InitialCatalog = "ProductData";
            List<OrderDetail> orders = new List<OrderDetail>();
            using (SqlConnection con = new SqlConnection(builder.ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * From OrderDetail Where Id=@Id", con);
                cmd.Parameters.AddWithValue("@Id", id);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OrderDetail orderDetail = new OrderDetail()
                    {
                        Id = reader.GetInt32(0),
                        ProductId = reader.GetInt32(1),
                        OrderId = reader.GetInt32(2),
                        Price = reader.GetInt32(3),
                        Quantity = reader.GetInt32(4)
                    };
                    return orderDetail;
                }
                con.Close();
                return null;
            }
        }

        public List<OrderDetail> GetOrderDetails()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "LAPTOP-BTBN3PVI\\PHUONGNLT";
            builder.UserID = "sa";
            builder.Password = "12345phuong";
            builder.InitialCatalog = "ProductData";
            List<OrderDetail> orderDetails = new List<OrderDetail>();
            using (SqlConnection con = new SqlConnection(builder.ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * From OrderDetail", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OrderDetail orderDetail = new OrderDetail()
                    {
                        Id = reader.GetInt32(0),
                        ProductId = reader.GetInt32(1),
                        OrderId = reader.GetInt32(2),
                        Price = reader.GetInt32(3),
                        Quantity = reader.GetInt32(4)
                    };
                    orderDetails.Add(orderDetail);
                }
                con.Close();
                return orderDetails;
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
                    SqlCommand cmd = new SqlCommand("Update OrderDetail set ProductId=@ProductId,OrderId=@OrderId,Price=@Price,Quantity=@Quantity where Id = @Id", con);
                    cmd.Parameters.AddWithValue("@Id", id);
                    con.Open();
                    cmd.ExecuteNonQuery(); //đang thực thi câu lệnh ko lấy dữ liệu ra -> insert, update, delete xài
                    con.Close();
                }
            }
        }
    }
}
