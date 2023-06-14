using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VeganProject
{
    public class Display
    {
        private VeganLogic veganLogic = new VeganLogic();
        private int closeOperation = 6;
        public Display()
        {
            Input();
        }
        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "MENU" +new string(' ', 18));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1 List all entries");
            Console.WriteLine("2 Add new entry");
            Console.WriteLine("3 Update entry");
            Console.WriteLine("4 Fetch entry by ID");
            Console.WriteLine("5 Delete entry by ID");
            Console.WriteLine("6 Exit");
        }
        private void Input()
        {
            var operation = -1;
            do
            {
                ShowMenu();
                operation = int.Parse(Console.ReadLine());
                switch(operation)
                {
                    case 1:
                        ListAll();
                        break;
                    case 2:
                        Add();
                        break;
                    case 3:
                        Update();
                        break;
                    case 4:
                        Fetch();
                        break;
                    case 5:
                        Delete();
                        break;
                    default:                        
                        break;
                }

            } while (operation != closeOperation);
        }
        private void PrintVegan(Vegan vegan)
        {
            Console.WriteLine($"{vegan.Id}. {vegan.Name}. {vegan.Description} --Price: {vegan.Price} VeganTypeId: {vegan.VeganTypesId}");
        }
        private void Delete()
        {
            Console.WriteLine("Enter id to fetch: ");
            int id = int.Parse(Console.ReadLine());
            VeganLogic vegancontroller = new VeganLogic();
            Vegan vegan = vegancontroller.Get(id);
            if (vegan != null)
            {
                vegancontroller.Delete(id);
            }
        }

        private void Fetch()
        {
            Console.WriteLine("Enter id to fetch");
            int id = int.Parse(Console.ReadLine());
            VeganLogic vegancontroller = new VeganLogic();
            Vegan vegan = vegancontroller.Get(id);
            if (vegan != null)
            {
                PrintVegan(vegan);
            }
        }

        private void Update()
        {
            Console.WriteLine("Enter the vegans Id");
            int veganId = int.Parse(Console.ReadLine());
            VeganLogic vegancontroller = new VeganLogic();
            Vegan vegan = vegancontroller.Get(veganId);
            if (vegan == null)
            {
                Console.WriteLine("Enter new values: ");
                Console.Write("Name: ");
                vegan.Name = Console.ReadLine();
                Console.Write("Description: ");
                vegan.Description = Console.ReadLine();
                Console.Write("Price: ");
                vegan.Price = int.Parse(Console.ReadLine());
                VeganTypeLogic typelogic = new VeganTypeLogic();
                List<VeganType> alltypes = typelogic.GetAllVeganTypes();
                Console.WriteLine("Type:");
                Console.WriteLine(new string('-', 4));
                foreach (var item in alltypes)
                {
                    Console.WriteLine(item.Id + ". " + item.Name);
                }
                Console.WriteLine("Insert Type: ");
                vegan.VeganTypesId = int.Parse(Console.ReadLine());
                VeganLogic vegancont = new VeganLogic();
                vegancont.Update(veganId, vegan);
            }
        }

        private void Add()
        {
            Vegan vegan = new Vegan();
            Console.Write("Name: ");
            vegan.Name = Console.ReadLine();
            Console.Write("Description: ");
            vegan.Description = Console.ReadLine();
            Console.Write("Price: ");
            vegan.Price = int.Parse(Console.ReadLine());

            VeganTypeLogic vegantypeLogic = new VeganTypeLogic();
            List<VeganType> alltypes = vegantypeLogic.GetAllVeganTypes();
            Console.WriteLine("Type: ");
            Console.WriteLine(new string('-', 4));
            foreach (var item in alltypes)
            {
                Console.WriteLine(item.Id + ". " + item.Name); 
            }
            Console.WriteLine("Select type: ");
            vegan.VeganTypesId = int.Parse(Console.ReadLine());
            VeganLogic vegancontroller = new VeganLogic();
            vegancontroller.Create(vegan);
            Console.WriteLine($"{vegan.Id}. {vegan.Name}. {vegan.Description} >>> {vegan.Price}" +
                $" >>type: {vegan.VeganTypesId}");
        }

        private void ListAll()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "Vegans" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            VeganLogic vegancontroller = new VeganLogic();
            var products = vegancontroller.GetAll();
            foreach (var item in products)
            {
                Console.WriteLine($"{item.Id} {item.Name} {item.Description} {item.Price} {item.VeganTypesId}");
            }
        }
    }
}
