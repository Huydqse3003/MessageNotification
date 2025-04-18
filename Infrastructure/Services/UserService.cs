using Application;
using Application.IServices;
using AutoMapper;
using Domain;
using Domain.DTOs;
using Domain.Entities;
using Domain.Requests.User;
using Domain.Responses;
using Domain.Responses.User;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _config;
        private readonly AppSetting _appSettings;
        private readonly IMapper _mapper;
        private readonly IClaimService _service;

        public UserService(IUnitOfWork unitOfWork, IConfiguration config, AppSetting appSettings, IMapper mapper, IClaimService service)
        {
            _unitOfWork = unitOfWork;
            _config = config;
            _appSettings = appSettings;
            _mapper = mapper;
            _service = service;
        }

        public async Task<ApiResponse> LoginAsync(LoginRequest request)
        {
            ApiResponse response = new ApiResponse();
            var account = await _unitOfWork.Users.GetAsync(u => u.Email == request.Email);
            if (account == null || !VerifyPasswordHash(request.Password, account.PasswordHash, account.PasswordSalt))
            {
                response.SetBadRequest(message: "Email or password is wrong");
                return response;
            }

            if (account.IsEmailVerified == false)
            {
                response.SetBadRequest(message: "Please Verify your email");
                return response;
            }

            response.SetOk(CreateToken(account));
            return response;
        }
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
        private string CreateToken(User user)
        {
            var fullName = user.FirstName + " " + user.LastName;
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim("Role", user.Role.ToString()),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
                new Claim("Email" , user.Email!),
                new Claim("UserId", user.UserId.ToString()),
                new Claim("FullName", fullName),
                new Claim(ClaimTypes.Name, fullName),
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                 _appSettings!.SecretToken.Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

        public async Task<ApiResponse> GetUserByIdAsync(int id)
        {
            ApiResponse response = new ApiResponse();
            var user = await _unitOfWork.Users.GetAsync(u => u.UserId == id);
            if (user == null)
            {
                response.SetNotFound(message: "UserId not found");
                return response;
            }
            var result = _mapper.Map<GetUserByIdResponse>(user);
            response.SetOk(result);
            return response;
        }

        public async Task<ApiResponse> SearchUsers(string keyword)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                if (string.IsNullOrWhiteSpace(keyword)) return response.SetBadRequest(message: "Keyword is required");
                var claim = _service.GetUserClaim();
                var users = await _unitOfWork.Users.GetAllAsync(u => u.FirstName.ToLower().Contains(keyword) || u.LastName.ToLower().Contains(keyword));
                users = users.Where(u => u.UserId != claim.UserId).ToList();

                var result = _mapper.Map<List<SearchUserResponse>>(users ?? []);

                return response.SetOk(result);
            }
            catch (Exception ex)
            {
                return response.SetBadRequest($"Error: {ex.Message}");
            }
            
        }

        public async Task<ApiResponse> RegisterAsync(RegisterRequest request)
        {
            ApiResponse response = new ApiResponse();
            try
            {

                var checkPassword = CheckUserPassword(request);
                if (!checkPassword)
                {
                    response.SetBadRequest(message: "Confirm password is wrong !");
                    return response;
                }
                var existingUser = await _unitOfWork.Users.GetAsync(x => x.Email == request.Email);
                if (existingUser != null)
                {
                    response.SetBadRequest(message: "The email address is already register");
                    return response;
                }

                var pass = CreatePasswordHash(request.Password);
                User user = new User()
                {
                    PasswordHash = pass.PasswordHash,
                    PasswordSalt = pass.PasswordSalt,
                    Email = request.Email,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Role = request.Role,
                    IsEmailVerified = true
                };

                await _unitOfWork.Users.AddAsync(user);
                await _unitOfWork.SaveChangeAsync();

                response.SetOk(user.UserId);
                return response;
            }
            catch (Exception ex)
            {
                return response.SetBadRequest($"Error: {ex.Message}. Details: {ex.InnerException?.Message}");
            }
        }

        private PasswordDTO CreatePasswordHash(string password)
        {
            PasswordDTO pass = new PasswordDTO();
            using (var hmac = new HMACSHA512())
            {
                pass.PasswordSalt = hmac.Key;
                pass.PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
            return pass;
        }

        public bool CheckUserPassword(RegisterRequest request)
        {
            if (request.Password is null) return (false);
            return (request.Password.Equals(request.ConfirmPassword));
        }
    }
}
