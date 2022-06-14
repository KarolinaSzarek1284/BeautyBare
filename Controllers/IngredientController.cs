using AutoMapper;
using BeautyBareAPI.Models;
using BeautyBareAPI.Services;
using BeautyBareAPI.ViewModels;
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
        public ActionResult Post([FromRoute] int productId, [FromBody] CreateIngredientDto dto)
        {
            var newIngredientId = _ingredientService.Create(productId, dto);

            return Created($"api/{productId}/ingredient/{newIngredientId}", null);
        }
        [HttpGet("{ingredientId}")]
        public ActionResult<ViewModel> Get([FromRoute] int productId, [FromRoute] int ingredientId)
        {
            return Ok(_ingredientService.GetById(productId, ingredientId));
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
