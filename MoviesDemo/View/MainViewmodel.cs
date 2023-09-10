using MoviesDemo.Core;
using MoviesDemo.Domain;
using MoviesDemo.UseCases;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace MoviesDemo.View
{
    public class MainViewmodel: BaseViewmodel
    {
       

        public MainViewmodel(GetMoviesUseCase useCase)
        {
            _useCase = useCase;
        }

        private ObservableCollection<string> _orderBy = new List<string>() {
            "Ordenar por Año", 
            "Ordenar por Título", 
            "Ordenar por Duración", 
            "Posteriores a 2012",
            "Buscar"
        }.ToObservableCollection();
        private string _ActionSelected = "Año";
        private Movie _MovieSelected;
        private readonly GetMoviesUseCase _useCase;
        private string _SearchText = "";


        public ICommand MovieAction => new MovieCommand(ExecuteAction);

        public ObservableCollection<Movie> Movies
        {
            get
            {
               
                switch (ActionSelected)
                {
                    case "Ordenar por Año":
                        return _useCase.GetMoviesByYear();
                    case "Ordenar por Título":
                        return _useCase.GetMoviesByTitle();
                    case "Ordenar por Duración":
                        return _useCase.GetMoviesByDuration();
                    case "Buscar":
                        return _useCase.GetMoviesBySearch(SearchText);
                    default:
                        return _useCase.GetMoviesNextTo(2012);

                }
            }
        }

        

        public string ActionSelected
        {
            get { return _ActionSelected; }
            set 
            { 
                _ActionSelected = value;
                OnPropertyChanged(nameof(ActionSelected));
                OnPropertyChanged(nameof(Movies));
                OnPropertyChanged(nameof(SearchIsEnabled));
            }
        }


        public string SearchText
        {
            get { return _SearchText; }
            set
            { 
                _SearchText = value;
                OnPropertyChanged(nameof(SearchText));
                OnPropertyChanged(nameof(Movies));
            }
        }

        public Movie MovieSelected
        {
            get { return _MovieSelected; }
            set
            { 
                _MovieSelected = value;
                OnPropertyChanged(nameof(MovieSelected));
                OnPropertyChanged(nameof(EditIsEnabled));
            }
        }

        public ObservableCollection<string> OrderBy
        {
            get { return _orderBy; }
            set { _orderBy = value; }
        }

        public bool EditIsEnabled => MovieSelected != null;
        public bool SearchIsEnabled => ActionSelected == "Buscar";

        private void ExecuteAction(object parameter)
        {
           
            switch (parameter.ToString())
            {
                case "Add":
                    ShowMessage("Pelicula añadida...");
                    break;
                case "Delete":
                    ShowMessage("Pelicula borrada...");
                    Movies.Remove(MovieSelected);

                    break;
                case "Edit":
                    ShowMessage("Pelicula actualizada...");
                    break;
                default:
                    break;
            }                
           

        }
	}
}
