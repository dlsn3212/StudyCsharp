using Prism.Events;
using Prism.Mvvm;
using PrismApp.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace RightModule.ViewModels
{
    public class MessageListViewModel : BindableBase
    {
        IEventAggregator _ea;
        //Messages
        private ObservableCollection<string> messages;
        public ObservableCollection<string> Messages
        {
            get => messages;
            set => SetProperty(ref messages, value);
        }

        public MessageListViewModel(IEventAggregator ea)            //Prism이 들어가야만 보낼수있게 필터링
        {
            _ea = ea;
            Messages = new ObservableCollection<string>();
            _ea.GetEvent<MessageSentEvent>().Subscribe(MessageReceived,ThreadOption.PublisherThread, false,
                            filter => filter.Contains("Prism"));
        }

        private void MessageReceived(string messages)           //메세지 받은거 list로 추가
        {
            Messages.Add(messages);  
        }
    }
}
