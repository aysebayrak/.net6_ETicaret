using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Application.RequestParameters;
using ETicaretAPI.Application.ViewModels.Products;
using ETicaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IProductReadRepository _productReadRepository;


        public ProductsController(
            IProductReadRepository productReadRepository, 
            IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
          
        }


        //[HttpGet]
        //public async Task<ActionResult> Get(Pagination pagination)
        //{
        //    var totalCount = _productReadRepository.GetAll(false).Count();
        //    var products =   _productReadRepository.GetAll(false).Skip(pagination.Page * pagination.Size).Take(pagination.Size).Select(p => new
        //    {
        //        p.Id,
        //        p.Name,
        //        p.Stock,
        //        p.Price,
        //        p.CreatedDate,
        //        p.UpdatedDate
        //    });
        //   return Ok(new
        //   {
        //       totalCount,
        //       products
        //   });
        //}

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_productReadRepository.GetAll(false));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _productReadRepository.GetByIdAsync(id,false));

        }


        [HttpPost]

        public async Task<ActionResult> Post(VM_Create_Product  model)
        {
            
            await  _productWriteRepository.AddAsync(new() 
            {
                 Name = model.Name,
                 Price = model.Price,
                 Stock = model.Stock
            });
            await _productWriteRepository.SaveAsync();
             return StatusCode((int)HttpStatusCode.Created); // 201 DÖNMESİ İÇİN
 
        }

        [HttpPut]
        public async Task<IActionResult> Put(VM_Update_Product model)
        {
           Product product = await   _productReadRepository.GetByIdAsync(model.Id);
            product.Name = model.Name;
            product.Price = model.Price;
            product.Stock = model.Stock;
            await _productWriteRepository.SaveAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _productWriteRepository.RemoveAsync(id);
            await _productWriteRepository.SaveAsync();
            return Ok();

        }


        

    }
}
