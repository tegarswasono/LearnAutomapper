using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LearnAutomapper.EntityFramework;
using LearnAutomapper.EntityFramework.Entities;
using LearnAutomapper.Models;
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
            List<Product> products = GetMapper.Map<List<Product>>(_context.Products.ToList());
            return Ok(products);
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public ActionResult Get(Guid Id)
        {
            Product product = GetMapper.Map<Product>(_context.Products.Where(x=>x.Id == Id).FirstOrDefault());
            return Ok(product);
        }

        // POST: api/Products
        [HttpPost]
        public ActionResult Post(CreateProductVM model)
        {
            Product product = GetMapper.Map<Product>(model);
            _context.Products.Add(product);
            _context.SaveChanges();
            return Ok();
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid Id, [FromBody]UpdateProductVM model)
        {
            Product product = _context.Products.Where(x=>x.Id == Id).FirstOrDefault();
            if (product == null)
                return BadRequest("Data Not Found");

            Product newProduct = GetMapper.Map(model, product);
            _context.Products.Update(newProduct);
            _context.SaveChanges();
            return Ok();
        }
        [HttpPut("FreshdeskStyle/{id}")]
        public ActionResult FreshdeskStyle(Guid Id, [FromBody]UpdateProductVMFreshdeskStyle model)
        {
            Product product = _context.Products.Where(x => x.Id == Id).FirstOrDefault();
            if (product == null)
                return BadRequest("Data Not Found");

            Product newProduct = GetMapper.Map(model, product);
            _context.Products.Update(newProduct);
            _context.SaveChanges();
            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid Id)
        {
            Product product = _context.Products.Where(x => x.Id == Id).FirstOrDefault();
            if (product == null)
                return BadRequest("Data Not Found");

            _context.Products.Remove(product);
            _context.SaveChanges();
            return Ok();
        }

        private IMapper GetMapper
        {
            get
            {
                var mapper = new MapperConfiguration(cfg => {
                    cfg.CreateMap<Product, ProductVM>();
                    cfg.CreateMap<CreateProductVM, Product>();
                    cfg.CreateMap<UpdateProductVM, Product>();

                    //cfg.CreateMap<UpdateProductVMFreshdeskStyle, Product>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
                    cfg.CreateMap<UpdateProductVMFreshdeskStyle, Product>()
                    .ForMember(x => x.CategoryId, opts => opts.Condition((src, dest, srcMember) => srcMember != Guid.Empty))
                    .ForMember(x => x.Name, opts => opts.Condition((src, dest, srcMember) => !string.IsNullOrEmpty(srcMember)))
                    .ForMember(x => x.Colour, opts => opts.Condition((src, dest, srcMember) => !string.IsNullOrEmpty(srcMember)))
                    .ForMember(x => x.Price, opts => opts.Condition((src, dest, srcMember) => !string.IsNullOrEmpty(srcMember) ));
                });
                return mapper.CreateMapper();
            }
        }
    }
}
