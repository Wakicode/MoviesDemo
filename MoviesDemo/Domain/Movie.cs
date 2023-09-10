using MoviesDemo.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WkSoftware.Core;

namespace MoviesDemo.Domain
{
    public class Movie : ModelBase
    {
        #region Fields

        private string title;
        private int year;
        private string rated;
        private DateTime released;
        private double runtimeMinutes;
        private string genre;
        private string director;
        private string writer;
        private string actors;
        private string plot;
        private string language;
        private string country;
        private string awards;
        private string poster;
        private string _UrlPoster;
        private string metascore;
        private string imdbRating1;
        private string imdbVotes1;
        private string imdbID1;
        private string type;
        private string response;
        private ObservableCollection<string> images;
        #endregion

        #region Properties


        public string Title
        {
            get => title;
            set
            {
                title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
        public int Year
        {
            get => year;
            set
            {
                year = value;
                OnPropertyChanged(nameof(Year));
            }
        }
        public string Rated
        {
            get => rated;
            set
            {
                rated = value;
                OnPropertyChanged(nameof(Rated));
            }
        }
        public DateTime Released
        {
            get => released;
            set
            {
                released = value;
                OnPropertyChanged(nameof(Released));
            }
        }
        public double RuntimeMinutes
        {
            get => runtimeMinutes;
            set
            {
                runtimeMinutes = value;
                OnPropertyChanged(nameof(RuntimeMinutes));
            }
        }
        public string Genre
        {
            get => genre;
            set
            {
                genre = value;
                OnPropertyChanged(nameof(Genre));
            }
        }
        public string Director
        {
            get => director;
            set
            {
                director = value;
                OnPropertyChanged(nameof(Director));
            }
        }
        public string Writer
        {
            get => writer;
            set
            {
                writer = value;
                OnPropertyChanged(nameof(Writer));
            }
        }
        public string Actors
        {
            get => actors;
            set
            {
                actors = value;
                OnPropertyChanged(nameof(Actors));
            }
        }
        public string Plot
        {
            get => plot;
            set
            {
                plot = value;
                OnPropertyChanged(nameof(Plot));
            }
        }
        public string Language
        {
            get => language; set
            {
                language = value;
                OnPropertyChanged(nameof(Language));
            }
        }
        public string Country
        {
            get => country;
            set
            {
                country = value;
                OnPropertyChanged(nameof(Country));
            }
        }
        public string Awards
        {
            get => awards;
            set
            {
                awards = value;
                OnPropertyChanged(nameof(Awards));
            }
        }
        public string Poster
        {
            get => poster;
            set
            {
                poster = value;
                OnPropertyChanged(nameof(Poster));
            }
        }

        public string UrlPoster
        {
            get => _UrlPoster;
            set
            {
                _UrlPoster = value;
                OnPropertyChanged(nameof(UrlPoster));
            }
        }
        public string Metascore
        {
            get => metascore;
            set
            {
                metascore = value;
                OnPropertyChanged(nameof(Metascore));
            }
        }
        public string ImdbRating
        {
            get => imdbRating1;
            set
            {
                imdbRating1 = value;
                OnPropertyChanged(nameof(ImdbRating));
            }
        }
        public string ImdbVotes
        {
            get => imdbVotes1;
            set
            {
                imdbVotes1 = value;
                OnPropertyChanged(nameof(ImdbVotes));
            }
        }
        public string ImdbID
        {
            get => imdbID1;
            set
            {
                imdbID1 = value;
                OnPropertyChanged(nameof(ImdbID));
            }
        }
        public string Type
        {
            get => type;
            set
            {
                type = value;
                OnPropertyChanged(nameof(Type));
            }
        }
        public string Response
        {
            get => response;
            set
            {
                response = value;
                OnPropertyChanged(nameof(Response));
            }
        }
        public ObservableCollection<string> Images
        {
            get => images;
            set
            {
                images = value;
                OnPropertyChanged(nameof(Images));
            }
        }



        #endregion


        #region ReadOnly

        public string Duration => TimeTools.GetTimeHM(RuntimeMinutes * 60);
        public ImageSource PosterImage => Tools.GetImageFromPath($"{App.urlAPI}\\{Poster}");
     
        #endregion
    }
}
