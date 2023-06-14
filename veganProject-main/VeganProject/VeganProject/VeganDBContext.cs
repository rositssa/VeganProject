using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeganProject
{
    public class VeganDBContext:DbContext
    {
        public VeganDBContext():base("VeganDBContext")
        {

        }
        public DbSet<Vegan> Vegans { get; set; }
        public DbSet<VeganType> VeganTypes { get; set; }
    }
}
