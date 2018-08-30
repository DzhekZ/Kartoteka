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
    private ReactiveList<Chitateli> _chitateliKartotekiView;
    private readonly IChitateliKartotekiService _chitateliKartotekiService;
    private ReactiveList<User> _chitateliKartotekiLightView;
    private readonly IChitateliKartotekiLightService _chitateliKartotekiLightService;

    private int _selectedrow = 0;
    private DateTime _currentDateForm;
    private string _statusString = "";
    #endregion

    #region Properties
    //public ReactiveCommand CurrentDateCommand { get; }
    //public ReactiveCommand SelectRowNumberCommand { get; }
    public ReactiveCommand ExitFromApplicationCommand { get; }
    public ReactiveCommand<Unit, IEnumerable<Chitateli>> MenuChitateliCommand { get; private set; }

    public ReactiveList<Chitateli> ChitateliKartotekiView
    {
      get => _chitateliKartotekiView;
      set => this.RaiseAndSetIfChanged(ref _chitateliKartotekiView, value);
    }
    public ReactiveList<User> ChitateliKartotekiLightView
    {
      get => _chitateliKartotekiLightView;
      set => this.RaiseAndSetIfChanged(ref _chitateliKartotekiLightView, value);
    }
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
        return _currentDateForm = KartotekaManagement.CurrentDate;
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
      //SelectRowNumberCommand = ReactiveCommand.Create(SelectRowNumber);
      _chitateliKartotekiService = new ChitateliKartotekiService();
      //_chitateliKartotekiLightService = new ChitateliKartotekiLightService();
      ChitateliKartotekiView = new ReactiveList<Chitateli>();
      MenuChitateliCommand = ReactiveCommand.CreateFromTask(MenuChitateliCommandImpl);
      MenuChitateliCommand.ObserveOn(RxApp.MainThreadScheduler).Subscribe(MapChitateliKartotekiViewImpl);
      MenuChitateliCommand.Execute().Subscribe();

      //CurrentDateCommand = ReactiveCommand.Create(() => CurrentDateForm = KartotekaManagement.CurrentDate);
      //this.WhenAnyValue(x => x.CurrentDateForm).Select(p => string.Format("Selected date: {0}", p.ToShortDateString())).ToProperty(this, p => p.StatusString);


      StatusString = string.Format("Loaded users - {0}", ChitateliKartotekiView.Count);
      //CurrentDateForm = KartotekaManagement.CurrentDate;
    }
    #endregion

    #region Commands and Procedures

    private void ExitFromApplication()
    {
      //
      StatusString = "choosed exit command";
    }
    private void SelectRowNumber()
    {
      //
    }
    private async Task<IEnumerable<Chitateli>> MenuChitateliCommandImpl()
    {
      return await _chitateliKartotekiService.Get();
    }
    private void MapChitateliKartotekiViewImpl(IEnumerable<Chitateli> chitatelis)
    {
      using (ChitateliKartotekiView.SuppressChangeNotifications())
      {
        ChitateliKartotekiView.Clear();
        //chitatelis.ToObservable().Subscribe();
        ChitateliKartotekiView.AddRange(KartotekaManagement.ChitateliKartoteki.FindAll(x => x != null));
      }
    }
    private async Task<IEnumerable<User>> MenuChitateliLightCommandImpl()
    {
      return await _chitateliKartotekiLightService.Get();
    }
    private void MapChitateliKartotekiLightViewImpl(IEnumerable<Chitateli> chitatelis)
    {
      using (ChitateliKartotekiLightView.SuppressChangeNotifications())
      {
        ChitateliKartotekiLightView.Clear();
        //chitatelis.ToObservable().Subscribe();
        ChitateliKartotekiLightView.AddRange(KartotekaManagement.ChitateliKartotekiLight.FindAll(x => x != null));
      }
    }
  }
  #endregion
}
