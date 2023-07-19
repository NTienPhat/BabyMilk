using AutoMapper;
using BusinessObject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using StoreAPI.DTO;
using System.Net;

namespace StoreAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserVoucherController : ControllerBase
    {
        private readonly IUserVoucherRepository _repo;
        private readonly IMapper _mapper;
        private ApiResponse _response;

        public UserVoucherController(IUserVoucherRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
            _response = new ApiResponse();
        }

        [HttpGet]
        public ActionResult Get()
        {
            List<UserVoucher> products = _repo.Get();
            if (products == null || products.Count == 0)
            {
                _response.StatusCode = HttpStatusCode.NotFound;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Can't found any user voucher!");
                return NotFound(_response);
            }
            _response.Result = products;
            _response.IsSuccess = true;
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }

        [HttpGet("{id:int}")]
        public ActionResult Get(int id)
        {
            UserVoucher b = _repo.GetById(id);
            if (b == null)
            {
                _response.StatusCode = HttpStatusCode.NotFound;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Can't found any user voucher!");
                return NotFound(_response);
            }
            _response.Result = b;
            _response.IsSuccess = true;
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }

        [HttpPost]
        //[Authorize(Roles = "admin")]
        public async Task<ActionResult<ApiResponse>> Post([FromBody] UserVoucherCreateDTO p)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var newPro = _mapper.Map<UserVoucher>(p);
                    _repo.Create(newPro);
                    _response.Result = newPro;
                    _response.IsSuccess = true;
                    _response.StatusCode = HttpStatusCode.OK;
                    return Ok(_response);
                }
                else
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
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
            }
            return _response;

        }


        [HttpDelete("{id}")]
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var p = _repo.GetById(id);
                if (p == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.ErrorMessages.Add("Not Found!");
                    return NotFound(_response);
                }
                _repo.Delete(p);
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
                return NotFound(_response);
            }
        }

        [HttpPut("{id:int}")]
        //[Authorize(Roles = "admin")]
        public IActionResult Put(int id, [FromBody] UserVoucherCreateDTO p)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var pro = _repo.GetById(id);
                    if (pro == null)
                    {
                        _response.IsSuccess = false;
                        _response.StatusCode = HttpStatusCode.NotFound;
                        _response.ErrorMessages.Add("Not Found!");
                        return NotFound(_response);
                    }
                    var newPro = _mapper.Map<UserVoucher>(p);
                    newPro.UserVoucherId = id;
                    _repo.Update(newPro);
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
            _response.IsSuccess = false;
            _response.StatusCode = HttpStatusCode.BadRequest;
            _response.ErrorMessages.Add($"{ModelState.Values.Select(e => e.Errors).ToList()}");
            return BadRequest(_response);

        }
    }
}
