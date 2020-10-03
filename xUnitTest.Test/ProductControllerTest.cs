using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using xUnitTest.Controllers;
using xUnitTest.Models.Repository;

namespace xUnitTest.Test
{
    public class ProductControllerTest
    {
        private readonly Mock<IRepository<Product>> _mockRepo;
        private readonly ProductsController _productsController;
        private List<Product> products;
        public static IEnumerable<object[]> Guids
        {
            get
            {
                yield return new object[] { "ba2a2479-d174-47a5-8f87-7d1bd5a01c78" };
            }
        }
        public ProductControllerTest()
        {
            _mockRepo = new Mock<IRepository<Product>>();
            _productsController = new ProductsController(_mockRepo.Object);

            products = new List<Product>() {
                new Product() { Id = new Guid("ba2a2479-d174-47a5-8f87-7d1bd5a01c78"), Name = "UnitTest 2", Price = 200, Stock = 1 },
                new  Product(){ Id=Guid.NewGuid(),Name="UnitTest 3",Price=300,Stock=5}
            };
        }

        [Fact]
        public async void Index_ActionExecutes_ReturnView()
        {
            var result = await _productsController.Index();

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async void Index_ActionExecutes_ReturnProductList()
        {
            _mockRepo.Setup(repo => repo.GetAll()).ReturnsAsync(products);

            var result = await _productsController.Index();

            var viewResult = Assert.IsType<ViewResult>(result);

            var productList = Assert.IsAssignableFrom<IEnumerable<Product>>(viewResult.Model);

            Assert.Equal<int>(2, productList.Count());
        }
        [Theory]
        [InlineData(null)]
        public async void Details_IdIsNull_ReturnRedirectToAction(Guid? id)
        {
            var result = _productsController.Details(id);

            var redirect = Assert.IsType<RedirectToActionResult>(result.Result);

            Assert.Equal("Index", redirect.ActionName);
        }

        [Theory, MemberData(nameof(Guids))]
        public async void Details_IdIsNull_ReturnNotFound(string id)
        {
            Guid paramId = new Guid(id);

            Product product = products.Where(c => c.Id == paramId).FirstOrDefault();

            _mockRepo.Setup(repo => repo.GetById(paramId)).ReturnsAsync(product);

            var result = _productsController.Details(paramId);
            var viewResult = Assert.IsType<ViewResult>(result.Result);

            Assert.NotNull(viewResult);
            Assert.NotNull(viewResult.Model);
            Assert.IsType<Product>(viewResult.Model);

            var resultProduct = Assert.IsAssignableFrom<Product>(viewResult.Model);

            Assert.Equal(product, resultProduct);
        }

        [Fact]
        public void Create_ActionExecuties_ReturnView()
        {
            var result = _productsController.Create();

            Assert.IsType<ViewResult>(result);
        }

    }
}
