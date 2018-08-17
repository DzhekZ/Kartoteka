using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;

namespace Kartoteka.Client.WPFApp.ViewModels
{
    public class MainWindowVM : ReactiveObject, IRoutableViewModel
    {
        public ReactiveCommand ExitFromApplicationCommand { get; }
        public ReactiveCommand ShowChitateliMainCommand { get; }

        public MainWindowVM()
        {
            // Set properties
            // Create commands
            ExitFromApplicationCommand = ReactiveCommand.Create(ExitFromApplication);
            ShowChitateliMainCommand = ReactiveCommand.Create(ShowChitateliMain);

        }

        private void ExitFromApplication()
        {
            App.Current.Shutdown();
        }
        private void ShowChitateliMain()
        {
            // Navigate to ChitateliMainViewModel 
            App.Router.Navigate.Execute(new ChitateliMainVM()).Subscribe();

        }
        public IScreen HostScreen { get; protected set; }
        public string UrlPathSegment { get; protected set; }
    }
}
