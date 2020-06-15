using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnAutomapper.EntityFramework;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearnAutomapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private DBContext _context;
        public CategoriesController(DBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult Get()
        {
            var categories = _context.Categories.ToList();
            return Ok(categories);
        }
    }
}