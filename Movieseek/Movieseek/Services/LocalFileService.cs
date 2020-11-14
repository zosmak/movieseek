using Movieseek.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

namespace Movieseek.Services
{
    public class LocalFileService
    {
        #region constructor
        public List<Movie> localMovies;
        private readonly string filePath = $"{ConfigurationManager.AppSettings["DATABASE.Path"]}/{ConfigurationManager.AppSettings["DATABASE.File"]}";

        public LocalFileService()
        {
            localMovies = LoadMoviesFromFile();
        }
        #endregion

        // load list from saved file
        public List<Movie> LoadMoviesFromFile()
        {
            try
            {
                // check if file exists
                if (File.Exists(filePath))
                {
                    using (var sr = new StreamReader(filePath))
                    {
                        // read the stream as a string
                        string fileValue = sr.ReadToEnd();
                        Movie[] movies = JsonConvert.DeserializeObject<Movie[]>(fileValue);

                        if (movies != null && movies.Length > 0)
                        {
                            List<Movie> moviesList = movies.OfType<Movie>().ToList();
                            return moviesList;
                        }
                        return new List<Movie>();
                    }
                }
                else
                {
                    Directory.CreateDirectory(ConfigurationManager.AppSettings["DATABASE.Path"]);

                    // create file and return an empty list
                    File.Create(filePath).Close();
                    return new List<Movie>();
                }
            }
            catch (IOException e)
            {
                throw new Exception(e.Message);
            }
        }

        // save current list in file
        public void SaveMoviesFromFile(List<Movie> movies)
        {
            string valueToSave = JsonConvert.SerializeObject(movies);

            // clear file data
            File.WriteAllText(filePath, string.Empty);


            // write text to .txt file
            using (StreamWriter sw = File.AppendText(filePath))
            {
                sw.WriteLine(valueToSave);
            }
        }
    }
}
