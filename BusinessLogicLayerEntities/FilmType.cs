using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    /// <summary>
    /// Animacia, kino, mult....
    /// </summary>
    [Serializable]
    public class FilmType
    {
        public string Name { get; set; }
        public Guid ID { get; set; }

        public FilmType(string myName, Guid myGuid)
        {
            ID = myGuid;
            Name = myName;
        }
    }
}
