using MoviesDemo.Core;
using MoviesDemo.Domain;
using MoviesDemo.UseCases.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesDemo.UseCases
{
    public class GetMoviesUseCase
    {
        private readonly IMovieRepository _repository;

        public GetMoviesUseCase(IMovieRepository repository)
        {
            _repository = repository;
        }

        public ObservableCollection<Movie> GetMoviesByYear() => _repository
            .GetMovies()
            .OrderBy(it => it.Year)
            .ToObservableCollection();

        public ObservableCollection<Movie> GetMoviesByTitle() => _repository
            .GetMovies()
            .OrderBy(it => it.Title)
            .ToObservableCollection();

        public ObservableCollection<Movie> GetMoviesBySearch(string text) => _repository
           .GetMovies(text)
           .OrderBy(it => it.Title)
           .ToObservableCollection();

        public ObservableCollection<Movie> GetMoviesByDuration() => _repository
            .GetMovies()
            .OrderBy(it => it.Duration)
            .ToObservableCollection();
        public ObservableCollection<Movie> GetMoviesNextTo(int year = 2012) => _repository
           .GetMovies()
            .Where(it => it.Year > year)
           .OrderBy(it => it.Year)
           .ToObservableCollection();
    }
}
