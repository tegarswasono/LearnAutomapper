using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LearnAutomapper.EntityFramework.Entities
{
    public class Category : BaseEntity
    {
        public string Name { set; get; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
