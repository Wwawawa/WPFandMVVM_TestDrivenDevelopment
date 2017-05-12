using System.Collections.ObjectModel;
using FriendStorage.UI.DataProvider;

namespace FriendStorage.UI.ViewModel
{
  public class MainViewModel : ViewModelBase
  {
        private FriendEditViewModel _selectedFriendEditViewModel;
        public MainViewModel(INavigationViewModel navigationViewModel)
        {
            NavigationViewModel = navigationViewModel;
            FriendEditViewModels = new ObservableCollection<FriendEditViewModel>();                
        }

        public INavigationViewModel NavigationViewModel { get; private set; }

        public ObservableCollection<FriendEditViewModel> FriendEditViewModels { get; set; }

        public FriendEditViewModel SelectedFriendEditViewModel
        {
            get
            {
                return _selectedFriendEditViewModel;
            }

            set
            {
                _selectedFriendEditViewModel = value;
            }
        }        
        public void Load()
        {
            NavigationViewModel.Load();
        }
    }
}
