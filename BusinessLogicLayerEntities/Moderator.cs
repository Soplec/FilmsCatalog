using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable]
    public class Moderator : User
    {
        Film[] AddedFilms { get; set; }
        Film[] DeletedFilms { get; set; }

        public Moderator(Guid myID, string myName, string myPassword)
        {
            ID = myID;
            Name = myName;
            Password = myPassword;
            UserActorsRates = new ActorRate[0];
            UserFilmsRates = new FilmRate[0];
            AddedFilms = new Film[0];
            DeletedFilms = new Film[0];
        }
    }
}
