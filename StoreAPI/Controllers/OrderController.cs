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
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _repo;
        private readonly IPaymentRepository _repoPayment;
        private readonly IMapper _mapper;
        private ApiResponse _response;

        public OrderController(IOrderRepository repo, IPaymentRepository repoPayment, IMapper mapper)
        {
            _repoPayment = repoPayment;
            _repo = repo;
            _mapper = mapper;
            _response = new ApiResponse();
        }
        //[Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult Get()
        {
            List<Order> products = _repo.GetOrder();
            if (products == null || products.Count == 0)
            {
                _response.StatusCode = HttpStatusCode.NotFound;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Can't found any order!");
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
            Order b = _repo.GetOrderById(id);
            if (b == null)
            {
                _response.StatusCode = HttpStatusCode.NotFound;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Can't found any order!");
                return NotFound(_response);
            }
            _response.Result = b;
            _response.IsSuccess = true;
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }

        [HttpGet("GetOrderOfUser")]
        public ActionResult<Baby> GetOrderOfUser(int userId)
        {
            List<Order> b = _repo.GetOrderByAccountId(userId);
            if (b == null)
            {
                _response.StatusCode = HttpStatusCode.NotFound;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Can't found any order!");
                return NotFound(_response);
            }
            _response.Result = b;
            _response.IsSuccess = true;
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }

        [HttpPost]
        //[Authorize(Roles = "admin")]
        public async Task<ActionResult<ApiResponse>> Post([FromBody] OrderCreateDTO p)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newPro = _mapper.Map<Order>(p);
                    _repo.CreateNewOrder(newPro);
                    var payment = new PaymentCreateDTO()
                    {
                        AccountId = newPro.AccountId,
                        OrderId = newPro.OrderId,
                        Type = "cash",
                        TokenPayment = $"EzMom-{newPro.OrderId}-{newPro.OrderDate.ToString("MM-dd-yyy")}"
                    };
                    var newPayment = _mapper.Map<Payment>(payment);
                    _repoPayment.Create(newPayment);
                    var orderResponse = _mapper.Map<OrderCreateResponseDTO>(newPro);
                    orderResponse.Token = payment.TokenPayment;
                    orderResponse.OderId = newPro.OrderId;
                    _response.Result = orderResponse;
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
                var p = _repo.GetOrderById(id);
                if (p == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.ErrorMessages.Add("Not Found!");
                    return NotFound(_response);
                }
                _repo.DeleteOrder(p);
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
        public IActionResult Put(int id, [FromBody] OrderUpdateDTO p)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var pro = _repo.GetOrderById(id);
                    if (pro == null)
                    {
                        _response.IsSuccess = false;
                        _response.StatusCode = HttpStatusCode.NotFound;
                        _response.ErrorMessages.Add("Not Found!");
                        return NotFound(_response);
                    }
                    //var newPro = _mapper.Map<Order>(p);
                    //newPro.OrderId = id;
                    pro.OrderStatus = p.OrderStatus;
                    pro.ShippedDate = p.ShippedDate;
                    _repo.UpdateOrder(pro);
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
