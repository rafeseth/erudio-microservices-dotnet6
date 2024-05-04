using GeekShopping.ProductAPI.Data.ValueObjects;
using GeekShopping.ProductAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.ProductAPI.Controllers
{
    [Route("api/vi/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private IProductRepository _repository;
        public ProductController(IProductRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository)); ;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult>FindById(long id)
        {
            var product = await _repository.FindById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductVO>>> FindAll()
        {
            var product = await _repository.FindAll();
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult> Create(ProductVO vo)
        {
            if (vo == null)
            {
                return BadRequest();
            }
            await _repository.Create(vo);
            return Ok(vo);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var product = await _repository.Delete(id);
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> Update(ProductVO vo)
        {
            if (vo == null)
            {
                return BadRequest();
            }
            await _repository.Update(vo);
            return Ok(vo);
        }
    }
}
