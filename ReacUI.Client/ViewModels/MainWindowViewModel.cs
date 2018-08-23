using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using ReactiveUI;
using Kartoteka.Model;

namespace ReacUI.Client.ViewModels
{
    public class MainWindowViewModel : ReactiveObject
    {
        private KartotekaManage KartotekaManagement { get; } = new KartotekaManage();
        private IScheduler _mainScheduler;
        public IReactiveDerivedList<User> usersForView;
        
        public ReactiveCommand ExitFromApplicationCommand { get; }
        public ReactiveCommand SelectRowNumberCommand { get; }
        public ReactiveCommand ShowChitateliMainCommand { get; }
        private int _selectedrow = 0;
        public int SelectedRow
        {
            get => _selectedrow;
            set { this.RaiseAndSetIfChanged(ref _selectedrow, value); }
        }

        public MainWindowViewModel(IScheduler mainScheduler)
        {
            if (mainScheduler == null) return;

            _mainScheduler = mainScheduler;
            //KartotekaManagement.PropertyChanged += (s, e) => { this.RaisePropertyChanged(e.PropertyName); };
            // Create commands
            ExitFromApplicationCommand = ReactiveCommand.Create(ExitFromApplication);
            SelectRowNumberCommand = ReactiveCommand.Create(SelectRowNumber);
            ShowChitateliMainCommand = ReactiveCommand.(ShowChitateliMain);
            usersForView = KartotekaManagement.ChitateliKartoteki.CreateDerivedCollection(u => u.User);
        }

    private Task ShowChitateliMain(Unit arg)
    {
      Action action = () => KartotekaManagement.ChitateliKartoteki.Add(new Chitateli(new User("user", "0", "1"), KartotekaManagement.CurrentDate, 1));
      _mainScheduler.ScheduleAsync(_mainScheduler,null, action);
      await Task.Run(() => action);
      return true;
    }

    private void ExitFromApplication()
        {
            //
        }
        private void ShowChitateliMain()
        {
 
      //Action action = () => KartotekaManagement.ChitateliKartoteki.Add(new Chitateli(new User("user", "0", "1"), KartotekaManagement.CurrentDate, 1));
      //_mainScheduler.ScheduleAsync(action);
      //usersForView = null;
      //_mainScheduler.Schedule(action);
      // Navigate to ChitateliMain 
      //Views.ChitateliMain chitateliMain = new Views.ChitateliMain();
      //chitateliMain.ShowDialog();
      //KartotekaManagement.ChitateliKartoteki.Add(new Chitateli(new User("user", "0", "1"), KartotekaManagement.CurrentDate, 1));
      /*Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(async () =>
      {
      }));*/
      //RxApp.MainThreadScheduler.Schedule(TaskStatus.Running,(KartotekaManagement.AddNewUser("user", "0", "1"));
      //this.RaisePropertyChanged("usersForView");

    }

    private void Proc()
    {
      
      //Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
      //{
      //}));
    }
    private void SelectRowNumber()
        {
            //
        }
    }
}
