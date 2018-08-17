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
using Kartoteka.Client.WPFApp.ViewModels;

namespace Kartoteka.Client.WPFApp.Views
{
  /// <summary>
  /// Interaction logic for ChitateliMain.xaml
  /// </summary>
  public partial class ChitateliMain : UserControl, IViewFor<ChitateliMainVM>
  {
    public ChitateliMain()
    {
      InitializeComponent();
      ChitateliMainViewModel = new ChitateliMainVM();
    }

    //public static readonly DependencyProperty ChitateliMainViewModelProperty = DependencyProperty.Register("ChitateliMainViewModel", typeof(ChitateliMainVM), typeof(ChitateliMain));
    public ChitateliMainVM ChitateliMainViewModel
    {
      get;
      set;
    }
    object IViewFor.ViewModel
    {
      get
      {
        return ChitateliMainViewModel;
      }
      set
      {
        ChitateliMainViewModel = (ChitateliMainVM)value;
      }
    }
    ChitateliMainVM IViewFor<ChitateliMainVM>.ViewModel
    {
      get
      {
        return ChitateliMainViewModel;
      }
      set
      {
        ChitateliMainViewModel = value;
      }
    }
  }
}
