using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ReactiveUI;
using ReacUI.Client.ViewModels;

namespace ReacUI.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window , IViewFor<MainWindowViewModel>
  {
   public MainWindow()
   {
      MainWindowViewModel ViewModel = new MainWindowViewModel();
      InitializeComponent();

        this.OneWayBind(ViewModel, vm => vm.ChitateliKartotekiView, v => v.dataGrid.ItemsSource);
        this.OneWayBind(ViewModel, vm => vm.StatusString, v => v.statusRow.Text);
        this.BindCommand(ViewModel, vm => vm.MenuChitateliCommand, v => v.MenuChitateli);
        this.BindCommand(ViewModel, vm => vm.ExitFromApplicationCommand, v => v.MenuExit);
        //this.BindCommand(ViewModel, vm => vm.SelectRowNumberCommand, v => v.bSelect);
        //this.Bind(ViewModel, vm => vm.CurrentDateForm, v => v.CurrentDate.DisplayDate);
   }

    #region ViewModel Setup
    public MainWindowViewModel ViewModel { get; set; }
    object IViewFor.ViewModel
    {
     get => ViewModel;
     set => ViewModel = (MainWindowViewModel)value;
    }
    #endregion
  }
}
