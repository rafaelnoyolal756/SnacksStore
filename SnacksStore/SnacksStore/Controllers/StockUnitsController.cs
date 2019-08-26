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
    [Route("stockUnits")]
    public class StockUnitsController : Controller
    {
        private readonly IStockUnitsRepository _stockUnitsRepository;

        private readonly IProductRepository _productRepository;

        public StockUnitsController(IStockUnitsRepository stockUnitsRepository, IProductRepository productRepository)
        {
            _stockUnitsRepository = stockUnitsRepository;
            _productRepository = productRepository;
        }

        // GET stockUnits/5/comments
        [HttpGet("{Id}/[controller]")]
        public async Task<IActionResult> Get([FromRoute]int Id)
        {
            var stockUnit = await _stockUnitsRepository.GetAsync(Id);

            if (stockUnit == null)
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

        // GET stockUnits/{articleId}/comments/5
        [HttpGet("{Id}/[controller]/{id}")]
        public async Task<IActionResult> Get([FromRoute]int Id, [FromRoute]int id)
        {
            var stockUnit = await _stockUnitsRepository.GetAsync(Id);

            if (stockUnit == null)
            {
                return NotFound();
            }
           
            var products = await _productRepository.Query().Where(p => p.Id == Id).Take(20).ToListAsync();

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

        // POST stockUnits/5/comments
        [HttpPost("{Id}/[controller]")]
        public async Task<IActionResult> Post([FromRoute]int Id, [FromBody]ProductModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            List<StockUnitsModel> lstStockUnits = new List<StockUnitsModel>();
            StockUnits stockUnitModel = new StockUnits();
            stockUnitModel.stockCount = lstStockUnits.Count();
            //var stockCount = await _stockUnitsRepository.Query().Where(p => p.Id == Id).SelectMany(t => t.ProductId).Count();

            stockUnitModel = await _stockUnitsRepository.GetAsync(Id);

            if (stockUnitModel == null)
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

            return Created($"stockUnit/{Id}/products/{products.Id}", result);
        }

        // PUT stockUnit/5
        [HttpPost("{Id}/[controller]")]
        public async Task<IActionResult> Put([FromRoute]int Id, [FromBody]ProductModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var stockUnit = await _stockUnitsRepository.GetAsync(Id);

            if (stockUnit == null)
            {
                return NotFound();
            }

            var products = new Product
            {
                Id = Id,
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

            return Created($"stockUnit/{Id}/products/{products.Id}", result);
        }

        // DELETE stockUnit/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var stockUnit = await _stockUnitsRepository.GetAsync(id);

            if (stockUnit == null)
            {
                return NotFound();
            }

            await _stockUnitsRepository.DeleteAsync(id);

            return Ok();
        }
    }
}