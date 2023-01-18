using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.UpSchool.DAL;
using WebApi.UpSchool.DAL.Entities;

namespace WebApi.UpSchool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        Context context = new Context();

        [HttpGet]
        public IActionResult CategoryList()
        {
            var categories = context.Categories.ToList();
            return Ok(categories);
        }

        [HttpPost]
        public IActionResult CategoryAdd(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult CategoryGet(int id)
        {
            var category = context.Categories.Find(id);
            return Ok(category);
        }

        [HttpDelete("{id}")]
        public IActionResult CatgoryDelete(int id)
        {
            var category = context.Categories.Find(id);
            context.Categories.Remove(category);
            context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult CategoryUpdate(Category category)
        {
            var categoryUpdate = context.Categories.Find(category.CategoryID);
            categoryUpdate.CategoryName = category.CategoryName;
            categoryUpdate.Description = category.Description;
            categoryUpdate.Status = category.Status;
            context.SaveChanges();
            return Ok();
        }
    }
}
