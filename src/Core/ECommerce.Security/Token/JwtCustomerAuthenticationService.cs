using ECommerce.Application.Interfaces.Repository;
using ECommerce.Application.Interfaces.Security;
using ECommerce.Application.Interfaces.UnitOfWork;
using ECommerce.Application.ViewModels;
using ECommerce.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Security.Token
{
    public class JwtCustomerAuthenticationService : IJwtAuthenticationService
    {
        private readonly IHashHelper _hashHelper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        public JwtCustomerAuthenticationService(IHashHelper hashHelper, IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _hashHelper = hashHelper;
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        public async Task<string> Authenticate(string username, string password)
        {
            var user = await _unitOfWork.CustomerRepository.GetFilterByCondition(x => x.EmailAddress.ToLower() == x.EmailAddress.ToLower());
            if (user is null)
                return null;

            var userLogin = await _unitOfWork.CustomerLoginRepository.GetFilterByCondition(x => x.PersonID == user.ID);

            if (_hashHelper.IsValidPassword(password, userLogin.Password, userLogin.Salt))
            {
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name,user.FirstName+" "+user.LastName),
                    new Claim(ClaimTypes.NameIdentifier,user.ID.ToString())
                };

                var token = new JwtSecurityToken(
                    issuer: _configuration["Jwt:Issuer"],
                    audience: _configuration["Jwt:Audience"],
                    claims: claims,
                    expires: DateTime.UtcNow.AddHours(Convert.ToDouble(_configuration["Jwt:ExpirationHours"])),
                    signingCredentials: credentials);

                var tokenHandler = new JwtSecurityTokenHandler();
                return tokenHandler.WriteToken(token);
            }

            return null;
        }


        public async Task<bool> Register(UserRegisterVM userRegisterVM)
        {
            bool status = false;

            if (await _unitOfWork.CustomerRepository.GetFilterByCondition(x => x.EmailAddress.ToUpper() == userRegisterVM.EmailAddress.ToUpper()) is null)
                return false;

            byte[] salt = _hashHelper.GenerateSalt();
            byte[] passwordHash = _hashHelper.HashPassword(userRegisterVM.Password, salt);

            _unitOfWork.BeginTransaction();

            try
            {

                var personelID = Guid.NewGuid();

                _unitOfWork.CustomerRepository.AddEntity(new Customer()
                {
                    ID = personelID,
                    FirstName = userRegisterVM.FirstName,
                    LastName = userRegisterVM.LastName,
                    EmailAddress = userRegisterVM.EmailAddress,
                    BirthOfDate = userRegisterVM.BirthOfDate,
                    PhoneNumber = userRegisterVM.PhoneNumber,
                    CreatedDate = DateTime.Now,
                    CreatorID = personelID,
                    IsActive = true,
                });

                _unitOfWork.CustomerLoginRepository.AddEntity(new CustomerLogin()
                {
                    ID = Guid.NewGuid(),
                    PersonID = personelID,
                    Password = passwordHash,
                    Salt = salt,
                    CreatedDate = DateTime.Now,
                    CreatorID = personelID,
                    IsActive = true

                });

                _unitOfWork.Commit();
                status = true;
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                status = false;
            }

            return status;
        }
    }
}
