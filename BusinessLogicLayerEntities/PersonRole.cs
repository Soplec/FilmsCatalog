using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable]
    class PersonRole
    {
        public Guid RoleID { get; set; }
        public string Name { get; set; }

        public PersonRole(Guid myRoleID, string myName)
        {
            RoleID = myRoleID;
            Name = myName;
        }
    }
}
