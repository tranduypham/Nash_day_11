using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EF_Core_2.Models;
using EF_Core_2.Services;

namespace EF_Core_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryServices _categoryServices;
        public CategoryController(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        [HttpGet("")]
        public ActionResult<IEnumerable<Category>> GetCategorys()
        {
            return _categoryServices.GetAll();
        }

        [HttpPost("")]
        public IActionResult PostCategory(Category category)
        {
            _categoryServices.Add(category);
            return Ok("Thanh cong");
        }

        [HttpPut("{id}")]
        public IActionResult PutCategory(int id, Category category)
        {
            _categoryServices.Update(id, category);
            return Ok("Thanh cong");
        }

        [HttpDelete("{id}")]
        public ActionResult<Category> DeleteCategoryById(int id)
        {
            _categoryServices.Delete(id);
            return Ok("Thanh cong");
        }
    }
}