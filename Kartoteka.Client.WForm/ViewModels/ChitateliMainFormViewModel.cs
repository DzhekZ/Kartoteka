using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using Kartoteka.Model;

namespace Kartoteka.Client.WForm.ViewModels
{
    public class ChitateliMainFormViewModel : ReactiveObject
    {
        public KartotekaManage KartotekaManage;
        private bool AddOrEdit { get; set; }
        public string Status { get; set; }
        public string CurrentDate
        {
            get => KartotekaManage.CurrentDate.ToLongDateString();
        }
        private User newUser;
        private User _viewUser;
        public User ViewUser
        {
            get
            {
                return _viewUser;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _viewUser, value);
            }
        }
        private int _numberUser;
        public int NumberUser
        {
            get
            {
                return _numberUser;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _numberUser, value);
            }
        }
        private bool _manageControl;
        public bool ManageControl
        {
            get
            {
                return _manageControl;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _manageControl, value);
            }
        }
        public ReactiveCommand AddCommand { get; }
        public ReactiveCommand EditCommand { get; }
        public ReactiveCommand DelCommand { get; }
        public ReactiveCommand SaveCommand { get; }
        public ReactiveCommand CancelCommand { get; }
        public ReactiveCommand FindCommand { get; }

        public ChitateliMainFormViewModel(KartotekaManage kartotekaManage)
        {
            KartotekaManage = kartotekaManage;
            AddCommand = ReactiveCommand.Create(AddFunc);
            EditCommand = ReactiveCommand.Create(EditFunc);
            DelCommand = ReactiveCommand.Create(DelFunc);
            SaveCommand = ReactiveCommand.Create(SaveFunc);
            CancelCommand = ReactiveCommand.Create(CancelFunc);
            FindCommand = ReactiveCommand.Create(FindFunc);
            Status = "form loaded";
            NumberUser = 0;
            ViewUser = kartotekaManage.ChitateliKartoteki[NumberUser].User;
            ManageControl = true;
            //this.RaisePropertyChanged("ManageControl");
        }

        private void AddFunc()
        {
            newUser = new User("", "", "");
            ViewUser = newUser;
            ManageControl = false;
            AddOrEdit = true;
        }

        private void EditFunc()
        {
            ManageControl = false;
            AddOrEdit = false;
        }

        private void DelFunc()
        {

        }

        private void SaveFunc()
        {

            if (!string.IsNullOrWhiteSpace(ViewUser.FirstName) && !string.IsNullOrWhiteSpace(ViewUser.SecondName) && !string.IsNullOrWhiteSpace(ViewUser.ThirdName))
            {
                if (AddOrEdit)
                {
                    //add item
                    if (KartotekaManage.CanAddNewUser(ViewUser))
                    {
                        KartotekaManage.AddNewUser(ViewUser);
                        NumberUser = KartotekaManage.ChitateliKartoteki.Count - 1;
                        ViewUser = KartotekaManage.ChitateliKartoteki[NumberUser].User;
                    };
                }
                else
                {
                    //edit item
                    KartotekaManage.EditCurrentUser(ViewUser, NumberUser);
                };
                ManageControl = true;
            }
            else
            {
                Status = "необходимо заполнить поля";
                this.RaisePropertyChanged("Status");
                ManageControl = false;
            };
        }

        private void CancelFunc()
        {
            ManageControl = true;
            ViewUser = KartotekaManage.ChitateliKartoteki[NumberUser].User;
        }

        private void FindFunc()
        {
            Views.ChitateliSearchForm chitateliSearchForm = new Views.ChitateliSearchForm(KartotekaManage, ref _numberUser);
            if (chitateliSearchForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ViewUser = KartotekaManage.ChitateliKartoteki[NumberUser].User;
            };
        }
    }
}
