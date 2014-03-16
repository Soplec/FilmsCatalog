using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DataAcessLayer;


namespace BusinessComponents
{
    public class PersonComponents
    {
        private static Person uselessPerson;

        public static void AddPerson(string myName, Guid myID, Country myCountry)
        {
            Logic.Create(new Person(myName, myID, myCountry), myID);
        }

        public static List<Object> ReadAll()
        {
            return Logic.ReadAll(uselessPerson.GetType());
        }

        public static Person Read(Guid myGuid)
        {
            return (Person)Logic.Read(uselessPerson.GetType(), myGuid);
        }

        public static void Delete(Guid myGuid)
        {
            Logic.Delete(uselessPerson.GetType(), myGuid);
        }

        public static List<Person> FindAllByNamePart(string NamePart)
        {
            List<Object> myList = Logic.ReadAll(uselessPerson.GetType());
            var findedPersons = new List<Person>();
            foreach (Person item in myList)
            {
                if (item.Name.Contains(NamePart))
                {
                    findedPersons.Add(item);
                }
            }
            return findedPersons;
        }

       public static void AddFilmPartake(Guid personID, Guid filmID, PersonRole role)
        {
            var myPerson = new Person();
            var myFilm = new Film();

            myPerson = (Person)Logic.Read(myPerson.GetType(), personID);
            myFilm = (Film)Logic.Read(myFilm.GetType(), filmID);
            var myPersonFilmsID = myPerson.FilmsID;
            var myPersonRoles = myPerson.Roles;
            var myFilmPersons = myFilm.PersonsID;

            Array.Resize(ref myPersonFilmsID, myPersonFilmsID.Count() + 1);
            Array.Resize(ref myPersonRoles, myPersonFilmsID.Count() + 1);
            Array.Resize(ref myFilmPersons, myPersonFilmsID.Count() + 1);

            myPersonFilmsID[myPersonFilmsID.Count() - 1] = filmID;
            myPersonRoles[myPersonRoles.Count() - 1] = role;
            myFilmPersons[myFilmPersons.Count() - 1] = personID;

            myPerson.FilmsID = myPersonFilmsID;
            myPerson.Roles = myPersonRoles;
            myFilm.PersonsID = myFilmPersons;

            Logic.Update(myPerson, myPerson.ID);
            Logic.Update(myFilm, myFilm.ID); 
        }   

    }
}
