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
    internal class TabulatureRepository
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
                Tabulature user = new Tabulature
                {
                    Id = 0,
                    Fret = 0,
                    Position = 0,
                    SongId = 0,
                    StringId = 0,
                    StringName = "Note"
                };
                // Get the product
                int TabulatureId = await GetTabulature(tabulature);

                await Console.Out.WriteLineAsync("Получаем Табы");
                await Console.Out.WriteLineAsync(Convert.ToString(TabulatureId));

                TabulatureId = await PostTabulature(tabulature);
                await Console.Out.WriteLineAsync("Постим табы");
                await Console.Out.WriteLineAsync(Convert.ToString(TabulatureId));

                TabulatureId = await DeleteTabulature(tabulature);
                await Console.Out.WriteLineAsync("Дэлитим табы");
                await Console.Out.WriteLineAsync(Convert.ToString(TabulatureId));

                TabulatureId = await PutTabulature(tabulature);
                await Console.Out.WriteLineAsync("Путим табы");
                await Console.Out.WriteLineAsync(Convert.ToString(TabulatureId));




            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }


        static async Task<Tabulature> GetTabulatureAsync(string path)
        {
            Tabulature tabulature = null;


            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                tabulature = DataSerializer.Deserialize<User>(await response.Content.ReadAsStringAsync())!;
            }
            return tabulature;
        }

        static async Task<int> GetTabulature(Tabulature tabulature)
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.PostAsJsonAsync(
                "GetTab", tabulature);
            response.EnsureSuccessStatusCode();

            int TabulatureResponse = 0;
            if (response.IsSuccessStatusCode)
            {
                TabulatureResponse = DataSerializer.Deserialize<int>(await response.Content.ReadAsStringAsync())!;
            }
            return TabulatureResponse;
        }

        static async Task<int> PostTabulature(Tabulature tabulature)
        {

            HttpResponseMessage response = await client.PostAsJsonAsync(
                "PostTab", tabulature);
            response.EnsureSuccessStatusCode();

            int TabulatureResponse = 0;
            if (response.IsSuccessStatusCode)
            {
                TabulatureResponse = DataSerializer.Deserialize<int>(await response.Content.ReadAsStringAsync())!;
            }
            return TabulatureResponse;
        }

        static async Task<int> DeleteTabulature(Tabulature tabulature)
        {

            HttpResponseMessage response = await client.PostAsJsonAsync(
                "DeleteTab", tabulature);
            response.EnsureSuccessStatusCode();

            int TabulatureResponse = 0;
            if (response.IsSuccessStatusCode)
            {
                TabulatureResponse = DataSerializer.Deserialize<int>(await response.Content.ReadAsStringAsync())!;
            }
            return TabulatureResponse;
        }


        static async Task<int> PutTabulature(Tabulature tabulature)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "PutTab", tabulature);
            response.EnsureSuccessStatusCode();

            int TabulatureResponse = 0;
            if (response.IsSuccessStatusCode)
            {
                TabulatureResponse = DataSerializer.Deserialize<int>(await response.Content.ReadAsStringAsync())!;
            }
            return TabulatureResponse;
        }

    }
}