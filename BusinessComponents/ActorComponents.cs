using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcessLayer;
using Entities;

namespace BusinessComponents
{
    public static class ActorComponents
    {
        private static Actor uselessActor = new Actor();

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
            var uselessUser = new User();
            var newRate = new ActorRate(myActorID, value, myUserID);

            Actor myActor = (Actor)Logic.Read(uselessActor.GetType(), myActorID);
            User myUser = (User)Logic.Read(uselessUser.GetType(), myUserID);

            var newRatesArray = myActor.Rates;           
            Array.Resize(ref newRatesArray, myActor.Rates.Length + 1);
            newRatesArray[newRatesArray.Length - 1] = newRate;
            myActor.Rates = newRatesArray;

            var newUserRatesArray = myUser.UserActorsRates;
            Array.Resize(ref newUserRatesArray, newUserRatesArray.Length + 1);
            newUserRatesArray[newUserRatesArray.Length - 1] = newRate;
            myUser.UserActorsRates = newUserRatesArray;

            int Rate = 0;
            int RatesCount = 0;
            foreach(ActorRate item in myActor.Rates)
            {
                Rate += item.Value;
                RatesCount += 1;
            }
            myActor.Rate = Rate / RatesCount;

            Logic.Update(myActor, myActorID);
            Logic.Update(myUser, myUserID);

        }


    }
}
