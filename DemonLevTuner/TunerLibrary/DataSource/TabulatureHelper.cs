using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.JScript;
using ServiceStack.Text;

namespace TunerLibrary.DataSource
{
    public static class TabulatureHelper
    {
        //C:\Users\2\Desktop\UHU\DemonLevTunerUHU (1)\DemonLevTuner\DemonLevTuner\BD\DemLev.db
        private const string connectionS = "Data Source=C:\\Users\\2\\Desktop\\DemonLevTunerZhopauraedet (1)\\DemonLevTuner\\DemonLevTuner\\BD\\DemLev.db; FailIfMissing=False";

        /// <summary>
        /// Тут будет реализация форматирования табулатуры
        /// из базы данных в текст, а после и во вью с 
        /// выводом всего этого на экран
        /// </summary>
        /// <param name="answer"></param>
        /// 

        public static  string JoinP(string separator, List<long> values)
        {
            if (values == null)
            {
                throw new ArgumentNullException("values");
            }

            if ((object)separator == null)
            {
                separator = " ";
            }

            StringBuilder stringBuilder = new StringBuilder();
            string text = values.First().ToString();
            if ((object)text != null)
            {
                stringBuilder.Append(text);
            }

            for (int i = 1; i < values.Count(); i++)
            {
                stringBuilder.Append(separator); 
                stringBuilder.Append(values[i].ToString());
            }

            return stringBuilder.ToString();
        }



        public static Tabulature GetTabulature(int songId)
        { 

            List<int> tabs = new List<int>();
            List<int> pos = new List<int>();
            List<string> stringNames = new List<string>();
            List<int> stringIds= new List<int>();
            try
            {
                string sql = $"SELECT * FROM tabulature WHERE songId = {songId};";
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
                            tabs.Add((int)row.Field<Int64>("лад"));
                            
                            pos.Add((int)row.Field<Int64>("position"));

                            stringNames.Add((string)row.Field<string>("имя струны"));
                            stringIds.Add((int)row.Field<Int64>("stringId"));
                        }

                        return new Tabulature(tabs, pos, stringNames.Distinct().ToList(), stringIds);
                    }
                }
            }
            catch (SQLiteException ex)
            {
                throw ex;
            }
        }

    }
}
