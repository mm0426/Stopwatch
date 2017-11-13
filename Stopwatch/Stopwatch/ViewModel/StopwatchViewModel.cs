﻿using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Stopwatch.ViewModel
{
    using Model;
    // todo: implement the code commented below in an icommand interface
    // https://developer.xamarin.com/guides/xamarin-forms/xaml/xaml-basics/data_bindings_to_mvvm/

    /*
     void OnStartButtonClicked(object sender, EventArgs args)
        {
            if (StopwatchViewModel.IsRunning())
            {
                StartStopButton.Text = "Start";
                _viewModel.Stop();
            }
            else
            {
                StartStopButton.Text = "Stop";
                _viewModel.Start();
            }
        }
        void OnResetButtonClicked(object sender, EventArgs arg)
        {
            _viewModel.Reset();
        }
         */
    class StopwatchViewModel : INotifyPropertyChanged
    {
        private string _TimerTime;
        public string TimerTime
        {
            get
            {
                return _TimerTime;
            }
            private set {
                _TimerTime = value;
                NotifyPropertyChanged("TimerTime");
            }
        }
           
        
   
        private StopwatchModel _StopwatchInstance = new StopwatchModel();

        public StopwatchViewModel()
        {
            TimerTime = "0:00";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged (string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool IsRunning()
        {
            return _StopwatchInstance.IsRunning();
        }
        
        public void Stop()
        {
            _StopwatchInstance.Stop();
        }

        public void Start()
        {
            _StopwatchInstance.Start();
            TimerTime = "1:00";
            Device.StartTimer(TimeSpan.FromMilliseconds(50), _timerTick);
        }

        public void Reset()
        {
            _StopwatchInstance.Reset();
        }

        private bool _timerTick()
        {
            // System.TimeSpan? elapsed = DateTime.Now.Subtract((_StopwatchInstance.Started);

            TimeSpan? elapsed = DateTime.Now - _StopwatchInstance.Started;
            TimerTime = elapsed.ToString();
            if (_StopwatchInstance.Started == null)
                return false;
            else
                return true;
        }
    }
}
