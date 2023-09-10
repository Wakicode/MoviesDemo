using MoviesDemo.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesDemo.UseCases.Abstractions
{
    public interface IMovieRepository
    {       
        IEnumerable<Movie> GetMovies();
        IEnumerable<Movie> GetMovies(string text);

        void AddMovie(Movie movie);
        void DeleteMovie(Movie movie);
        void UpdateMovie(Movie movie);

        void SaveChanges();
    }
}
