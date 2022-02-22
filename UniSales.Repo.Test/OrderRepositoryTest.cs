using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using UniSales.Repository;
using UniSales.Repository.Entity;

namespace UniSales.Repo.Test
{
    [TestClass]
    public class OrderRepositoryTest
    {
        [TestMethod]
        public void TestCreateOrder()
        {
            Order order = new Order()
            {
                CustomerName = "Phượng",
                Address = "240 NVL",
                CreateDate = new DateTime(2020, 02, 13),
                Status = 1
            };
            OrderRepository orderRepository = new OrderRepository();
            orderRepository.Create(order);

            //lấy danh sách các sản phẩm từ DB
            List<Order> orders = orderRepository.GetOrders();
            //lấy phần tử cuối cùng trong danh sách
            var lastOrder = orders[orders.Count - 1];
            Assert.AreEqual(order.CustomerName, lastOrder.CustomerName);
            Assert.AreEqual(order.Address, lastOrder.Address);
            Assert.AreEqual(order.CreateDate, lastOrder.CreateDate);
            Assert.AreEqual(order.Status, lastOrder.Status);
        }
        [TestMethod]
        public void TestGetOrder()
        {
            OrderRepository orderRepository = new OrderRepository();
            var ord = orderRepository.Get(1000);
            Assert.AreEqual(null, ord);
        }

        [TestMethod]
        public void TestGetOrders()
        {
            OrderRepository orderRepository = new OrderRepository();
            var ords = orderRepository.GetOrders();
            Order order = new Order()
            {
                CustomerName = "Tiên",
                Address = "Núi Bà Đen",
                CreateDate = new DateTime(2022, 02, 13),
                Status = 1
            };
            orderRepository.Create(order);
            var ords1 = orderRepository.GetOrders();

            Assert.AreEqual(ords1.Count, ords.Count + 1);
        }

        [TestMethod]
        public void TestUpdateOrder()
        {
            OrderRepository orderRepository = new OrderRepository();
            List<Order> ords = orderRepository.GetOrders();
            Order order = new Order()
            {
                CustomerName = "Quân",
                Address = "Vũng Tàu",
                CreateDate = new DateTime(2021, 02, 13),
                Status = 1
            };
            orderRepository.Update(order);
            Order getById = orderRepository.Get(2);

            Assert.AreEqual(order.CustomerName, getById.CustomerName);
            Assert.AreEqual(order.Address, getById.Address);
            Assert.AreEqual(order.CreateDate, getById.CreateDate);
            Assert.AreEqual(order.Status, getById.Status);
        }

        [TestMethod]
        public void TestDeleteOrder()
        {
            OrderRepository orderRepository = new OrderRepository();
            orderRepository.Delete(5);

            Assert.AreEqual(orderRepository.Get(5), null);
        }
    }
}
