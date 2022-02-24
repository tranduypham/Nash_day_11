using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EF_Core_2.Models;
using EF_Core_2.Services;
using System.Net;

namespace EF_Core_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductServices _productServices;
        public ProductsController(IProductServices productServices)
        {
            _productServices = productServices;
        }

        [HttpGet("")]
        public ActionResult<IEnumerable<Product>> GetTModels()
        {
            return _productServices.GetAll();
        }

        [HttpPost]
        public HttpStatusCode PostTModel(Product product)
        {
            _productServices.Add(product);
            return HttpStatusCode.OK;
        }

        [HttpPut("{id}")]
        public IActionResult PutTModel(int id, Product product)
        {
            _productServices.Update(id, product);
            return Ok("Thanh cong");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTModelById(int id)
        {
            _productServices.Delete(id);
            return Ok("Thanh cong");
        }
    }
}