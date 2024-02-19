using ECommerce.Application.DTOs;
using ECommerce.Application.Validators;
using FluentValidation;
using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Test.Application.Validator
{
    [TestClass]
    public class ProductValidatorTests
    {
        [TestMethod]
        public void ProductValidator_ShouldHaveValidationErrors()
        {
            // Arrange
            var validator = new ProductValidator();
            var productDTO = new ProductDTO
            {
                // Set properties to intentionally violate validation rules
                ProductName = "sdfsdfs",
                CategoryID = Guid.NewGuid(),
                ProductDescription = "sdfsdf",
                ProductPicture = "ssss.png",
                Price = 145670.5d,
                Unit = 50,
                Stock = 60,
                Supplier = "sdfsdf",
                IsActive = true,
                ModifierID= Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                CreatorID= Guid.NewGuid(),
                ID= Guid.NewGuid(),
                ModifiedDate= DateTime.Now,
            };

            // Act
            var result = validator.Validate(productDTO);

            // Assert
            Assert.IsTrue(result.IsValid);
        }

        [TestMethod]
        public void ProductValidator_ShouldNotHaveValidationErrors()
        {
            // Arrange
            var validator = new ProductValidator();
            var productDTO = new ProductDTO
            {
                // Set properties to satisfy validation rules
                ProductName = "Valid Product",
                CategoryID = Guid.NewGuid(),
                ProductDescription = "Valid Description",
                ProductPicture = "valid.jpg",
                Price = 19.99d,
                Unit = 5,
                Stock = 100,
                Supplier = "Valid Supplier"
            };

            // Act
            var result = validator.TestValidate(productDTO);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.ProductName);
            result.ShouldNotHaveValidationErrorFor(x => x.CategoryID);
            result.ShouldNotHaveValidationErrorFor(x => x.ProductDescription);
            result.ShouldNotHaveValidationErrorFor(x => x.ProductPicture);
            result.ShouldNotHaveValidationErrorFor(x => x.Price);
            result.ShouldNotHaveValidationErrorFor(x => x.Unit);
            result.ShouldNotHaveValidationErrorFor(x => x.Stock);
            result.ShouldNotHaveValidationErrorFor(x => x.Supplier);
        }
    }
}
