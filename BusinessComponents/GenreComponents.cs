using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DataAcessLayer;

namespace BusinessComponents
{
    class GenreComponents
    {
        public static void AddGenre(string genreName, Guid ID)
        {
            var myGenre = new Genre(genreName, ID);
            var GenreList = Logic.ReadAll(myGenre.GetType());
            bool consistGenre = false;

            foreach (Genre item in GenreList)
            {
                if (item.Name == genreName)
                    consistGenre = true;
            }

            if (!consistGenre)
            {
                Logic.Create(myGenre, ID);
            }

        }
    }
}
