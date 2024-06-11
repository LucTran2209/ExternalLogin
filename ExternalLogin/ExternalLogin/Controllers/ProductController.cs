using ExternalLogin.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExternalLogin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        [Authorize(Roles = AppRole.Admin)]
        public IActionResult GetListProduct()
        {
            // Tạo danh sách các sản phẩm
            List<Product> products = new List<Product>
              {
                     new Product(1, "Laptop", 1200m),
                     new Product(2, "Smartphone", 800m),
                     new Product(3, "Tablet", 600m),
                     new Product(4, "Monitor", 300m),
                     new Product(5, "Keyboard", 50m),
                     new Product(6, "Mouse", 25m),
                     new Product(7, "Printer", 150m),
                     new Product(8, "Camera", 500m),
                     new Product(9, "Headphones", 100m),
                     new Product(10, "Speakers", 200m)
               };

            // Tạo một đối tượng Random
            Random rand = new Random();

            // Lấy ngẫu nhiên 5 sản phẩm từ danh sách
            List<Product> randomProducts = products.OrderBy(x => rand.Next()).Take(5).ToList();

            return Ok(randomProducts);
        }

    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Product(int id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return $"Product(Id={Id}, Name='{Name}', Price={Price})";
        }
    }
}
