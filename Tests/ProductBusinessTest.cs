using NUnit.Framework;
using Shop.API.Business;
using Shop.API.Models;
using Moq;
using System.Threading.Tasks;

namespace Tests
{
    class ProductTests
    {
        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public async Task CreateANewProduct()
        {
            var item = new Product()
            {
                CategoryId = 1,
                Description = null,
                StockId = 1,
                Name = "Bermuda",
                Price = 33.15M,
                Sku = "mmonwa",
                Category = null,
                Stock = null

            };

            var mockBusiness = new Mock<IProductBusiness>();

            mockBusiness.Setup(business => business.CreateProduct(It.IsAny<Product>()))
                .Returns(Task.FromResult(item));
            var result = await mockBusiness.Object.CreateProduct(item);
            Assert.IsNotNull(result);
            Assert.AreEqual(item, result);

        }

        [Test]
        public void AddTwoProductsWithTheSameName()
        {
            var item1 = new Product()
            {
                CategoryId = 1,
                Description = null,
                StockId = 1,
                Name = "Bermuda",
                Price = 33.15M,
                Sku = "mmonwa",
                Category = null,
                Stock = null

            };

            var item2 = new Product()
            {
                CategoryId = 1,
                Description = null,
                StockId = 1,
                Name = "Bermuda",
                Price = 33.15M,
                Sku = "mmonwa",
                Category = null,
                Stock = null

            };

            var mockBusiness = new Mock<IProductBusiness>();
            var result1 = mockBusiness.Object.CreateProduct(item1);
            var result2 = mockBusiness.Object.CreateProduct(item2);
            Assert.Pass();

        }
    }
}