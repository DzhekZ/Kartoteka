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
    public partial class ChitateliMainForm : Form, IViewFor<ChitateliMainFormViewModel>
    {
        public ChitateliMainForm(Model.KartotekaManage kartotekaManage)
        {
            InitializeComponent();
            ViewModel = new ChitateliMainFormViewModel(kartotekaManage);
            this.WhenActivated(d =>
            {
                d(this.OneWayBind(ViewModel, vm => vm.Status, v => v.toolStripStatusLabel1.Text));
                d(this.OneWayBind(ViewModel, vm => vm.CurrentDate, v => v.textBox1.Text));
                //bind control management status
                d(this.OneWayBind(ViewModel, vm => vm.ManageControl, v => v.textBox2.ReadOnly));
                d(this.OneWayBind(ViewModel, vm => vm.ManageControl, v => v.textBox3.ReadOnly));
                d(this.OneWayBind(ViewModel, vm => vm.ManageControl, v => v.textBox4.ReadOnly));
                d(this.OneWayBind(ViewModel, vm => vm.ManageControl, v => v.textBox5.ReadOnly));
                d(this.OneWayBind(ViewModel, vm => vm.ManageControl, v => v.comboBox1.Enabled, p => !p));
                d(this.OneWayBind(ViewModel, vm => vm.ManageControl, v => v.textBox6.ReadOnly));
                d(this.OneWayBind(ViewModel, vm => vm.ManageControl, v => v.buttonAdd.Enabled));
                d(this.OneWayBind(ViewModel, vm => vm.ManageControl, v => v.buttonEdit.Enabled));
                d(this.OneWayBind(ViewModel, vm => vm.ManageControl, v => v.buttonDel.Enabled));
                d(this.OneWayBind(ViewModel, vm => vm.ManageControl, v => v.buttonFind.Enabled));
                d(this.OneWayBind(ViewModel, vm => vm.ManageControl, v => v.buttonSave.Enabled, p => !p));
                d(this.OneWayBind(ViewModel, vm => vm.ManageControl, v => v.buttonCancel.Enabled, p => !p));
                //bind data model
                d(this.Bind(ViewModel, vm => vm.ViewUser.FirstName, v => v.textBox2.Text));
                d(this.Bind(ViewModel, vm => vm.ViewUser.SecondName, v => v.textBox3.Text));
                d(this.Bind(ViewModel, vm => vm.ViewUser.ThirdName, v => v.textBox4.Text));
                d(this.Bind(ViewModel, vm => vm.ViewUser.Number, v => v.textBox5.Text));
                d(this.Bind(ViewModel, vm => vm.ViewUser.Age, v => v.textBox6.Text));
                d(this.Bind(ViewModel, vm => vm.ViewUser.Gender, v => v.comboBox1.Text));
                //bind commands
                d(this.BindCommand(ViewModel, vm => vm.AddCommand, v => v.buttonAdd));
                d(this.BindCommand(ViewModel, vm => vm.EditCommand, v => v.buttonEdit));
                d(this.BindCommand(ViewModel, vm => vm.DelCommand, v => v.buttonDel));
                d(this.BindCommand(ViewModel, vm => vm.SaveCommand, v => v.buttonSave));
                d(this.BindCommand(ViewModel, vm => vm.CancelCommand, v => v.buttonCancel));
                d(this.BindCommand(ViewModel, vm => vm.FindCommand, v => v.buttonFind));
            });
            comboBox1.DataSource = Enum.GetValues(typeof(Model.User.Genders));
            //comboBox1.DisplayMember = "Gender";
            //comboBox1.ValueMember = "Gender";
        }

        public ChitateliMainFormViewModel ViewModel { get; set; }
        object IViewFor.ViewModel
        {
            get
            {
                return ViewModel;
            }
            set
            {
                ViewModel = (ChitateliMainFormViewModel)value;
            }
        }
    }
}
