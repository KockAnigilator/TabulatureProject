using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TunerLibrary;
using TunerLibrary.DataSource;

namespace DemonLevTuner
{

    internal class Program
    {
        
        
        static void Main(string[] args)
        {
            
            TabulatureRepositoryImpl repository= new TabulatureRepositoryImpl();

            //repository.ShowAllTabs();
            //repository.UpdateTabs(5, 6);
            //repository.UpdateTabs(4, 5);
            //repository.ShowAllTabs();
            //repository.GetTabOnString(5);
            Song songSlipknot = new Song(1, "Psychosocial", "Metal", "Slipknot", 100);
            Song songRammstein = new Song(2, "Amour", "Industrial", "Rammstein", 100);
            Song song = new Song(0, "Englishman in New York", "Jazz", "Sting", 100);
            SongRepositoryImpl songRepository = new SongRepositoryImpl();
            List<Song> songList = songRepository.Read();


            List<long> tabs = new List<long>();
            List<long> position = new List<long>(); 
            List<long> StringIds = new List<long>();  


            Tabulature tabulature = TabulatureHelper.GetTabulature(songList.First().Id);


            //!!!
            String str = new String('-', position.ToArray().Count()); // Для держания интонации между табами 
            //!!!
            Console.WriteLine(tabulature.ToString());
            Console.ReadKey();

        }

    }
}
