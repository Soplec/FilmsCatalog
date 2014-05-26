using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using BinaryDAL;
using BusinessComponents;

namespace ConsoleApplicationTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test DALa, bez BLL");
            Console.WriteLine("Sozdadim 3 actera");
            Console.WriteLine();
            var USA = new Country("USA", Guid.NewGuid());
            var actor1 = new Actor("bred pit",Guid.NewGuid(), USA);
            var actor2 = new Actor("angelina djoli", Guid.NewGuid(), USA);
            var actor3 = new Actor("makalei kalkin", Guid.NewGuid(), USA);

            Logic.Create(actor1,actor1.ID);
            Logic.Create(actor2, actor2.ID);
            Logic.Create(actor3, actor3.ID);

            Console.WriteLine("4itaem sozdannix acterov iz filov");
            var actorsList = Logic.ReadAll(actor1.GetType());
            foreach (Actor item in actorsList)
            {               
                Console.WriteLine("ID " + item.ID);
                Console.WriteLine("name " + item.Name);
                Console.WriteLine("country " + item.Country.Name);

                Console.WriteLine();
            }


            Console.WriteLine("ydalyaem acterov dlya sledyywego zapuska testa");
            foreach (Actor item in actorsList)
            {
                Logic.Delete(item.GetType(), item.ID);
            }
            Console.WriteLine("*****************************************************************");
            Console.WriteLine("Test bll");
            Console.WriteLine("Sozdayem 3 filmTypa");
            BusinessComponents.FilmTypeComponents.AddFilmType("Kino",Guid.NewGuid());
            BusinessComponents.FilmTypeComponents.AddFilmType("Animaciya", Guid.NewGuid());
            BusinessComponents.FilmTypeComponents.AddFilmType("Serial", Guid.NewGuid());
            var myFTs = BusinessComponents.FilmTypeComponents.ReadAll();

            Console.WriteLine("Sozdayem 3 filma");
            var film1types = new FilmType[2];
            var film2types = new FilmType[1];
            var film3types = new FilmType[1];

            film1types[0] = (FilmType)myFTs[0];
            film1types[1] = (FilmType)myFTs[1];
            film2types[0] = (FilmType)myFTs[1];
            film3types[0] = (FilmType)myFTs[2];

            BusinessComponents.FilmComponents.AddFilm("film1","someInterestingDescription", 2001, 5, Guid.NewGuid(),film1types, null, null, null);
            BusinessComponents.FilmComponents.AddFilm("film2", "someInterestingDescription", 2002, 1, Guid.NewGuid(), film2types, null, null, null);
            BusinessComponents.FilmComponents.AddFilm("film3", "someInterestingDescription", 2003, 10, Guid.NewGuid(), film3types, null, null, null);
            Console.WriteLine("pro4itaem vse filmi");
            var myFilms = BusinessComponents.FilmComponents.ReadAll();
            foreach (Film item in myFilms)
            {
                Console.WriteLine("name "+item.Name);
                Console.WriteLine("Description "+item.Description);
                Console.WriteLine("Year "+item.ReleaseYear);
                Console.WriteLine("Discs count"+item.DiscsNumber);
                Console.WriteLine("Guid "+item.ID);
                foreach(var item1 in item.FilmTypes)
                {
                    Console.WriteLine("FilmType "+item1.Name);
                }
                Console.WriteLine("_________________________");
            }



            Console.WriteLine("Naidem filmi po ilm1");
            var findedFilms= BusinessComponents.FilmComponents.FindAllByNamePart("ilm1");
            foreach(Film item in findedFilms)
            {
                Console.WriteLine("name " + item.Name);
                Console.WriteLine("Description " + item.Description);
                Console.WriteLine("Year " + item.ReleaseYear);
                Console.WriteLine("Discs count" + item.DiscsNumber);
                Console.WriteLine("Guid " + item.ID);
                foreach (var item1 in item.FilmTypes)
                {
                    Console.WriteLine("FilmType " + item1.Name);
                }
                Console.WriteLine("+");
            }

            Console.WriteLine("ydalim pervii naidenii  film");
            BusinessComponents.FilmComponents.Delete(findedFilms[0].ID);
            Console.WriteLine("snova pro4itaem vse filmi");
            myFilms = BusinessComponents.FilmComponents.ReadAll();
            foreach (Film item in myFilms)
            {
                Console.WriteLine("name " + item.Name);
                Console.WriteLine("Description " + item.Description);
                Console.WriteLine("Year " + item.ReleaseYear);
                Console.WriteLine("Discs count" + item.DiscsNumber);
                Console.WriteLine("Guid " + item.ID);
                foreach (var item1 in item.FilmTypes)
                {
                    Console.WriteLine("FilmType " + item1.Name);
                }
                Console.WriteLine("_________________________");
            }



            Console.ReadKey();
            Console.WriteLine("ydalyaemvse filmi+filmTypi dlya sledyywego zapuska testa");
            foreach (FilmType item in myFTs)
            {
                Logic.Delete(item.GetType(), item.ID);
            }


            foreach (Film item in myFilms)
            {
                BusinessComponents.FilmComponents.Delete(item.ID);
            }
            

            Console.ReadKey();
        }
    }
}
