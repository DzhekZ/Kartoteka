using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using ReactiveUI;
using Kartoteka.Model;

namespace ReacUI.Client.ViewModels
{
    public class MainWindowViewModel : ReactiveObject
    {
        private KartotekaManage KartotekaManagement { get; } = new KartotekaManage();
        public IReactiveDerivedList<User> usersForView;
        public ReactiveCommand ExitFromApplicationCommand { get; }

        public ReactiveCommand ShowChitateliMainCommand { get; }
        public ReactiveCommand SelectRowNumberCommand { get; }
        private int _selectedrow = 0;
        public int SelectedRow
        {
            get => _selectedrow;
            set { this.RaiseAndSetIfChanged(ref _selectedrow, value); }
        }

        public MainWindowViewModel()
        {
            // Create commands
            ExitFromApplicationCommand = ReactiveCommand.Create(ExitFromApplication);
            ShowChitateliMainCommand = ReactiveCommand.CreateFromTask(ShowChitateliMain);
            SelectRowNumberCommand = ReactiveCommand.Create(SelectRowNumber);
            usersForView = KartotekaManagement.ChitateliKartoteki.CreateDerivedCollection(u => u.User);
        }

        private void ExitFromApplication()
        {
            //
        }
        private async Task ShowChitateliMain()
        {
            // Navigate to ChitateliMain 
            //Views.ChitateliMain chitateliMain = new Views.ChitateliMain();
            //chitateliMain.ShowDialog();
            //KartotekaManagement.ChitateliKartoteki.Add(new Chitateli(new User("user", "0", "1"), KartotekaManagement.CurrentDate, 1));
            /*Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(async () =>
            {
            }));*/
                 KartotekaManagement.AddNewUser("user", "0", "1");
           await Task.CompletedTask;
            //this.RaisePropertyChanged("usersForView");
        }
        private void SelectRowNumber()
        {
            //
        }
    }
}
