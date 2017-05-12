
using System;
using FriendStorage.UI.ViewModel;
using Moq;
using Xunit;

namespace UITests.ViewModel
{
    public class MainViewModelTest
    {
        private Mock<INavigationViewModel> _navigationViewModelMock;
        private MainViewModel _viewModel;

        public MainViewModelTest()
        {
            _navigationViewModelMock = new Mock<INavigationViewModel>();
            _viewModel = new MainViewModel(_navigationViewModelMock.Object);
        }
        [Fact]
        public void ShouldCallLoadMethodOfNavigationViewModel()
        {
            _viewModel.Load();
            _navigationViewModelMock.Verify(vm=>vm.Load(), Times.Once);
        }
    }
}
