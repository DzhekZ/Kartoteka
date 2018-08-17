using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;

namespace Kartoteka.Client.ViewModels
{
    public class MainWindowViewModel : ReactiveObject
    {
        public ReactiveCommand ExitFromApplicationCommand { get; }
        public ReactiveCommand ShowChitateliMainCommand { get; }

        public MainWindowViewModel()
        {
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
            // Navigate to ChitateliMain 
            Views.ChitateliMain chitateliMain = new Views.ChitateliMain();
            chitateliMain.ShowDialog();
        }
    }
}
