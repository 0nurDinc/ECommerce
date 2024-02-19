using ECommerce.Application.Interfaces.UnitOfWork;
using ECommerce.Domain.Entities;
using ECommerce.Persistence.UnitOfWorks;
using ECommerce.Security.Token;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Test.Security
{
    [TestClass]
    internal class JwtCustomerAuthenticationServiceTests
    {
        private JwtCustomerAuthenticationService _authenticationService;
        private IUnitOfWork _unitOfWork; // Gerçek veritabanına erişim sağlayacak nesne

        [TestInitialize]
        public void Setup()
        {
            // InMemoryDatabase ile test veritabanını oluştur
            _unitOfWork = new UnitOfWork();

            // Diğer servis ve konfigürasyon nesnelerini oluştur
            var hashHelper = new HashHelper();
            var configuration = new ConfigurationBuilder().Build();

            // JwtCustomerAuthenticationService'ı oluştur ve gerçek veritabanını enjekte et
            _authenticationService = new JwtCustomerAuthenticationService(hashHelper, _unitOfWork, configuration);
        }

        [TestMethod]
        public async Task Authenticate_ValidUser_ReturnsToken()
        {
            // Arrange
            var username = "test@example.com";
            var password = "testpassword";

            // Gerçek veritabanına eklenmiş bir müşteri ve giriş bilgileri
            var user = new Customer { ID = Guid.NewGuid(), EmailAddress = username, FirstName = "John", LastName = "Doe" };
            var userLogin = new CustomerLogin { PersonID = user.ID, Password = new byte[32], Salt = new byte[16] };

            // Gerçek veritabanına müşteri ve giriş bilgilerini ekle
             _unitOfWork.CustomerRepository.AddEntity(user);
             _unitOfWork.CustomerLoginRepository.
                AddEntity(userLogin);

            // Act
            var token = await _authenticationService.Authenticate(username, password);

            // Assert
            Assert.IsNotNull(token);
            // Diğer assert'leri uygulamanıza göre ekleyin
        }

        [TestMethod]
        public async Task Authenticate_InvalidUser_ReturnsNull()
        {
            // Arrange
            var username = "nonexistent@example.com";
            var password = "testpassword";

            // Act
            var token = await _authenticationService.Authenticate(username, password);

            // Assert
            Assert.IsNull(token);
        }

    }
}
