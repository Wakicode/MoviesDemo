using MoviesDemo.Data.API;
using MoviesDemo.Data.Repository;
using MoviesDemo.UseCases;
using MoviesDemo.UseCases.Abstractions;
using MoviesDemo.View;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows;

namespace MoviesDemo
{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static MainViewmodel MyViewmodel { get; set; }




        public static string urlAPI { get; set; } = "C:\\Desarrollo\\MicrosoftDev\\MoviesDemo\\DataMovies\\Films";


        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            IMovieAPI _myMovieApi = new MovieAPI($"{urlAPI}\\Films.json");
            IMovieRepository repository = new MovieRepository(_myMovieApi);
            var useCase = new GetMoviesUseCase(repository);

            MyViewmodel = new MainViewmodel(useCase);

        }

    }
}
