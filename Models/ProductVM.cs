using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnAutomapper.Models
{
    public class ProductVM
    {
        public Guid Id { set; get; }
        public Guid CategoryId { set; get; }
        public string Name { set; get; }
        public string Colour { set; get; }
        public string Price { set; get; }
    }
    public class CreateProductVM
    {
        public Guid CategoryId { set; get; }
        public string Name { set; get; }
        public string Colour { set; get; }
        public string Price { set; get; }
    }
    public class UpdateProductVM
    {
        public Guid CategoryId { set; get; }
        public string Name { set; get; }
        public string Colour { set; get; }
        public string Price { set; get; }
    }
    public class UpdateProductVMFreshdeskStyle
    {
        public Nullable<Guid> CategoryId { set; get; }
        public string? Name { set; get; }
        public string? Colour { set; get; }
        public string? Price { set; get; }
    }
}
