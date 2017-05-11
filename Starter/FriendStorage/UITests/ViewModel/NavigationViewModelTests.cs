using FriendStorage.UI.ViewModel;
using Xunit;
using FriendStorage.Model;
using FriendStorage.UI.DataProvider;
using System.Linq;
using System.Collections.Generic;


namespace UITests.ViewModel
{
    public class NavigationViewModelTests
    {
        [Fact]
        public void ShouldLoadFriends()
        {
            var viewModel = new NavigationViewModel(new NavigationDataProviderMock());
            viewModel.Load();
            Assert.Equal(2, viewModel.Friends.Count);

            var friend = viewModel.Friends.SingleOrDefault(f => f.Id == 1);
            Assert.NotNull(friend);
            Assert.Equal("Julia", friend.FirstName);

            friend = viewModel.Friends.SingleOrDefault(f => f.Id == 2);
            Assert.NotNull(friend);
            Assert.Equal("Thomas", friend.FirstName);
        }
        [Fact]
        public void ShouldLoadFriendsOnlyOnce()
        {
            var viewModel = new NavigationViewModel(new NavigationDataProviderMock());
            viewModel.Load();
            viewModel.Load();
            Assert.Equal(2, viewModel.Friends.Count);
        }
    }
    public class NavigationDataProviderMock : INavigationDataProvider
    {
        public IEnumerable<Friend> GetAllFriends()
        {
            yield return new Friend { Id = 1, FirstName = "Julia" };
            yield return new Friend { Id = 2, FirstName = "Thomas" };
        }
    }
}

