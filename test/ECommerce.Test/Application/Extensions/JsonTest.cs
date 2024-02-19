using ECommerce.Application.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Test.Application.Extensions
{
    [TestClass]
    public class JsonTest
    {
        [TestMethod]
        public void SerializeToJson_ShouldSerializeObjectToString()
        {
            // Arrange
            var sampleObject = new SampleObject { Id = 1, Name = "Test" };

            // Act
            var jsonString = sampleObject.SerializeToJson();

            // Assert
            Assert.IsNotNull(jsonString);
            Assert.IsFalse(string.IsNullOrEmpty(jsonString));
        }

        [TestMethod]
        public void DeserializeFromJson_ShouldDeserializeStringToObject()
        {
            // Arrange
            var jsonString = "{\"Id\":1,\"Name\":\"Test\"}";

            // Act
            var deserializedObject = jsonString.DeserializeFromJson<SampleObject>();

            // Assert
            Assert.IsNotNull(deserializedObject);
            Assert.AreEqual(1, deserializedObject.Id);
            Assert.AreEqual("Test", deserializedObject.Name);
        }

        
    }
}
