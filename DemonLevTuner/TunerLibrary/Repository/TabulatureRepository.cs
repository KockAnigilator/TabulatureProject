using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TunerLibrary
{

    public interface TabulatureRepository
    {
        void UpdateTabs(int stringId, long TabsP);
        void GetTabOnString(int stringId);
    }

    public class TabulatureRepositoryImpl : TabulatureRepository
    {
        public TabulatureRepositoryImpl() { }

        //C:\Users\2\Desktop\DemonLev\DemonLevTunerWIP\DemonLevTuner\DemonLevTuner\BD\TunerDemonLevWIP.sqbpro
        private const string connectionS = "Data Source=C:\\Users\\jonik\\OneDrive\\Документы\\GitHub\\TabulatureProject\\DemonLevTuner\\DemonLevTuner\\BD\\DemLev.db; FailIfMissing=False";


        public void CreateTabulature(string StringName, int FretId)
        {
            try
            {
                string sql = $"INSERT INTO \"tabulature\" VALUES(NULL, \"{StringName}\",{FretId},0,0,NULL)";
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
        public void UpdateTabs(int stringId, long TabsP)
        {
            if (stringId <= 5 && stringId > 0)
            {
                try
                {
                    string sql = $"UPDATE \"tabulature\" SET лад = {TabsP} WHERE id = {stringId}";
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
            else
            {
                Console.WriteLine("У вас шестиструнная гитара!!");
            }
        }


        //Метод выводит только определённую струну с её табами
        public void GetTabOnString(int stringId)
        {
            if (stringId <= 5 && stringId > 0)
            {
                try
                {
                    string sql = "SELECT * FROM tabulature;";
                    using (SQLiteConnection connection = new SQLiteConnection(connectionS))
                    {
                        connection.Open();
                        using (SQLiteCommand cmd = new SQLiteCommand(sql, connection))
                        {
                            DataTable data = new DataTable();
                            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
                            adapter.Fill(data);
                            Console.WriteLine($"Прочитано {data.Rows.Count} записей из таблицы БД");
                            foreach (DataRow row in data.Rows)
                            {
                                if (stringId == row.Field<Int64>("id"))
                                {
                                    Console.WriteLine($"id = {row.Field<Int64>("id")} струна = {row.Field<string>("имя струны")} лад = {row.Field<Int64>("лад")}");
                                }
                            }
                        }
                    }
                }
                catch (SQLiteException ex)
                {
                    Console.WriteLine($"Ошибка доступа к базе данных. Исключение: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Ошибка");
            }


        }
        //Метод который будет выводить табулатуру
        public void ShowAllTabs()
        {
            try
            {
                string sql = "SELECT * FROM tabulature;";
                using (SQLiteConnection connection = new SQLiteConnection(connectionS))
                {
                    connection.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, connection))
                    {
                        DataTable data = new DataTable();
                        SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
                        adapter.Fill(data);
                        Console.WriteLine($"Прочитано {data.Rows.Count} записей из таблицы БД");
                        foreach (DataRow row in data.Rows)
                        {
                            Console.WriteLine($"id = {row.Field<Int64>("id")} струна = {row.Field<string>("имя струны")} лад = {row.Field<Int64>("лад")}");
                        }
                    }
                }
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine($"Ошибка доступа к базе данных. Исключение: {ex.Message}");
            }
        }

    }
}