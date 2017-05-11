using System.Collections.Generic;
using FriendStorage.Model;

namespace FriendStorage.UI.DataProvider
{
    public interface INavigationDataProvider
    {
        IEnumerable<Friend> GetAllFriends();
    }
}
