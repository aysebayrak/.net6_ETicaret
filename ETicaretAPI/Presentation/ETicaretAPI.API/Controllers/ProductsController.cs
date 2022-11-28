using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IProductReadRepository _productReadRepository;


        readonly private IOrderWriteRepository _orderWriteRepository;
        readonly private ICustomerWriteRepository _customerWriteRepository;


        public ProductsController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository, IOrderWriteRepository orderWriteRepository, ICustomerWriteRepository customerWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
            _orderWriteRepository = orderWriteRepository;
            _customerWriteRepository = customerWriteRepository; 
        }



        [HttpGet]
        public async Task Get()
        {

           var customerId = Guid.NewGuid();
           await _customerWriteRepository.AddAsync(new()
            { 
               Id = customerId,
               Name = "Ayşe"
            });
           await  _orderWriteRepository.AddAsync(new()
            {
                Description ="bla bala",
                Address ="istanbul",
                CustomerId = customerId

           });
            await _orderWriteRepository.AddAsync(new()
            {
                Description = "bla bala2222222",
                Address = "maraş",
                CustomerId = customerId
            });
            await _orderWriteRepository.SaveAsync();
        }      
    }
}
