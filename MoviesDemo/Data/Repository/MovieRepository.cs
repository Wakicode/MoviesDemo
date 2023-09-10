using MoviesDemo.Data.API;
using MoviesDemo.Domain;
using MoviesDemo.UseCases.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesDemo.Data.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly IMovieAPI _api;

        public MovieRepository(IMovieAPI api)
        {
            _api = api;
        }

        public void AddMovie(Movie movie)
        {
            // todo añadir pelicula
        }

        public void DeleteMovie(Movie movie)
        {
            // borrar pelicula
        }

        public IEnumerable<Movie> GetMovies()
        {
            return _api.GetAllMovies();
        }

        public IEnumerable<Movie> GetMovies(string text)
        {
            return _api.GetAllMovies().Where(x=> $"{x.Title} {x.Actors} {x.Director} {x.Country} {x.Year}".ToLower().Contains(text.ToLower()));
        }

        public void SaveChanges()
        {
            // todo guardar cambios
        }

        public void UpdateMovie(Movie movie)
        {
            // todo actualizar pelicula
        }
    }
}
