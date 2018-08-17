using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReactiveUI;
using Kartoteka.Client.WForm.ViewModels;

namespace Kartoteka.Client.WForm.Views
{
    public partial class MainForm : Form, IViewFor<MainFormViewModel>
    {
        public MainForm()
        {
            InitializeComponent();
            ViewModel = new MainFormViewModel();

            this.WhenActivated(d =>
            {
                //bind current date
                d(this.Bind(ViewModel, vm => vm.CurrentDateVM, v => v.dtpCurrDate.Value));
                d(this.OneWayBind(ViewModel, vm => vm.CurrentDateVM, v => v.toolStripStatusLabel1.Text, vm => vm.ToShortDateString()));
                //bind list users
                //d(this.OneWayBind(ViewModel, vm => vm.KartotekaManage.ChitateliKartotekiLight, v => v.lBusers.DataSource));
                //d(this.Bind(ViewModel, vm => vm.SelectedUser, v => v.lBusers.SelectedIndex));
                //d(this.OneWayBind(ViewModel, vm => vm.SelectedUser, v => v.toolStripStatusLabel3.Text, vm => string.Format("User: {0}", vm)));

                //d(this.OneWayBind(ViewModel, vm => vm.uFirstName, v => v.textBox1.Text));
                //d(this.OneWayBind(ViewModel, vm => vm.uSecondName, v => v.textBox2.Text));
                //d(this.OneWayBind(ViewModel, vm => vm.uThirdName, v => v.textBox3.Text));
                //d(this.OneWayBind(ViewModel, vm => vm.uRegDate, v => v.textBox4.Text));
                //bind list books
                //d(this.OneWayBind(ViewModel, vm => vm.KartotekaManage.BooksCatalogLight, v => v.cLBbooks.DataSource));
                //d(this.Bind(ViewModel, vm => vm.SelectedBook, v => v.cLBbooks.SelectedIndex));
                //d(this.OneWayBind(ViewModel, vm => vm.SelectedBook, v => v.toolStripStatusLabel2.Text, vm => string.Format("Book: {0}", vm)));

                //d(this.OneWayBind(ViewModel, vm => vm.bName, v => v.textBox5.Text));
                //d(this.OneWayBind(ViewModel, vm => vm.bNumber, v => v.textBox6.Text));
                //d(this.OneWayBind(ViewModel, vm => vm.bAuthor, v => v.textBox7.Text));
                //d(this.OneWayBind(ViewModel, vm => vm.bUser, v => v.textBox8.Text));
                //bind button
                d(this.BindCommand(ViewModel, vm => vm.ShowChitateliMainCommand, v => v.usersToolStripMenuItem));
            });
            //lBusers.DisplayMember = "Fullname";
            //cLBbooks.DisplayMember = "Name";

        }

        public MainFormViewModel ViewModel { get; set; }
        object IViewFor.ViewModel
        {
            get
            {
                return ViewModel;
            }
            set
            {
                ViewModel = (MainFormViewModel)value;
            }
        }

    }

}
