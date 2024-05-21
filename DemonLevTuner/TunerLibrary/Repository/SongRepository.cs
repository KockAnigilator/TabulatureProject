using ServiceStack;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using TunerLibrary.DataSource;

namespace TunerLibrary
{
    public interface SongRepository
    {
        List<Song> Read();
        void Delete(int songId);
        void Update(Song song, long idP);

        void UpdateAuthor(string Author, int id);
        void UpdateGenre(string Genre, long idP);
        void UpdateSongName(string songName, long idP);


        void Create(Song song);
    }

    public class SongRepositoryImpl : SongRepository
    {
        //C:\Users\jonik\OneDrive\Рабочий стол\DemonLevTuner\DemonLevTuner\BD\DemLev.db
        private const string connectionS = "datasource = C:\\Users\\2\\Desktop\\DemonLevTunerZhopauraedet (1)\\DemonLevTuner\\DemonLevTuner\\BD\\DemLev.db; FailIfMissing=False";
        public void Create(Song song)
        {
            try
            {
                string sql = $"INSERT INTO \"Song\" VALUES({song.Id}, \"{song.SongName}\", \"{song.Genre}\", \"{song.Author}\")";
                using (SQLiteConnection connection = new SQLiteConnection(connectionS))
                {
                    connection.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, connection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Delete(int songId)
        {
            try
            {
                string sql = $"DELETE FROM \"Song\" WHERE \"id\" = {songId}";
                using (SQLiteConnection connection = new SQLiteConnection(connectionS))
                {
                    connection.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, connection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SQLiteException ex)
            {
            }
        }
        public List<Song> Read()
        {
            List<Song> list = new List<Song>();
            try
            {
                string sql = "SELECT * FROM \"Song\";";
                using (SQLiteConnection connection = new SQLiteConnection(connectionS))
                {
                    connection.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, connection))
                    {
                        DataTable data = new DataTable();
                        SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
                        adapter.Fill(data);
                        foreach (DataRow row in data.Rows)
                        {
                            long id = row.Field<Int64>("id");
                            string songName = row.Field<string>("songName");
                            string genre= row.Field<string>("genre");
                            string author = row.Field<string>("author");
                            long bpm = row.Field<Int64>("bpm");

                            list.Add(new Song((int)id,songName,genre,author,(int)bpm)); 
                        }
                    }
                }
                                        
            }
            catch (SQLiteException ex)
            {
                throw ex;
            }
            return list;
        }
        public void UpdateGenre(string Genre, long idP)
        {
            try
            {
                string sql = $"UPDATE \"Song\" SET \"genre\" = \"{Genre}\" WHERE id = {idP};";
                using (SQLiteConnection connection = new SQLiteConnection(connectionS))
                {
                    connection.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, connection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine("Ошибка");
            }
        }

        public void UpdateSongName(string songName, long idP)
        {

            try
            {
                string sql = $"UPDATE \"Song\" SET songName = \"{songName}\" WHERE id = {idP};";
                using (SQLiteConnection connection = new SQLiteConnection(connectionS))
                {
                    connection.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, connection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine("Ошибка");
            }
        }
        public void UpdateAuthor(string Author, int id)
        {

            try
            {
                string sql = $"UPDATE \"Song\" SET author = \"{Author}\" WHERE id = {id};";
                using (SQLiteConnection connection = new SQLiteConnection(connectionS))
                {
                    connection.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, connection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine("Ошибка");
            }
        }
        public void Update(Song song, long idP)
        {

            try
            {
                string sql = $"UPDATE \"Song\" SET \"genre\" = \"{song.Genre}\", \"author\" = \"{song.Author}\", \"songName\" = \"{song.SongName}\" WHERE id = {idP};";
                using (SQLiteConnection connection = new SQLiteConnection(connectionS))
                {
                    connection.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, connection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine("Ошибка");
            }
        }
    }
}
