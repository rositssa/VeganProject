using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace VeganProject
{
    public class Vegan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int VeganTypesId { get; set; }
        public VeganType VeganTypes { get; set; }
        

        
    }
}
