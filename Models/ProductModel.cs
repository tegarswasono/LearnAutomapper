using LearnAutomapper.EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnAutomapper.Models
{
    public class ProductModel
    {
        public Guid Id { set; get; }
        public Guid CategoryId { set; get; }
        public string Name { set; get; }
        public string Colour { set; get; }
        public string Price { set; get; }
        public static ProductModel DTO(Product product)
        {
            var result = new ProductModel()
            {
                Id = product.Id,
                CategoryId = product.CategoryId,
                Name = product.Name,
                Colour = product.Colour,
                Price = product.Price
            };
            return result;
        }
    }
}
