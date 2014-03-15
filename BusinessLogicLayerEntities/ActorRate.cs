using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable]
    public class ActorRate
    {
        public Guid ActorID { get; set; }
        public int Value { get; set; }
        public Guid UserID { get; set; }

        public ActorRate(Guid myActorID, int value, Guid myUserID)
        {
            ActorID = myActorID;
            Value = value;
            UserID = myUserID;
        }
    }
}
