using ECommerce.Application.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Test.Application.Extensions
{
    [TestClass]
    public class XmlTest
    {
        [TestMethod]
        public void SerializeToXml_ShouldSerializeObjectToString()
        {
            // Arrange
            var sampleObject = new SampleObject { Id = 1, Name = "Test" };

            // Act
            var xmlString = sampleObject.SerializeToXml();

            // Assert
            Assert.IsNotNull(xmlString);
            Assert.IsFalse(string.IsNullOrEmpty(xmlString));
        }

        [TestMethod]
        public void DeserializeFromXml_ShouldDeserializeStringToObject()
        {
            // Arrange
            var xmlString = "<SampleObject><Id>1</Id><Name>Test</Name></SampleObject>";

            // Act
            var deserializedObject = xmlString.DeserializeFromXml<SampleObject>();

            // Assert
            Assert.IsNotNull(deserializedObject);
            Assert.AreEqual(1, deserializedObject.Id);
            Assert.AreEqual("Test", deserializedObject.Name);
        }
    }
}
