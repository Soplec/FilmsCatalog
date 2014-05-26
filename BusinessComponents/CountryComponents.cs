using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinaryDAL;
using Entities;
namespace BusinessComponents
{
    public static class CountryComponents
    {
        public static void AddCountry(string countryName, Guid ID)
        {
            var myCountry = new Country(countryName, ID);
            var CountryList = Logic.ReadAll(myCountry.GetType());
            bool consistCountry = false;

            foreach (Country item in CountryList)
            {
                if (item.Name == countryName)
                    consistCountry = true;
            }

            if (!consistCountry)
            {
                Logic.Create(myCountry, ID);
            }

        }
    }
}
