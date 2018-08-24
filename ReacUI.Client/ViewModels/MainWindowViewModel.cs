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
        #region Members
        private KartotekaManage KartotekaManagement = new KartotekaManage();
        public ReactiveCommand ExitFromApplicationCommand { get; }
        public ReactiveCommand SelectRowNumberCommand { get; }
        public ReactiveCommand ShowChitateliMainCommand { get; }
        private int _selectedrow = 0;
        private DateTime _currentDateForm;
        public ReactiveCommand CurrentDateCommand { get; }
        private string _statusString = "";
        #endregion

    #region Properties
    public IReactiveDerivedList<Chitateli> ChitateliKartoteki;
    public IReactiveDerivedList<User> ChitateliKartotekiLight;
    //public IReactiveDerivedList<BookCatalog> BooksCatalog;
    //public IReactiveDerivedList<Book> BooksCatalogLight;
    public int SelectedRow
    {
      get => _selectedrow;
      set { this.RaiseAndSetIfChanged(ref _selectedrow, value); }
    }

    public DateTime CurrentDateForm
    {
      get
      {
        return _currentDateForm;
      }
      set
      {
        this.RaiseAndSetIfChanged(ref _currentDateForm, value);
        KartotekaManagement.CurrentDate = CurrentDateForm;
      }
    }
    public string StatusString
    {
      get
      {
        return _statusString;
      }
      set
      {
        this.RaiseAndSetIfChanged(ref _statusString, value);
      }
    }
    #endregion

    #region Construction
    public MainWindowViewModel()
        {
            //KartotekaManagement.PropertyChanged += (s, e) => { this.RaisePropertyChanged(e.PropertyName); };
            // Create commands
            ExitFromApplicationCommand = ReactiveCommand.Create(ExitFromApplication);
            SelectRowNumberCommand = ReactiveCommand.Create(SelectRowNumber);
            ShowChitateliMainCommand = ReactiveCommand.Create(ShowChitateliMain);
            CurrentDateCommand = ReactiveCommand.Create(() => CurrentDateForm = KartotekaManagement.CurrentDate);
            this.WhenAnyValue(x => x.CurrentDateForm).Select(p => string.Format("Selected date: {0}", p.ToShortDateString())).ToProperty(this, p => p.StatusString);

            ChitateliKartoteki = KartotekaManagement.ChitateliKartoteki.CreateDerivedCollection(p => p);
            ChitateliKartotekiLight = KartotekaManagement.ChitateliKartoteki.CreateDerivedCollection(u => u.User);

      StatusString = string.Format("Loaded users - {0}", ChitateliKartotekiLight.Count);
      CurrentDateForm = KartotekaManagement.CurrentDate;
        }
    #endregion

    #region Commands and Procedures

    private void ExitFromApplication()
        {
            //
        }
        private void ShowChitateliMain()
        {
          KartotekaManagement.AddNewUser("user", "0", "1");
 
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
  #endregion
}
