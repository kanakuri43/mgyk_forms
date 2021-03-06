using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using mgyk_forms.Views;

namespace mgyk_forms.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;

        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            _regionManager.RegisterViewWithRegion("ContentRegion", typeof(Dashboard));

            LogoutCommand = new DelegateCommand(LogoutCommandExecute);

        }
        public DelegateCommand LogoutCommand { get; }
        private void LogoutCommandExecute()
        {
            _regionManager.RequestNavigate("ContentRegion", nameof(Dashboard));
        }
    }
}
