﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;


namespace ViewTuner.Repo
{
    internal class UserRepository
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
                User user = new User
                {
                    Id = 0,
                    Login = "Roman",
                    Password = "12345"
                };

                // Get the product
                int userId = await Register(user);

                await Console.Out.WriteLineAsync("РЕГАЕМСЯ");
                await Console.Out.WriteLineAsync(Convert.ToString(userId));

                userId = await Login(user);
                await Console.Out.WriteLineAsync("ЛОГИНИМСЯ");
                await Console.Out.WriteLineAsync(Convert.ToString(userId));



            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }


        static async Task<User> GetUserAsync(string path)
        {
            User user = null;


            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                user = DataSerializer.Deserialize<User>(await response.Content.ReadAsStringAsync());
            }
            return user;
        }

        static async Task<int> Register(User user)
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.PostAsync(
                "register", JsonContent.Create(user));
            response.EnsureSuccessStatusCode();

            int userResponse = 0;
            if (response.IsSuccessStatusCode)
            {
                userResponse = DataSerializer.Deserialize<int>(await response.Content.ReadAsStringAsync());
            }
            return userResponse;
        }

        static async Task<int> Login(User user)
        {

            HttpResponseMessage response = await client.PostAsync(
                "login", JsonContent.Create(user));
            response.EnsureSuccessStatusCode();

            int userResponse = 0;
            if (response.IsSuccessStatusCode)
            {
                userResponse = DataSerializer.Deserialize<int>(await response.Content.ReadAsStringAsync());
            }
            return userResponse;
        }
    }

}
