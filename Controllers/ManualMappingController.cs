using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnAutomapper.EntityFramework;
using LearnAutomapper.EntityFramework.Entities;
using LearnAutomapper.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearnAutomapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManualMappingController : ControllerBase
    {
        private DBContext _context;
        public ManualMappingController(DBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult Get()
        {
            var products = _context.Products.Select(x => ProductModel.DTO(x));
            return Ok(products);
        }
    }
}