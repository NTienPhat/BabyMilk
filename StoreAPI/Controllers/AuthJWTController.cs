using AutoMapper;
using BusinessObject.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using StoreAPI.DTO;
using System.Net;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace StoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthJWTController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IAccountRepository _repo;
        private readonly IMapper _mapper;
        private ApiResponse _response;
        public AuthJWTController(IConfiguration config, IAccountRepository repo, IMapper mapper)
        {
            _configuration = config;
            _repo = repo;
            _mapper = mapper;
            _response = new ApiResponse();
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Get(AccountLoginDTO c)
        {
            var newCus = _mapper.Map<Account>(c);
            var cus = _repo.Login(newCus);
            if (cus != null)
            {
                var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("AccountId", cus.AccountId.ToString()),
                        new Claim("Name", cus.Name),
                        new Claim("Role", cus.Role.ToString()),
                        new Claim("Address", cus.Address),
                        new Claim("PhoneNumber", cus.PhoneNumber),
                        new Claim("Email", cus.Email)
                    };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(10),
                    signingCredentials: signIn);

                var tokenObject = new { Token = new JwtSecurityTokenHandler().WriteToken(token) };
                var tokenJson = JsonConvert.SerializeObject(tokenObject);

                //_response.IsSuccess = true;
                //_response.StatusCode = HttpStatusCode.OK;
                //_response.Result = tokenJson;
                return Ok(tokenJson);
            }
            _response.IsSuccess = false;
            _response.StatusCode = HttpStatusCode.NotFound;
            _response.ErrorMessages.Add("Not Found!");
            return NotFound(_response);
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Post(RegisterDTO c)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!c.Password.Equals(c.ConfirmPassword))
                    {
                        _response.IsSuccess = false;
                        _response.ErrorMessages.Add("Confirm Password Is Incorrect!");
                        _response.StatusCode = HttpStatusCode.BadRequest;
                    }
                    var user = _repo.SearchByKeyword(c.Email);
                    if (user.Count == 0)
                    {
                        var newUser = _mapper.Map<Account>(c);
                        newUser.Role = "customer";
                        _repo.CreateNewAccount(newUser);
                        _response.IsSuccess = true;
                        _response.StatusCode = HttpStatusCode.OK;
                        return Ok(_response);
                    }
                    else
                    {
                        _response.IsSuccess = false;
                        _response.ErrorMessages.Add("Email already exists!");
                        _response.StatusCode = HttpStatusCode.BadRequest;
                    }

                    return BadRequest(_response);
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessages = new List<string>()
                {
                    ex.ToString()
                };
                return BadRequest(_response);
            }

        }
    }
}
