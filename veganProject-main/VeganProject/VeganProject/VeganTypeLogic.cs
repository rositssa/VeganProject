using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeganProject
{
    public class VeganTypeLogic
    {
        private VeganDBContext _veganDbContext = new VeganDBContext();
        public List<VeganType> GetAllVeganTypes()
        {
            return _veganDbContext.VeganTypes.ToList();
        }
        public string GetTypeById(int id)
        {
            return _veganDbContext.VeganTypes.Find(id).Name;
        }
    }
}
