using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable]
    public class User
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public FilmRate[] UserFilmsRates { get; set; }
        public ActorRate[] UserActorsRates { get; set; }

        public User()
        {

        }
        public User(Guid myID, string myName, string myPassword)
        {
            ID = myID;
            Name = myName;
            Password = myPassword;
            UserActorsRates = new ActorRate[0];
            UserFilmsRates = new FilmRate[0];
        }
    }
}
