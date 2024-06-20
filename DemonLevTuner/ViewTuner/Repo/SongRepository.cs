using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebTuner;


namespace ViewTuner.Repo
{
    internal class SongRepository
    {
        public static readonly HttpClient client = new HttpClient();

        private static async Task Main(string[] args)
        {
            client.BaseAddress = new Uri("http://localhost:5118/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                // Create a new product
                Song song = new Song
                {
                    Id = 0,
                    Bpm = 0,
                    Author = "None",
                    Genre = "None",
                    SongName = "None"
                };
                // Get the product
                int SongId = await GetSong(song);

                await Console.Out.WriteLineAsync("Получаем Песни");
                await Console.Out.WriteLineAsync(Convert.ToString(SongId));

                SongId = await PostTabulature(song);
                await Console.Out.WriteLineAsync("Постим Песни");
                await Console.Out.WriteLineAsync(Convert.ToString(SongId));

                SongId = await DeleteTabulature(song);
                await Console.Out.WriteLineAsync("Дэлитим Песни");
                await Console.Out.WriteLineAsync(Convert.ToString(SongId));

                SongId = await PutTabulature(song);
                await Console.Out.WriteLineAsync("Путим Песни");
                await Console.Out.WriteLineAsync(Convert.ToString(SongId));




            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }


        static async Task<Tabulature> GetSongAsync(string path)
        {
            Song song = null;


            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                song = DataSerializer.Deserialize<User>(await response.Content.ReadAsStringAsync())!;
            }
            return song;
        }

        static async Task<int> GetSong(Song song)
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.PostAsJsonAsync(
                "GetSong", song);
            response.EnsureSuccessStatusCode();

            int SongResponse = 0;
            if (response.IsSuccessStatusCode)
            {
                SongResponse = DataSerializer.Deserialize<int>(await response.Content.ReadAsStringAsync())!;
            }
            return SongResponse;
        }

        static async Task<int> PostSong(Song song)
        {

            HttpResponseMessage response = await client.PostAsJsonAsync(
                "PostSong", song);
            response.EnsureSuccessStatusCode();

            int SongResponse = 0;
            if (response.IsSuccessStatusCode)
            {
                SongResponse = DataSerializer.Deserialize<int>(await response.Content.ReadAsStringAsync())!;
            }
            return SongResponse;
        }

        static async Task<int> DeleteSong(Song song)
        {

            HttpResponseMessage response = await client.PostAsJsonAsync(
                "DeleteSong", song);
            response.EnsureSuccessStatusCode();

            int SongResponse = 0;
            if (response.IsSuccessStatusCode)
            {
                SongResponse = DataSerializer.Deserialize<int>(await response.Content.ReadAsStringAsync())!;
            }
            return SongResponse;
        }


        static async Task<int> PutSong(Song song)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "Putsong", song);
            response.EnsureSuccessStatusCode();

            int SongResponse = 0;
            if (response.IsSuccessStatusCode)
            {
                SongResponse = DataSerializer.Deserialize<int>(await response.Content.ReadAsStringAsync())!;
            }
            return SongResponse;
        }

    }
}
