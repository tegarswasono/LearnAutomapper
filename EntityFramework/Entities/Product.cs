﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LearnAutomapper.EntityFramework.Entities
{
    public class Product : BaseEntity
    {
        public Guid CategoryId { set; get; }
        public string Name { set; get; }
        public string Colour { set; get; }
        public string Price { set; get; }
        public virtual Category Category { set; get; }
    }
}
