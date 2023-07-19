using AutoMapper;
using BusinessObject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using StoreAPI.DTO;
using StoreAPI.Services;
using System.Net;

namespace StoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecomenderController : ControllerBase
    {
        private readonly IRecomenderRepository _repo;
        private readonly IMapper _mapper;
        private readonly IBlobService _blobService;
        private ApiResponse _response;

        public RecomenderController(IRecomenderRepository repo, IMapper mapper, IBlobService blobService)
        {
            _repo = repo;
            _mapper = mapper;
            _blobService = blobService;
            _response = new ApiResponse();
        }
        //[Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAll(int month, int page =1)
        {
            List<Product> products = _repo.Get(page, 8, month);
            if (products == null || products.Count == 0)
            {
                _response.StatusCode = HttpStatusCode.NotFound;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Can't found any product!");
                return NotFound(_response);
            }
            _response.Result = products;
            _response.IsSuccess = true;
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            Product pro = await _repo.GetById(id);
            if (pro == null)
            {
                _response.StatusCode = HttpStatusCode.NotFound;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Can't found any product!");
                return NotFound(_response);
            }
            _response.Result = pro;
            _response.IsSuccess = true;
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }
    }
}
