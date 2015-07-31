using System;
using System.Collections.Generic;
using System.Text;
using Caliburn.Micro;
using EventAggregatorDemo.Events;

namespace EventAggregatorDemo.ViewModels
{
    public class Screen4ViewModel : Screen, IHandle<MainPageButtonPressedEvent>
    {
        private readonly IEventAggregator _eventAggregator;
        private string _eventText;
        public string EventText
        {
            get { return _eventText; }
            set
            {
                _eventText = value;
                NotifyOfPropertyChange(() => EventText);
            }
        }

        public Screen4ViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;          
        }

        protected override void OnActivate()
        {
            base.OnActivate();
            _eventAggregator.Subscribe(this);
        }

        protected override void OnDeactivate(bool close)
        {
            base.OnDeactivate(close);
            _eventAggregator.Unsubscribe(this);
        }

        public void Handle(MainPageButtonPressedEvent message)
        {
            EventText = "The button in the appbar has been clicked";
        }
    }
}
