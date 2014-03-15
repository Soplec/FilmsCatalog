using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable]
    public class Actor
    {
        public string Name { get; set; }
        public float Rate { get; set; }
        public Guid ID { get; set; }
        public Country Country { get; set; }
        public Guid[] FilmsID { get; set; }
        public ActorRate[] Rates { get; set; }

        public Actor()
        {

        }
        public Actor(string myName, Guid myID, Country myCountry)
        {
            Name = myName;
            Rate = 5;
            ID = myID;
            Country = myCountry;
            FilmsID = new Guid[0];
            Rates = new ActorRate[0];
        }
    }
}
