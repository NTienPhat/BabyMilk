using AutoMapper;
using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using StoreAPI.DTO;
using System.Net;

namespace StoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _repo;
        private readonly IMapper _mapper;
        private ApiResponse _response;

        public AccountController(IAccountRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
            _response = new ApiResponse();
        }
        //[Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult<List<Account>> Get()
        {
            List<Account> products = _repo.GetAccount();
            if (products == null || products.Count == 0)
            {
                _response.StatusCode = HttpStatusCode.NotFound;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Can't found any account!");
                return NotFound(_response);
            }
            _response.Result = products;
            _response.IsSuccess = true;
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }

        [HttpGet("{id:int}")]
        public ActionResult<Account> Get(int id)
        {
            Account b = _repo.GetAccountById(id);
            if (b == null)
            {
                _response.StatusCode = HttpStatusCode.NotFound;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Can't found any account!");
                return NotFound(_response);
            }
            _response.Result = b;
            _response.IsSuccess = true;
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }



        [HttpDelete("{id}")]
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var p = _repo.GetAccountById(id);
                _repo.DeleteAccount(p);
                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.OK;
                _response.Result = p;
                return Ok(_response);
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

        //[HttpPut]
        ////[Authorize(Roles = "admin")]
        //public IActionResult Put([FromBody] BabyCreateDTO p)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            var newBaby = _mapper.Map<Baby>(p);
        //            _repo.UpdateBaby(newBaby);
        //            _response.IsSuccess = true;
        //            _response.StatusCode = HttpStatusCode.OK;
        //            _response.Result = p;
        //            return Ok(_response);
        //        }
        //        catch (Exception ex)
        //        {
        //            _response.IsSuccess = false;
        //            _response.StatusCode = HttpStatusCode.BadRequest;
        //            _response.ErrorMessages = new List<string>()
        //        {
        //            ex.ToString()
        //        };
        //            return BadRequest(_response);
        //        }
        //    }
        //    _response.IsSuccess = false;
        //    _response.StatusCode = HttpStatusCode.BadRequest;
        //    _response.ErrorMessages.Add($"{ModelState.Values.Select(e => e.Errors).ToList()}");
        //    return BadRequest(_response);

        //}
    }
}
