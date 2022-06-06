using BeautyBareAPI.Models;
using BeautyBareAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BeautyBareAPI.Controllers
{
    [Route("api/product/{productId}/ingredient")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly IIngredientService _ingredientService;

        public IngredientController(IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }
        [HttpPost]
        public ActionResult Post([FromRoute] int productId, [FromBody] CreateIngredientDto dto)
        {
            var newIngredientId = _ingredientService.Create(productId, dto);

            return Created($"api/{productId}/ingredient/{newIngredientId}", null);
        }
        [HttpGet("{ingredientId}")]
        public ActionResult<IngredientDto> Get([FromRoute] int productId, [FromRoute] int ingredientId)
        {
            IngredientDto ingredient = _ingredientService.GetById(productId, ingredientId);
            return Ok(ingredient);
        }

        [HttpGet]
        public ActionResult<List<IngredientDto>> Get([FromRoute] int productId)
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
        public ActionResult<IngredientDto> DeleteById([FromRoute] int productId, [FromRoute] int ingredientId)
        {
            _ingredientService.Remove(productId, ingredientId);

            return NoContent();
        }
    }
}
