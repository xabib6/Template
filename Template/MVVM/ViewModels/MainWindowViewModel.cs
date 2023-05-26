using System.Collections.ObjectModel;

namespace Template.MVVM.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        public BaseViewModel CurrentView { get => currentView; set => SetField(ref currentView, value); }
        private BaseViewModel currentView;
        public ObservableCollection<BaseViewModel> ViewModels { get; set; } = new();

        public MainWindowViewModel()
        {

        }
    }
}
