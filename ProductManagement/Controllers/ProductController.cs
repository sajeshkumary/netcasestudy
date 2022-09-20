using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceBookingLibrary.Models;
using ProductManagement.Repo;

namespace ProductManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly TrainingServiceBookingContext _context;

        public ProductController(TrainingServiceBookingContext db)
        {
            _context = db;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAll()
        {
            try
            {
                ProductRepo ProductRepo = new ProductRepo(_context);
                return await ProductRepo.getAllProduct();
            }
            catch (NoProductsException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            try
            {
                ProductRepo ProductRepo = new ProductRepo(_context);

                return await ProductRepo.getProduct(id);
            }
            catch (NoProductsException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Product>> Add(Product u)
        {
            ProductRepo ProductRepo = new ProductRepo(_context);

            return await ProductRepo.AddNewProduct(u);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> UpdateProduct(int id, Product p)
        {
            try
            {
                ProductRepo ProductRepo = new ProductRepo(_context);

                return await ProductRepo.UpdateProduct(id, p);
            }
            catch (NoProductsException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            try
            {
                ProductRepo ProductRepo = new ProductRepo(_context);
                ProductRepo.deleteProduct(id);
                return Ok();
            }
            catch (NoProductsException ex)
            {
                return NotFound(ex.Message);
            }
        }


    }
}
