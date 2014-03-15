using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable]
    public class Country
    {
        public string Name { get; set; }
        public Guid ID { get; set; }

        public Country(string myName, Guid myID)
        {
            Name = myName;
            ID = myID;
        }
    }
}
