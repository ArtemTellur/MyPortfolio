using _SSTU_MyPortfolio.Interfaces;
using _SSTU_MyPortfolio.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _SSTU_MyPortfolio.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            IMyPortfolioLogicAlbum logic = new AlbumLogic();
            var a = int.Parse(Console.ReadLine());
            var albums = logic.GetAlbumsOfUser(a);
            foreach (var item in albums)
            {
                Console.WriteLine(item.AlbumId + " " + item.AlbumName + " " + item.Description);
            }
            Console.ReadLine();
        }
    }
}
