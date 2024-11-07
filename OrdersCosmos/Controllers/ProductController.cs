using Microsoft.AspNetCore.Mvc;
using Product_API.Models;
using Product_API.Services;
namespace Product_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        public readonly IProductService _ProductService;

        public ProductController(IProductService ProductService)
        {
            _ProductService = ProductService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var sqlQuery = "SELECT * FROM c";
            var result = await _ProductService.Get(sqlQuery);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Add(ProductModel task)
        {
            task.Id = Guid.NewGuid().ToString();
            var result = await _ProductService.Add(task);

            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update(ProductModel task)
        {
            var result = await _ProductService.Update(task);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(string id, string
        partition)
        {
            await _ProductService.Delete(id, partition);
            return Ok();
        }
    }
}