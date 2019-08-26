using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SnacksStore.Repository;
using SnacksStore.Entities;
using SnacksStore.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using SnacksStore.Service;
using SnacksStore.Helpers;

namespace SnacksStore.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private IUserService _userService;

        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // GET products/search
        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery]string name)
        {
            var products = await _productRepository.Query().Where(p => p.Name.Contains(name)).Take(20).ToListAsync();
            
            var result = new ProductListModel
            {
                Products = products.Select(p => new ProductModel
                {
                    ProductId = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    Size = p.Size
                })
            };

            return Ok(result);
        }

        // GET products/GetAll
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(string sortOrder)
        {
            var product = new List<Product> { 
            }.AsQueryable();
            var products = await _productRepository.Query().ToListAsync();
            // var products = from s in _productRepository.Query().Where(p => p.Name.OrderBy(sortOrder, null));
            var result = product.Sort("Name").Select(x => x.Name).ToList();

            return Ok(result);
        }



        // GET products/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var product = await _productRepository.GetAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            var result = new ProductModel
            {
                ProductId = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Size = product.Size
            };

            return Ok(result);
        }

        // POST products
        [Authorize(Roles = Role.Admin)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ProductModel model)
        {
            
            var currentUserId = int.Parse(User.Identity.Name);
            if (!User.IsInRole(Role.Admin))
            {
                return Forbid();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = new Product
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                Size = model.Size
            };

            await _productRepository.InsertAsync(product);

            return Created($"product/{product.Id}", product);
        }

        // PUT products/5
        [Authorize(Roles = Role.Admin)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]ProductModel model)
        {
           
            var currentUserId = int.Parse(User.Identity.Name);
            if (!User.IsInRole(Role.Admin))
            {
                return Forbid();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = await _productRepository.GetAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            product.Name = model.Name;
            product.Description = model.Description;
            product.Price = model.Price;
            product.Size = model.Size;

            await _productRepository.UpdateAsync(product);

            return Ok(product);
        }

        // DELETE products/5
        [Authorize(Roles = Role.Admin)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            
            var currentUserId = int.Parse(User.Identity.Name);
            if (!User.IsInRole(Role.Admin))
            {
                return Forbid();
            }
            var product = await _productRepository.GetAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            await _productRepository.DeleteAsync(id);

            return Ok();
        }
    }
}