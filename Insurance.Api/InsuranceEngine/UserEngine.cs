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

        public async Task<ICollection<string>> GetRolesByUserIdAsync(int userId)
        {
            return await _unitOfWork.RolesRepository.GetRolesByUserId(userId);
        }

        public async Task<UserReturnDto> LoginAsync(UserForLoginDto login)
        {
            var userFound = await _unitOfWork.UserRepository.LoginAsync(login.Username, login.Password);

            if (userFound == null)
            {
                return null;
            }

            var user = _mapper.Map<UserReturnDto>(userFound);
            user.Token = GenerateToken(user);

            return user;
        }

        public async Task<UserReturnDto> AddUserAsync(UserAddDto user)
        {
            user.Username = user.Username.ToLower();

            if (await _unitOfWork.UserRepository.UserExistsAsync(user.Username))
            {
                throw new ArgumentException($"The user {user.Username} already exists.");
            }

            var person = _mapper.Map<Person>(user);
            person.Created = DateTime.UtcNow;
            person.Modified = DateTime.UtcNow;
            await _unitOfWork.CommitAsync();

            var userToSave = _mapper.Map<User>(user);
            userToSave.Created = DateTime.UtcNow;
            userToSave.LastActive = DateTime.UtcNow;
            userToSave.PersonId = person.Id;

            await _unitOfWork.CommitAsync();

            return _mapper.Map<UserReturnDto>(userToSave);
        }

        private string GenerateToken(UserReturnDto user)
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
