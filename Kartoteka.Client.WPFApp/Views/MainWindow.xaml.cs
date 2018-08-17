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
using Kartoteka.Client.WPFApp.ViewModels;
using ReactiveUI;

namespace Kartoteka.Client.WPFApp.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IViewFor<MainWindowVM>
    {
        public MainWindow()
        {
            InitializeComponent();
            //MainWindowViewModel = new MainWindowVM();
            //this.DataContext = MainWindowViewModel;
            //this.Bind(MainWindowVM,vm=>vm.Router,v=>)
        }

        static MainWindow()
        {
            //ViewModelProperty = DependencyProperty.Register("MainWindowViewModel", typeof(MainWindowVM), typeof(MainWindow));
        }
        //public static readonly DependencyProperty ViewModelProperty;
        public MainWindowVM MainWindowViewModel
        {
            get;
            set;
        }
        object IViewFor.ViewModel
        {
            get
            {
                return MainWindowViewModel;
            }
            set
            {
                MainWindowViewModel = (MainWindowVM)value;
            }
        }
        MainWindowVM IViewFor<MainWindowVM>.ViewModel
        {
            get
            {
                return MainWindowViewModel;
            }
            set
            {
                MainWindowViewModel = value;
            }
        }
    }
}
