using System;
using FriendStorage.Model;

namespace FriendStorage.UI.ViewModel
{
    public interface IFriendEditViewModel
    {
        void Load(int friendId);
        Friend Friend { get; }
    }
    public class FriendEditViewModel : ViewModelBase, IFriendEditViewModel
    {
        public Friend Friend
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Load(int friendId)
        {
            throw new NotImplementedException();
        }
    }
}
