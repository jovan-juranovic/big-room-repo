using BigRoom.BusinessLayer.Interfaces;
using BigRoom.Model;
using BigRoom.Service.Controllers.API;
using BigRoom.Service.Models.ProductVms;
using NSubstitute;
using NUnit.Framework;

namespace BigRoom.Tests
{
    [TestFixture]
    public class ProductsControllerTests
    {
        [Test]
        public void GetProducts_WhenCalled_ReturnsProduct()
        {
            // Arrange
            const int id = 1;
            Product product = new Product
            {
                Id = 1,
                Name = "TestProduct"
            };
            IProductService fakeProductService = Substitute.For<IProductService>();
            IProductReviewService fakeProductReviewService = Substitute.For<IProductReviewService>();
            fakeProductService.FindProduct(id).Returns(product);

            //Act
            ProductsController productsController = new ProductsController(fakeProductService, fakeProductReviewService);
            ProductVM result = productsController.Get(id);

            //Assert
            Assert.IsNotNull(result);
        }
    }
}
