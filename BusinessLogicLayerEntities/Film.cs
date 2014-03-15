using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable]
    public class Film
    {
        public string Name { get; set; }
        public int ReleaseYear { get; set; }
        public int DiscsNumber { get; set; }
        public Guid ID { get; set; }
        public float Rate { get; set; }
        public FilmRate[] FilmRates { get; set; }
        public FilmType[] FilmTypes { get; set; }
        public Genre[] Genres { get; set; }
        public Guid[] CountryesID { get; set; }
        public Guid[] ActorsID { get; set; }

        public Film()
        {

        }
        public Film(string myName, int myReleaseYear, int myDiscsNumber, Guid myGuid, FilmType[] myFilmTypes, Genre[] myGenres, Guid[] myCountryesID, Guid[] myActorsID)
        {
            Name = myName;
            ReleaseYear = myReleaseYear;
            DiscsNumber = myDiscsNumber;
            ID = myGuid;
            Rate = 5;
            FilmRates = new FilmRate[0];
            FilmTypes = myFilmTypes;
            Genres = myGenres;
            CountryesID = myCountryesID;
            ActorsID = myActorsID;
        }
    }
}
