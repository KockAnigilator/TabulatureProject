using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TunerLibrary;
using System.Net.Http.Json;
using System.Windows.Documents;
using System.Collections.Generic;


namespace ViewTuner.Repo
{

    public class SongsDataSource
    {
        public static readonly HttpClient client = new HttpClient();

        public SongsDataSource()
        {
            client.BaseAddress = new Uri("http://localhost:5118/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }


        public async Task<Song> GetSongAsync(string path)
        {
            Song song = null;


            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                song = DataSerializer.Deserialize<Song>(await response.Content.ReadAsStringAsync());
            }
            return song;
        }

        public async Task<List<Song>> GetSong()
        {

            HttpResponseMessage response = await client.GetAsync(
                "api/Songs");
            response.EnsureSuccessStatusCode();

            List<Song> SongResponse = new List<Song>();
            if (response.IsSuccessStatusCode)
            {
                SongResponse = DataSerializer.Deserialize<List<Song>>(await response.Content.ReadAsStringAsync());
            }
            return SongResponse;
        }

        public async Task<int> PostSong(Song song)
        {

            HttpResponseMessage response = await client.PostAsync(
                "api/Songs", JsonContent.Create(song));
            response.EnsureSuccessStatusCode();

            int SongResponse = 0;
            if (response.IsSuccessStatusCode)
            {
                SongResponse = DataSerializer.Deserialize<int>(await response.Content.ReadAsStringAsync());
            }
            return SongResponse;
        }

    }
}
