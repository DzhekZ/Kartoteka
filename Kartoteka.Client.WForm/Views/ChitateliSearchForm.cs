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
    public partial class ChitateliSearchForm : Form, IViewFor<ChitateliSearchFormViewModel>
    {
        public ChitateliSearchForm(Model.KartotekaManage kartotekaManage, ref int _seluser)
        {
            InitializeComponent();
            ViewModel = new ChitateliSearchFormViewModel(kartotekaManage, ref _seluser);
            this.WhenActivated(d =>
            {
                d(this.OneWayBind(ViewModel, vm => vm.Status, v => v.toolStripStatusLabel1.Text));
                d(this.Bind(ViewModel, vm => vm.SearchStr, v => v.textBox1.Text));
                //bind datasoure
                d(this.OneWayBind(ViewModel, vm => vm.UsersForSearch, v => v.dataGridView1.DataSource));
                //bind commands
                d(this.BindCommand(ViewModel, vm => vm.ShowCommand, v => v.buttonShow));
                //d(this.BindCommand(ViewModel, vm => vm.SelectCommand, v => v.buttonSelect));
                //d(this.BindCommand(ViewModel, vm => vm.CancelCommand, v => v.buttonCancel));
                //bind selected row
                d(this.Bind(ViewModel, vm => vm.SelectedUser, v => v.dataGridView1.CurrentCell.RowIndex));
                d(this.OneWayBind(ViewModel, vm => vm.SelectedUser, v => v.toolStripStatusLabel1.Text, vm => string.Format("User: {0}", vm)));

            });
        }

        public ChitateliSearchFormViewModel ViewModel { get; set; }
        object IViewFor.ViewModel
        {
            get
            {
                return ViewModel;
            }
            set
            {
                ViewModel = (ChitateliSearchFormViewModel)value;
            }
        }
    }
}
