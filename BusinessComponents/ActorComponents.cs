using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcessLayer;
using Entities;

namespace BusinessComponents
{
    class ActorComponents
    {
        private static Actor uselessActor;

        public static void AddActor(string myName, Guid myID, Country myCountry)
        {
            Logic.Create(new Actor(myName, myID, myCountry), myID);
        }

        public static List<Object> ReadAll()
        {
            return Logic.ReadAll(uselessActor.GetType());
        }

        public static Actor Read(Guid myGuid)
        {
            return (Actor)Logic.Read(uselessActor.GetType(), myGuid);
        }

        public static void Delete(Guid myGuid)
        {
            Logic.Delete(uselessActor.GetType(), myGuid);
        }

        public static List<Actor> FindAllByNamePart(string NamePart)
        {
            List<Object> myList = Logic.ReadAll(uselessActor.GetType());
            var findedActors = new List<Actor>();
            foreach (Actor item in myList)
            {
                if (item.Name.Contains(NamePart))
                {
                    findedActors.Add(item);
                }
            }
            return findedActors;
        }

        public static void AddFilmID(Guid ActorGuid, Guid FilmGuid)
        {
            Actor myActor = (Actor)Logic.Read(uselessActor.GetType(), ActorGuid);
            var newFilmsArray = myActor.FilmsID;
            Array.Resize(ref newFilmsArray, myActor.FilmsID.Length + 1);
            newFilmsArray[newFilmsArray.Length - 1] = FilmGuid;
            myActor.FilmsID = newFilmsArray;
            Logic.Update(myActor, myActor.ID);
        }

        public static void AddActorRate(Guid myActorID, int value, Guid myUserID)
        {
            var newRate = new ActorRate(myActorID, value, myUserID);
        }


    }
}
