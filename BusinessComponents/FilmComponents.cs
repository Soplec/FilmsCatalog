using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcessLayer;
using Entities;

namespace BusinessComponents
{
    class FilmComponents
    {
        private static Film uselessFilm;

        public static void AddFilm(string myName, string myDescription, int myReleaseYear, int myDiscsNumber, Guid myGuid, FilmType[] myFilmTypes, Genre[] myGenres, Guid[] myCountryesID, Guid[] myActorsID)
        {
            Logic.Create(new Film(myName, myDescription, myReleaseYear, myDiscsNumber,myGuid, myFilmTypes, myGenres, myCountryesID, myActorsID), myGuid);
        }

        public static List<Object> ReadAll()
        {
            return Logic.ReadAll(uselessFilm.GetType());
        }

        public static Film Read(Guid myGuid)
        {
            return (Film)Logic.Read(uselessFilm.GetType(), myGuid);
        }

        public static void Delete(Guid myGuid)
        {
            Logic.Delete(uselessFilm.GetType(), myGuid);
        }

        public static List<Film> FindAllByNamePart(string NamePart)
        {
            List<Object> myList = Logic.ReadAll(uselessFilm.GetType());
            var findedFilms = new List<Film>();
            foreach (Film item in myList)
            {
                if (item.Name.Contains(NamePart))
                {
                    findedFilms.Add(item);
                }
            }
            return findedFilms;
        }
    }
}
