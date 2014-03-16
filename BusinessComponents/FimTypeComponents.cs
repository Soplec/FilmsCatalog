using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcessLayer;
using Entities;

namespace BusinessComponents
{
    class FimTypeComponents
    {
        public static void AddFilmType(string FTName, Guid ID)
        {
            var myFilmType = new FilmType(FTName, ID);
            var FTList = Logic.ReadAll(myFilmType.GetType());
            bool consistFilmType = false;

            foreach (FilmType item in FTList)
            {
                if (item.Name == FTName)
                    consistFilmType = true;
            }

            if (!consistFilmType)
            {
                Logic.Create(myFilmType, ID);
                
            }

        }
    }
}
