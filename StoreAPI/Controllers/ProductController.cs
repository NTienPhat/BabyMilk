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
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;
        private readonly IBlobService _blobService;
        private ApiResponse _response;
        private PagingApiResponse _responsePaging;

        public ProductController(IProductRepository repo, IMapper mapper, IBlobService blobService)
        {
            _repo = repo;
            _mapper = mapper;
            _blobService = blobService;
            _response = new ApiResponse();
            _responsePaging = new PagingApiResponse();
        }
        //[Authorize(Roles = "admin")]
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAll(int page = 1)
        {
            var productInPage = 9;
            List<Product> p = await _repo.GetAll();
            var total = p.Count;
            var rs = total % productInPage;
            var pageNum = 0;
            if(rs == 0)
            {
                pageNum = total / productInPage;
            }
            else
            {
                pageNum = total / productInPage +1;
            }
            List<Product> products = await _repo.GetProduct(page, productInPage);
            if (products == null || products.Count == 0)
            {
                _responsePaging.StatusCode = HttpStatusCode.NotFound;
                _responsePaging.IsSuccess = false;
                _responsePaging.ErrorMessages.Add("Can't found any product!");
                return NotFound(_responsePaging);
            }
            _responsePaging.Result = products;
            _responsePaging.IsSuccess = true;
            _responsePaging.StatusCode = HttpStatusCode.OK;
            _responsePaging.total = total;
            _responsePaging.pageNum = pageNum;
            return Ok(_responsePaging);
        }

        [AllowAnonymous]
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            Product pro = await _repo.GetProductById(id);
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

        //[HttpPost]
        ////[Authorize(Roles = "admin")]
        //public async Task<IActionResult> Post([FromForm] ProductCreateDTO p)
        //{
        //    if(ModelState.IsValid)
        //    {
        //        if(p.File == null || p.File.Length == 0)
        //        {
        //            _response.StatusCode = HttpStatusCode.NotFound;
        //            _response.IsSuccess = false;
        //            _response.ErrorMessages.Add("Image is required!");
        //            return BadRequest(_response);
        //        }
        //        try
        //        {
        //            string fileName = $"{Guid.NewGuid()}{Path.GetExtension(p.File.FileName)}";
        //            var img = await _blobService.UploadBlob(fileName, "babymilkimages", p.File);

        //            var newProduct = _mapper.Map<Product>(p);
        //            newProduct.Img = img;
        //            _repo.CreateNewProduct(newProduct);
        //            _response.Result = newProduct;
        //            _response.IsSuccess = true;
        //            _response.StatusCode = HttpStatusCode.OK;
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
        //    _response.IsSuccess= false;
        //    _response.StatusCode = HttpStatusCode.BadRequest;
        //    _response.ErrorMessages.Add($"{ModelState.Values.Select(e => e.Errors).ToList()}");
        //    return BadRequest(_response);

        //}
        [Authorize(Roles = "admin")]
        [HttpPost]
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> Post([FromForm] ProductCreateDTO p)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (p.File == null || p.File.Length == 0)
                    {
                        _response.StatusCode = HttpStatusCode.NotFound;
                        _response.IsSuccess = false;
                        _response.ErrorMessages.Add("Image is required!");
                        return BadRequest(_response);
                    }

                    string fileName = $"{Guid.NewGuid()}{Path.GetExtension(p.File.FileName)}";
                    var img = await _blobService.UploadBlob(fileName, "babymilkimages", p.File);

                    var newProduct = _mapper.Map<Product>(p);
                    newProduct.Img = img;
                    _repo.CreateNewProduct(newProduct);
                    _response.Result = newProduct;
                    _response.IsSuccess = true;
                    _response.StatusCode = HttpStatusCode.OK;
                    return Ok(_response);
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessages.Add($"{ModelState.Values.Select(e => e.Errors).ToList()}");
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
            return BadRequest(_response);

        }
        [Authorize(Roles = "admin")]
        [HttpDelete("{id:int}")]
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Product p = await _repo.GetProductById(id);
                if(p == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.ErrorMessages.Add("Not Found");
                    _response.IsSuccess = false;
                    return NotFound(_response);
                }
                var link = p.Img.Split('/').Last();
                await _blobService.DeleteBlob(link, "babymilkimages");
                _repo.DeleteProduct(p);
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
        [Authorize(Roles = "admin")]
        [HttpPut("{id:int}")]
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> Put(int id,[FromForm] ProductUpdateDTO p)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    Product product = await _repo.GetProductById(id);
                    if(product == null)
                    {
                        _response.IsSuccess = false;
                        _response.StatusCode = HttpStatusCode.NotFound;
                        _response.ErrorMessages.Add("Not Found");
                        return NotFound(_response);
                    }
                    product.ProductId = id;
                    product.Name = p.Name;
                    product.Price = p.Price;
                    product.Description = p.Description;
                    product.Status = p.Status;
                    product.Price = p.Price;
                    product.BrandId = p.BrandId;
                    product.ProductBabyDevelopmentId = p.ProductBabyDevelopmentId;
                    product.Quantity = p.Quantity;

                    if (p.File != null && p.File.Length > 0)
                    {
                        var link = product.Img.Split('/').Last();
                        string fileName = $"{Guid.NewGuid()}{Path.GetExtension(p.File.FileName)}";
                        await _blobService.DeleteBlob(link, "babymilkimages");
                        product.Img = await _blobService.UploadBlob(fileName, "babymilkimages", p.File);
                    }
                    _repo.UpdateProduct(product);
                    _response.IsSuccess = true;
                    _response.StatusCode = HttpStatusCode.OK;
                    _response.Result = p;
                    return Ok(_response);
                }
                else
                {

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
            return BadRequest(_response);

    }
}
}
