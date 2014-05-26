using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinaryDAL;
using Entities;

namespace BusinessComponents
{
    public static class UserComponents
    {
        private static User uselessUser = new User();

        public static void AddUser(Guid myID, string myName, string password)
        {
            Logic.Create(new User(myID, myName, password), myID);
        }

        public static List<Object> ReadAll()
        {
            return Logic.ReadAll(uselessUser.GetType());
        }

        public static User Read(Guid myGuid)
        {
            return (User)Logic.Read(uselessUser.GetType(), myGuid);
        }

        public static void Delete(Guid myGuid)
        {
            Logic.Delete(uselessUser.GetType(), myGuid);
        }

        public static List<User> FindAllByNamePart(string NamePart)
        {
            List<Object> myList = Logic.ReadAll(uselessUser.GetType());
            var findedUsers = new List<User>();
            foreach (User item in myList)
            {
                if (item.Name.Contains(NamePart))
                {
                    findedUsers.Add(item);
                }
            }
            return findedUsers;
        }
    }
}
