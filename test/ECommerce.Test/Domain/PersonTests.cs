using ECommerce.Domain.EntitesDataAttribute;
using ECommerce.Domain.EntitesException;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Test.Domain
{
    [TestClass]
    public  class PersonTests
    {

        [TestMethod]
        public void Person_AgeExceptionThrownWhenUnder18()
        {
            // Arrange
            var person = new Employee();

            // Act & Assert
            var ex = Assert.ThrowsException<AgeException>(() => person.BirthOfDate = DateTime.Now.AddYears(-17));

           
        }

        [TestMethod]
        public void TurkeyPhoneAttribute_ValidPhoneNumber_ReturnsTrue()
        {
            // Arrange
            var turkeyPhoneAttribute = new TurkeyPhoneAttribute();

            // Act
            var isValid = turkeyPhoneAttribute.IsValid("05321234567");

            // Assert
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void TurkeyPhoneAttribute_InvalidPhoneNumber_ReturnsFalse()
        {
            // Arrange
            var turkeyPhoneAttribute = new TurkeyPhoneAttribute();

            // Act
            var isValid = turkeyPhoneAttribute.IsValid("1234567890");

            // Assert
            Assert.IsFalse(isValid);
        }
    }
}
