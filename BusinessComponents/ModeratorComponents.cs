using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinaryDAL;
using Entities;

namespace BusinessComponents
{
    public static class ModeratorComponents
    {
        private static Moderator uselessModerator = new Moderator();

        public static void AddModerator(Guid myID, string myName, string password)
        {
            Logic.Create(new Moderator(myID, myName, password), myID);
        }

        public static List<Object> ReadAll()
        {
            return Logic.ReadAll(uselessModerator.GetType());
        }

        public static Moderator Read(Guid myGuid)
        {
            return (Moderator)Logic.Read(uselessModerator.GetType(), myGuid);
        }

        public static void Delete(Guid myGuid)
        {
            Logic.Delete(uselessModerator.GetType(), myGuid);
        }

        public static List<Moderator> FindAllByNamePart(string NamePart)
        {
            List<Object> myList = Logic.ReadAll(uselessModerator.GetType());
            var findedModerators = new List<Moderator>();
            foreach (Moderator item in myList)
            {
                if (item.Name.Contains(NamePart))
                {
                    findedModerators.Add(item);
                }
            }
            return findedModerators;
        }
    }
}
