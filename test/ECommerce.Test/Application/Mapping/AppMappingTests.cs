using ECommerce.Application.DTOs;
using ECommerce.Application.Mapping;
using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Test.Application.Mapping
{
    [TestClass]
    public class AppMappingTests
    {
        [TestMethod]
        public void Mapping_ProductToProductDTO_ShouldMapCorrectly()
        {
            // Arrange
            var appMapping = new AppMapping();
            var product = new Product
            {
                ProductName = "TestProduct",
                CategoryID = Guid.NewGuid(),
                ProductDescription = "Test Description",
                ProductPicture = "test.jpg",
                Price = 19.99,
                Unit = 5,
                Stock = 100,
                Supplier = "Test Supplier",
                IsActive = true,
                CreatedDate = DateTime.Now,
                CreatorID = Guid.NewGuid()
            };

            // Act
            var productDTO = appMapping.Mapping<ProductDTO, Product>(product);

            // Assert
            Assert.AreEqual(product.ProductName, productDTO.ProductName);
            Assert.AreEqual(product.CategoryID, productDTO.CategoryID);
            Assert.AreEqual(product.ProductDescription, productDTO.ProductDescription);
            Assert.AreEqual(product.ProductPicture, productDTO.ProductPicture);
            Assert.AreEqual(product.Price, productDTO.Price);
            Assert.AreEqual(product.Unit, productDTO.Unit);
            Assert.AreEqual(product.Stock, productDTO.Stock);
            Assert.AreEqual(product.Supplier, productDTO.Supplier);
        }
    }

 
}
