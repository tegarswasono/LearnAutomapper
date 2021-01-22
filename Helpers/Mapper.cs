using AutoMapper;
using LearnAutomapper.EntityFramework.Entities;
using LearnAutomapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnAutomapper.Helpers
{
    public static class Mapper
    {
        public static IMapper GetMapper
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
                    .ForMember(x => x.Price, opts => opts.Condition((src, dest, srcMember) => !string.IsNullOrEmpty(srcMember)));
                });
                return mapper.CreateMapper();
            }
        }
    }
}
