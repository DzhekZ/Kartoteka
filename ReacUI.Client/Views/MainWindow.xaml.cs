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
    public partial class MainWindow : Window, IViewFor<MainWindowViewModel>
    {
        public MainWindow()
        {
            InitializeComponent();
            ViewModel = new MainWindowViewModel();
            this.OneWayBind(ViewModel, vm => vm.usersForView, v => v.dataGrid.ItemsSource);
            this.OneWayBind(ViewModel, vm => vm.SelectedRow, v => v.selectedRow.Text, p => string.Format("Selected row num: {0}", p));
            this.BindCommand(ViewModel, vm => vm.ShowChitateliMainCommand, v => v.MenuChitateli);
            this.BindCommand(ViewModel, vm => vm.ExitFromApplicationCommand, v => v.MenuExit);
            this.BindCommand(ViewModel, vm => vm.ExitFromApplicationCommand, v => v.bSelect);

            //this.WhenAnyValue(v => v.dataGrid.SelectedIndex).ToProperty(ViewModel, p => p.SelectedRow);
        }

        public MainWindowViewModel ViewModel { get; set; }
        object IViewFor.ViewModel
        {
            get => ViewModel;
            set { ViewModel = (MainWindowViewModel)value; }
        }
    }
}
