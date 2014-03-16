using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable]
    public class Person
    {
        public string Name { get; set; }
        public Guid ID { get; set; }
        public Country MyCountry { get; set; }
        public Guid[] FilmsID { get; set; }
        public PersonRole[] Roles { get; set; }

        public Person()
        {

        }
        public Person(string myName, Guid myGuid, Country myCountry)
        {
            Name = myName;
            ID = myGuid;
            MyCountry = myCountry;
            FilmsID = new Guid[0];
            Roles = new PersonRole[0];
        }
    }
}
