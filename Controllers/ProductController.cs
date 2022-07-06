using AutoMapper;
using BeautyBareAPI.Entities;
using BeautyBareAPI.Models;
using BeautyBareAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeautyBareAPI.Controllers
{
    [Route("api/product")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        { 
            _productService = productService;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateProduct([FromBody] CreateProductModel dto)
        {
            var id = _productService.Create(dto);

            return Created($"api/product/{id}", null);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        { 
            _productService.Delete(id);

            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody] UpdateProductModel dto, [FromRoute] int id)
        {
             _productService.Update(id, dto);

            return Ok();
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductModel>> GetAll()
        {
            var productsDtos = _productService.GetAll();

            return Ok(productsDtos);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<ProductModel> Get([FromRoute] int id)
        {
            var product = _productService.GetById(id);

            return Ok(product);
        }
    }
}
