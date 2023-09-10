using MoviesDemo.Domain;
using MoviesDemo.UseCases.Abstractions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesDemo.Data.API
{
    public class MovieAPI: IMovieAPI
    {
        private readonly string _urlAPI;

        public MovieAPI(string urlAPI)
        {
            _urlAPI = urlAPI;
        }

        public IEnumerable<Movie> GetAllMovies()
        {

            var json = File.ReadAllText(_urlAPI);

            var objectsFromJson = JsonConvert.DeserializeObject<IEnumerable<Movie>>(json);
            

            return objectsFromJson;
        }

        public IEnumerable<Movie> MapperMovies()
        {
            // simulacion de una conversión de datos
            return GetAllMovies();
        }
    }
}
