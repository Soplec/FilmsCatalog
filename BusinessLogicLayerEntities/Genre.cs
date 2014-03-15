using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable]
    public class Genre
    {
        public string Name { get; set; }
        public Guid ID { get; set; }

        public Genre(string myName, Guid myGuid)
        {
            Name = myName;
            ID = myGuid;
        }
    }
}
