
using System;
using System.Collections.Generic;
using System.Linq;
using FriendStorage.UI.Events;
using FriendStorage.UI.ViewModel;
using Moq;
using Prism.Events;
using Xunit;

namespace UITests.ViewModel
{
    public class MainViewModelTest
    {
        private Mock<INavigationViewModel> _navigationViewModelMock;
        private MainViewModel _viewModel;
        private Mock<IEventAggregator> _eventAggregatorMock;
        private OpenFriendEditViewEvent _openFriendEditViewEvent;
        private List<Mock<IFriendEditViewModel>> _friendEditViewModelMocks;

        public MainViewModelTest()
        {
            _navigationViewModelMock = new Mock<INavigationViewModel>();
            _friendEditViewModelMocks = new List<Mock<IFriendEditViewModel>>();
            _openFriendEditViewEvent = new OpenFriendEditViewEvent();
            _eventAggregatorMock = new Mock<IEventAggregator>();
            _eventAggregatorMock.Setup(ea => ea.GetEvent<OpenFriendEditViewEvent>()).Returns(_openFriendEditViewEvent);

            _viewModel = new MainViewModel(_navigationViewModelMock.Object, CreateFriendEditViewModel, _eventAggregatorMock.Object);
        }

        private IFriendEditViewModel CreateFriendEditViewModel()
        {
            var friendEditViewModelMock = new Mock<IFriendEditViewModel>();
            _friendEditViewModelMocks.Add(friendEditViewModelMock);
            return friendEditViewModelMock.Object;
        }

        [Fact]
        public void ShouldCallLoadMethodOfNavigationViewModel()
        {
            _viewModel.Load();
            _navigationViewModelMock.Verify(vm=>vm.Load(), Times.Once);
        }

        [Fact]
        public void ShouldAddFriendEditViewModelAndLoadAndSelectIt()
        {
            const int friendId = 7;
            _openFriendEditViewEvent.Publish(friendId);
            Assert.Equal(1, _viewModel.FriendEditViewModels.Count);
            var firstEditVM = _viewModel.FriendEditViewModels.First();
            Assert.Equal(firstEditVM, _viewModel.SelectedFriendEditViewModel);
            _friendEditViewModelMocks.First().Verify(vm => vm.Load(friendId), Times.Once);
        }
    }
}
