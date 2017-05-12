using System;
using Prism.Events;
using System.Windows.Input;
using FriendStorage.UI.Command;

namespace FriendStorage.UI.ViewModel
{
    public class NavigationItemViewModel
    {
        public NavigationItemViewModel(int id, string displayMember, IEventAggregator eventAggregator)
        {
            Id = id;
            DisplayMember = displayMember;
            OpenFriendEditViewCommand = new DelegateCommand(OnFriendEditViewExecute);
        }

        private void OnFriendEditViewExecute(object obj)
        {
            throw new NotImplementedException();
        }

        public string DisplayMember { get; private set; }
        public int Id { get; private set; }

        public ICommand OpenFriendEditViewCommand { get; set; }
    }
}
