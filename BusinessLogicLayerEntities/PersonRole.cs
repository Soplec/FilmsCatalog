using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable]
    public class PersonRole
    {
        public Guid RoleID { get; set; }
        public string Name { get; set; }

        public PersonRole(string myName, Guid myRoleID)
        {
            RoleID = myRoleID;
            Name = myName;
        }
    }
}
