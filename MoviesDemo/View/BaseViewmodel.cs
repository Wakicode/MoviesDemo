using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace MoviesDemo.View
{
    public class BaseViewmodel : INotifyPropertyChanged
    {

        public BaseViewmodel()
        {
            timer.Interval = new TimeSpan(0, 0, 5);
            timer.Tick += (e, s) =>
            {
                ClearMessage();
            };
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(String propertyName) => this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private string _Message;
        private bool _ProgressBarIsVisible = false;
        DispatcherTimer timer = new DispatcherTimer();


        public bool ProgressBarIsVisible
        {
            get { return _ProgressBarIsVisible; }
            set
            {
                _ProgressBarIsVisible = value;
                OnPropertyChanged(nameof(ProgressBarIsVisible));
            }
        }
        public string Message
        {
            get { return _Message; }
            set
            {
                _Message = value;
                OnPropertyChanged(nameof(Message));
            }
        }

        private void ClearMessage()
        {
            ProgressBarIsVisible = false;
            Message = "";
            timer.Stop();
        }
        public void ShowMessage(string message)
        {

            ProgressBarIsVisible = false;
            MessageToTypeWriter(message);
        }

        public void MessageToTypeWriter(string message)
        {
            Message = "";

            Task.Run(() =>
            {
                foreach (var item in message)
                {
                    Message += item;
                    Task.Delay(15).Wait();
                }
                timer.Start();
            });
        }
    }
}
