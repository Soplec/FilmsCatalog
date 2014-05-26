using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinaryDAL;
using Entities;

namespace BusinessComponents
{
    public static class PersonRoleComponents
    {
        public static void AddPersonRole(string roleName, Guid ID)
        {
            var myPR = new PersonRole(roleName, ID);
            var PRList = Logic.ReadAll(myPR.GetType());
            bool consistPR = false;

            foreach (Genre item in PRList)
            {
                if (item.Name == roleName)
                    consistPR = true;
            }

            if (!consistPR)
            {
                Logic.Create(myPR, ID);
            }

        }
    }
}
