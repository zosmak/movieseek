using Movieseek.Models;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace Movieseek.Services
{
    public class OMDBService
    {
        #region constructor
        HttpClient _client;

        public OMDBService()
        {
            _client = new HttpClient();
        }
        #endregion

        public async Task<OMDBMoviesResult> GetMoviesList(int page, string name)
        {
            // build request params from configs
            string request = $"{ConfigurationManager.AppSettings["OMDBAPI.Address"]}/?apikey={ConfigurationManager.AppSettings["OMDBAPI.Key"]}&s={name}&page={page}";
            HttpResponseMessage result = await _client.GetAsync(request);
            if (result.IsSuccessStatusCode)
            {
                string resultContent = await result.Content.ReadAsStringAsync();
                OMDBMoviesResult OMDBMoviesResult = JsonConvert.DeserializeObject<OMDBMoviesResult>(resultContent);
                return OMDBMoviesResult;
            }
            else
            {
                throw new Exception("Request wasn't successfull");
            }
        }
    }
}