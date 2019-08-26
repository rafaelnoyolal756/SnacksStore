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

namespace SnacksStore.Controllers
{
    [Route("likingProducts")]
    
    public class LikingProductsController : Controller
    {
        private readonly ILikingProductsRepository _likingProductsRepository;

        private readonly IProductRepository _productRepository;

        private readonly IUserRepository _userRepository;

        public LikingProductsController(ILikingProductsRepository likingProductsRepository, IProductRepository productRepository, IUserRepository userRepository)
        {
            _likingProductsRepository = likingProductsRepository;
            _productRepository = productRepository;
            _userRepository = userRepository;
        }

        // GET likingProducts/5/products
        [HttpGet("{Id}/[controller]")]
        public async Task<IActionResult> Get([FromRoute]int Id)
        {
            var likingProducts = await _likingProductsRepository.GetAsync(Id);

            if (likingProducts == null)
            {
                return NotFound();
            }

            var products = await _productRepository.Query().ToListAsync();

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

        // GET likingProducts/{articleId}/comments/5
        [HttpGet("{Id}/[controller]/{id}")]
        public async Task<IActionResult> Get([FromRoute]int Id, [FromRoute]int id)
        {
            var likingProducts = await _likingProductsRepository.GetAsync(Id);

            if (likingProducts == null)
            {
                return NotFound();
            }

            var products = await _productRepository.Query().Where(p => p.ProductId == Id).Take(20).ToListAsync();

            if (products == null)
            {
                return NotFound();
            }

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

        // POST likingProducts/5/comments
        [HttpPost("{Id}/[controller]")]
        public async Task<IActionResult> Post([FromRoute]int Id, [FromBody]ProductModel model, [FromBody]UserModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var likingProducts = await _likingProductsRepository.GetAsync(Id);

            if (likingProducts == null)
            {
                return NotFound();
            }

            var products = new Product
            {
                ProductId = Id,
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                Size = model.Size
            };

            await _productRepository.InsertAsync(products);

            var result = new ProductModel
            {
                ProductId = products.Id,
                Name = products.Name,
                Description = products.Description,
                Price = products.Price,
                Size = products.Size
            };

            var users = new User
            {
                UserId = userModel.UserId,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                Username = userModel.Username,
                Password = userModel.Password,
                Role = userModel.Role
            };

            await _userRepository.InsertAsync(users);

             var result2 = new UserModel
            {
                 UserId = users.Id,
                FirstName = users.FirstName,
                LastName = users.LastName,
                Username = users.Username,
                Password = users.Password,
                Role = users.Role
            };

            

            return Created($"likingProducts/{Id}/products/{products.Id}", result);
        }

    }
}