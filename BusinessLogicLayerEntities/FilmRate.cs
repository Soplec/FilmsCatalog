using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable]
    public class FilmRate
    {
        public Guid FilmID { get; set; }
        public int Value { get; set; }
        public Guid UserID { get; set; }

        public FilmRate(Guid myFilmGuid, Guid myUserGuid, int myValue)
        {
            FilmID = myFilmGuid;
            UserID = myUserGuid;
            Value = myValue;
        }
    }
}
