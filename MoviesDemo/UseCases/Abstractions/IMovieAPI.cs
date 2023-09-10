using MoviesDemo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesDemo.UseCases.Abstractions
{
    public interface IMovieAPI
    {

        IEnumerable<Movie> GetAllMovies();

        IEnumerable<Movie> MapperMovies();
       
    }
}
