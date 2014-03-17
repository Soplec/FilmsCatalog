using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcessLayer;
using Entities;

namespace BusinessComponents
{
    public static class FilmTypeComponents
    {
        private static FilmType uselessFT = new FilmType("agh", Guid.NewGuid());
        public static void AddFilmType(string FTName, Guid ID)
        {
            var myFilmType = new FilmType(FTName, ID);

                Logic.Create(myFilmType, ID);
        }
        public static List<Object> ReadAll()
        {
            return Logic.ReadAll(uselessFT.GetType());
        }
    }
}
