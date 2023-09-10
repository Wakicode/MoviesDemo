using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesDemo.Core
{
    public static class Extension
    {
        public static void AddRange<T>(this ObservableCollection<T> observable, IEnumerable<T> collection)
        {
            if (collection != null)
            {
                foreach (var item in collection)
                {
                    observable.Add(item);
                }
            }
        }



        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> collection)
        {
            ObservableCollection<T> observable = new ObservableCollection<T>();
            observable.AddRange<T>(collection);
            return observable;
        }
    }
}
