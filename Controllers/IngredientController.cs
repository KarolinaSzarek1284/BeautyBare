using AutoMapper;
using BeautyBareAPI.Dtos;
using BeautyBareAPI.Models;
using BeautyBareAPI.Services;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace BeautyBareAPI.Controllers
{
    [Route("api/product/{productId}/ingredient")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly IIngredientService _ingredientService;
        private readonly IMapper _mapper;

        public IngredientController(IIngredientService ingredientService, IMapper mapper)
        {
            _ingredientService = ingredientService;
            _mapper = mapper;
        }
        [HttpPost]
        public ActionResult Post([FromRoute] int productId, [FromBody] CreateIngredientModel dto)
        {
            var newIngredientId = _ingredientService.Create(productId, dto);

            return Created($"api/{productId}/ingredient/{newIngredientId}", null);
        }
        [HttpGet("{ingredientId}")]
        public ActionResult<IngredientDto> Get([FromRoute] int productId, [FromRoute] int ingredientId)
        {
            var ingredientFromRepo = _ingredientService.GetById(productId, ingredientId);
            var ingredient = ingredientFromRepo.Adapt<IngredientDto>();
            return Ok(ingredient);
        }

        [HttpGet]
        public ActionResult<List<IngredientModel>> Get([FromRoute] int productId)
        {
            var result = _ingredientService.GetAll(productId);
            return Ok(result);
        }

        [HttpDelete]
        public ActionResult Delete([FromRoute] int productId)
        {
            _ingredientService.RemoveAll(productId);

            return NoContent();
        }

        [HttpDelete("{ingredientId}")]
        public ActionResult<IngredientModel> DeleteById([FromRoute] int productId, [FromRoute] int ingredientId)
        {
            _ingredientService.Remove(productId, ingredientId);

            return NoContent();
        }
    }
}
