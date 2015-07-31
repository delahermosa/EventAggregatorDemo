using System;
using System.Collections.Generic;
using System.Text;
using Caliburn.Micro;
using EventAggregatorDemo.Events;

namespace EventAggregatorDemo.ViewModels
{
    public class MainPageViewModel : Conductor<Screen>.Collection.AllActive
    {
        private readonly Screen1ViewModel _screen1ViewModel;
        private readonly Screen2ViewModel _screen2ViewModel;
        private readonly Screen3ViewModel _screen3ViewModel;
        private readonly Screen4ViewModel _screen4ViewModel;
        private readonly IEventAggregator _eventAggregator;

        public MainPageViewModel(Screen1ViewModel screen1ViewModel, Screen2ViewModel screen2ViewModel, Screen3ViewModel screen3ViewModel, Screen4ViewModel screen4ViewModel, IEventAggregator eventAggregator)
        {
            _screen1ViewModel = screen1ViewModel;
            _screen2ViewModel = screen2ViewModel;
            _screen3ViewModel = screen3ViewModel;
            _screen4ViewModel = screen4ViewModel;
            _eventAggregator = eventAggregator;
        }

        protected override void OnActivate()
        {
            base.OnActivate();
            ActivateItem(_screen1ViewModel);
            ActivateItem(_screen2ViewModel);
            ActivateItem(_screen3ViewModel);
            ActivateItem(_screen4ViewModel);
        }

        protected override void OnDeactivate(bool close)
        {
            base.OnDeactivate(close);
            DeactivateItem(_screen1ViewModel, close);
            DeactivateItem(_screen2ViewModel, close);
            DeactivateItem(_screen3ViewModel, close);
            DeactivateItem(_screen4ViewModel, close);
        }

        public void Play()
        {
            _eventAggregator.PublishOnUIThread(new MainPageButtonPressedEvent());
        }
    }
}
