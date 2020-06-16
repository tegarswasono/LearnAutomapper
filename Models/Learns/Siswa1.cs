using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnAutomapper.Models.Learns
{
    public class Siswa1
    {
        public Guid Id { set; get; }
        public String Name { set; get; }
        public long Age { set; get; }
        public DateTime CreatedAt { set; get; }
        public DateTime? UpdatedAt { set; get; }
    }
}
