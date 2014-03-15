using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DataAcessLayer;

namespace ConsoleApplicationTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test DALa, bez BLL");
            Console.WriteLine("Sozdadim 3 filma");
            Console.WriteLine();

            var film1 = new Film();
            film1.DiscsNumber = 5;
            film1.ID = Guid.NewGuid();
            film1.Name = "matrix";
            film1.Rate = 10;
            film1.ReleaseYear = 1999;

            var film2 = new Film();
            film2.DiscsNumber = 10;
            film2.ID = Guid.NewGuid();
            film2.Name = "lord of the ring";
            film2.Rate = 9;
            film2.ReleaseYear = 2002;

            var film3 = new Film();
            film3.DiscsNumber = 15;
            film3.ID = Guid.NewGuid();
            film3.Name = "gravitation";
            film3.Rate = (float)8.5 ;
            film3.ReleaseYear = 1999;

            Logic.Create(film1, film1.ID);
            Logic.Create(film2, film2.ID);
            Logic.Create(film3, film3.ID);

            Console.WriteLine("4itaem sozdannie filmi iz filov");
            Console.WriteLine();
            var filmsList = Logic.ReadAll(film1.GetType());
            foreach (Film item in filmsList)
            {
                Console.WriteLine("name " + item.Name);
                Console.WriteLine("ID " + item.ID);
                Console.WriteLine("DiscsNumber " + item.DiscsNumber);
                Console.WriteLine("Rate " + item.Rate);
                Console.WriteLine("ReleaseYear " + item.ReleaseYear);
                Console.WriteLine();
            }

            Console.WriteLine("ydalyaem vse dlya sledyywego zapuska testa");
            foreach (Film item in filmsList)
            {
                Logic.Delete(item.GetType(), item.ID);
            }

            Console.ReadKey();
        }
    }
}
