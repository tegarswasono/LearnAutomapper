using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnAutomapper.EntityFramework;
using LearnAutomapper.EntityFramework.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearnAutomapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private DBContext _context;
        public ProductsController(DBContext dBContext)
        {
            _context = dBContext;
        }
        [HttpGet]
        public ActionResult Get()
        {
            return Ok("Ok");
        }

        // GET: api/Products/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Products
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
