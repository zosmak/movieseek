using Movieseek.Models;
using Movieseek.Models.APIRequests;
using Movieseek.Models.APIResponses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Movieseek.Services
{
    public class APIService
    {
        #region constructor
        static HttpClient _client;
        static LoginResponse user;
        public static List<AddMovieResponse> movies;

        public APIService()
        {
        }

        public void InitializeAPIService()
        {
            _client = new HttpClient();
        }
        #endregion


        #region auth
        // login
        public async Task Login(string username, string password)
        {
            // build request params from configs
            string request = $"{ConfigurationManager.AppSettings["API.Address"]}/users/authenticate";
            var stringContent = new StringContent(JsonConvert.SerializeObject(
                new AuthenticateUserRequest()
                {
                    Username = username,
                    Password = password
                }),
                    Encoding.UTF8, "application/json");

            HttpResponseMessage result = await _client.PostAsync(request, stringContent); if (result.IsSuccessStatusCode)
            {
                // get typed response
                string resultContent = await result.Content.ReadAsStringAsync();
                LoginResponse LoginResponseResult = JsonConvert.DeserializeObject<LoginResponse>(resultContent);

                // set the default token to auth header
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LoginResponseResult.token);
                user = LoginResponseResult;
                movies = LoginResponseResult.movies;
            }
            else
            {
                throw new Exception($"{result.StatusCode} - Request wasn't successfull");
            }
        }

        // register a new user
        public async Task Register(string firstName, string lastName, string username, string password)
        {
            // build request params from configs
            string request = $"{ConfigurationManager.AppSettings["API.Address"]}/users/register";
            var stringContent = new StringContent(JsonConvert.SerializeObject(
                new RegisterUserRequest()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Username = username,
                    Password = password
                }),
                    Encoding.UTF8, "application/json");

            HttpResponseMessage result = await _client.PostAsync(request, stringContent);

            if (result.IsSuccessStatusCode)
            {
                // get typed response
                string resultContent = await result.Content.ReadAsStringAsync();
                LoginResponse LoginResponseResult = JsonConvert.DeserializeObject<LoginResponse>(resultContent);

                // set the default token to auth header
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LoginResponseResult.token);
                user = LoginResponseResult;
                movies = LoginResponseResult.movies;
            }
            else
            {
                throw new Exception($"{result.StatusCode} - Request wasn't successfull");
            }
        }
        #endregion


        #region movies
        public async Task<AddMovieResponse> AddNewMovie(string title, string year, string type)
        {
            // build request params from configs
            string request = $"{ConfigurationManager.AppSettings["API.Address"]}/movies";
            var stringContent = new StringContent(JsonConvert.SerializeObject(
                new AddMovieRequest()
                {
                    Title = title,
                    Year = year,
                    Type = type,
                    UserID = user.id
                }),
                    Encoding.UTF8, "application/json");

            HttpResponseMessage result = await _client.PostAsync(request, stringContent);

            if (result.IsSuccessStatusCode)
            {
                string resultContent = await result.Content.ReadAsStringAsync();
                AddMovieResponse AddMovieResponseResult = JsonConvert.DeserializeObject<AddMovieResponse>(resultContent);
                return AddMovieResponseResult;
            }
            else
            {
                throw new Exception($"{result.StatusCode} - Request wasn't successfull");
            }
        }

        public async Task RemoveMovie(string movieID)
        {
            // build request params from configs
            string request = $"{ConfigurationManager.AppSettings["API.Address"]}/movies/{movieID}";
            HttpResponseMessage result = await _client.DeleteAsync(request);

            if (!result.IsSuccessStatusCode)
            {
                throw new Exception($"{result.StatusCode} - Request wasn't successfull");
            }
        }
        #endregion
    }
}