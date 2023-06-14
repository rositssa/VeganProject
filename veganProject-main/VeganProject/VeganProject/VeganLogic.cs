using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeganProject
{
    public class VeganLogic
    {
        private VeganDBContext _veganDbContext = new VeganDBContext(); // Това е БД 
        public Vegan Get(int id)
        {
            Vegan findedVegan = _veganDbContext.Vegans.Find(id);
            if (findedVegan !=null)
            {
                _veganDbContext.Entry(findedVegan).Reference(x => x.VeganTypes).Load();
            }
            return findedVegan;
        }
        public List<Vegan> GetAll()
        {
            return _veganDbContext.Vegans.Include("VeganTypes").ToList();
        }
        public void Create(Vegan vegan)
        {
            _veganDbContext.Vegans.Add(vegan);
            _veganDbContext.SaveChanges();
        }
        public void Update(int id, Vegan vegan) 
        {
            Vegan findedvegan = _veganDbContext.Vegans.Find(id);
            if (findedvegan==null)
            {
                return;
            }
            findedvegan.Name = vegan.Name;
            findedvegan.Description = vegan.Description;
            findedvegan.Price = vegan.Price;
            findedvegan.VeganTypesId = vegan.VeganTypesId;
            _veganDbContext.SaveChanges();
        }
        public void Delete(int id)
        {
            Vegan findedvegan = _veganDbContext.Vegans.Find(id);
            _veganDbContext.Vegans.Remove(findedvegan);
            _veganDbContext.SaveChanges();
        }
    }
}
