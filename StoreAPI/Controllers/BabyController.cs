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
    [Route("api/[controller]")]
    [ApiController]
    public class BabyController : ControllerBase
    {
        private readonly IBabyRepository _repo;
        private readonly IMapper _mapper;
        private ApiResponse _response;

        public BabyController(IBabyRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
            _response = new ApiResponse();
        }
        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult<List<Baby>> Get()
        {
            List<Baby> products = _repo.GetBaby();
            if (products == null || products.Count == 0)
            {
                _response.StatusCode = HttpStatusCode.NotFound;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Can't found any baby!");
                return NotFound(_response);
            }
            _response.Result = products;
            _response.IsSuccess = true;
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }

        [HttpGet("{id:int}")]
        [Authorize]
        public ActionResult<Baby> Get(int id)
        {
            Baby b = _repo.GetBabyById(id);
            if (b == null)
            {
                _response.StatusCode = HttpStatusCode.NotFound;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Can't found any baby!");
                return NotFound(_response);
            }
            _response.Result = b;
            _response.IsSuccess = true;
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }
        [Authorize(Roles = "customer")]
        [HttpGet("GetBabyOfMom")]
        public ActionResult<List<Baby>> GetBabyByMom(int momId)
        {
            List<Baby> b = _repo.GetBabyByMom(momId);
            if (b == null)
            {
                _response.StatusCode = HttpStatusCode.NotFound;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Can't found any baby!");
                return NotFound(_response);
            }
            _response.Result = b;
            _response.IsSuccess = true;
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }

        [HttpPost]
        [Authorize(Roles = "customer")]
        public IActionResult Post([FromBody] BabyCreateDTO p)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var newBaby = _mapper.Map<Baby>(p);
                    _repo.CreateNewBaby(newBaby);
                    _response.Result = newBaby;
                    _response.IsSuccess = true;
                    _response.StatusCode = HttpStatusCode.OK;
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

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var p = _repo.GetBabyById(id);
                _repo.DeleteBaby(p);
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

        [HttpPut("{id:int}")]
        [Authorize]
        //[Authorize(Roles = "admin")]
        public IActionResult Put(int id,[FromBody] BabyCreateDTO p)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var pro = _repo.GetBabyById(id);
                    if(pro == null)
                    {
                        _response.IsSuccess = false;
                        _response.StatusCode = HttpStatusCode.NotFound;
                        return NotFound(_response);
                    }
                    var newBaby = _mapper.Map<Baby>(p);
                    newBaby.BabyId = id;
                    _repo.UpdateBaby(newBaby);
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
