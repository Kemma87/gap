using AutoMapper;
using DataAccess.Contracts;
using DataAccess.Models;
using InsuranceEngine.Contracts;
using InsuranceEngine.Dtos;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceEngine
{
    public class UserEngine : IUserEngine
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public UserEngine(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration config)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _config = config;
        }

        public async Task<UserReturnDto> LoginAsync(UserForLoginDto login)
        {
            var userFound = await _unitOfWork.UserRepository.LoginAsync(login.Username, login.Password);

            if (userFound == null)
            {
                return null;
            }

            var userRoles = await _unitOfWork.RolesRepository.GetRolesByUserId(userFound.Id);

            var user = _mapper.Map<UserReturnDto>(userFound);
            user.Token = GenerateToken(userFound);
            user.Roles = _mapper.Map<ICollection<UserRoleDto>>(userRoles);

            return user;
        }


        private string GenerateToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
