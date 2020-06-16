using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LearnAutomapper.Models.Learns;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearnAutomapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Learn1Controller : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            var siswa1 = new Siswa1()
            {
                Id = Guid.NewGuid(),
                Name = "Joko",
                Age = 24,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            Siswa2 siswa2 = GetMapper.Map<Siswa2>(siswa1);

            return Ok();
        }
        [HttpGet("Coba1")]
        public ActionResult Coba1()
        {
            var siswa2 = new Siswa2()
            {
                Name = "Joko",
                Age = 24
            };
            Siswa1 siswa1 = GetMapper.Map<Siswa1>(siswa2);

            return Ok();
        }
        [HttpGet("Coba2")]
        public ActionResult Coba2()
        {
            var siswa3 = new Siswa3()
            {
                Name = "Joko",
                Age = 24,
                Alamat = "Malang"
            };
            Siswa1 siswa1 = GetMapper.Map<Siswa1>(siswa3);

            return Ok();
        }
        private IMapper GetMapper
        {
            get
            {
                var mapper = new MapperConfiguration(cfg => {
                    cfg.CreateMap<Siswa1, Siswa2>().ReverseMap();

                    cfg.CreateMap<Siswa3, Siswa1>();
                });
                return mapper.CreateMapper();
            }
        }
    }
}