using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using UniSales.Repository;
using UniSales.Repository.Entity;

namespace UniSales.Repo.Test
{
    [TestClass]
    public class ProductRepositoryTest
    {
        [TestMethod]
        public void TestCreate()
        {
            Product product = new Product()
            {
                Name = "Cơm bì chả",
                Price = 10000,
                Description = "Quá đã",
                Status = 1,
                CatId = 1
            };
            ProductRepository productRepository = new ProductRepository();
            productRepository.Create(product);

            //lấy danh sách các sản phẩm từ DB
            List<Product> products = productRepository.GetProducts();
            //lấy phần tử cuối cùng trong danh sách
            var lastProduct = products[products.Count - 1];
            Assert.AreEqual(product.Name, lastProduct.Name);
            Assert.AreEqual(product.Price, lastProduct.Price);
            Assert.AreEqual(product.Description, lastProduct.Description);
            Assert.AreEqual(product.Status, lastProduct.Status);
            Assert.AreEqual(product.CatId, lastProduct.CatId);
        }
        [TestMethod]
        public void TestGet()
        {
            ProductRepository productRepository = new ProductRepository();
            var pro = productRepository.Get(1000);
            Assert.AreEqual(null, pro);
        }

        [TestMethod]
        public void TestGetProducts()
        {
            ProductRepository productRepository = new ProductRepository();
            var products = productRepository.GetProducts();
            Product product = new Product()
            {
                Name = "Cafe trứng",
                Price = 10000,
                Description = "Siu best",
                Status = 1,
                CatId = 1
            };
            productRepository.Create(product);
            var products1 = productRepository.GetProducts();

            Assert.AreEqual(products1.Count, products.Count + 1);
        }

        [TestMethod]
        public void TestUpdate()
        {
            ProductRepository productRepository = new ProductRepository();
            List<Product> products = productRepository.GetProducts();
            Product product = new Product()
            {
                Name = "Hủ tiếu",
                Price = 30000,
                Description = "Miền Tây sông nước",
                Status = 1,
                CatId = 1
            };
            productRepository.Update(product);
            Product getById = productRepository.Get(2);

            Assert.AreEqual(product.Name, getById.Name);
            Assert.AreEqual(product.Price, getById.Price);
            Assert.AreEqual(product.Description, getById.Description);
            Assert.AreEqual(product.Status, getById.Status);
            Assert.AreEqual(product.CatId, getById.CatId);
        }

        [TestMethod]
        public void TestDelete()
        {
            ProductRepository productRepository = new ProductRepository();
            productRepository.Delete(productRepository.Get(5));

            Assert.AreEqual(productRepository.Get(5), null);
        }
    }
}
