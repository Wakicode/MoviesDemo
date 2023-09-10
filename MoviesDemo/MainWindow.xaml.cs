using MoviesDemo.Data.API;
using System.Windows;

namespace MoviesDemo
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = App.MyViewmodel;
        }


    }
}
