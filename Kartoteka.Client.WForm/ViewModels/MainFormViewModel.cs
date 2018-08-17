using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using Kartoteka.Model;

namespace Kartoteka.Client.WForm.ViewModels
{
    public class MainFormViewModel : ReactiveObject
    {
        public KartotekaManage KartotekaManage { get; } = new KartotekaManage();
        public DateTime CurrentDateVM
        {
            get
            {
                return KartotekaManage.CurrentDate;
            }
            set
            {
                KartotekaManage.CurrentDate = value;
                this.RaisePropertyChanged("CurrentDateVM");
            }
        }
        private int _selectedUser;
        public int SelectedUser
        {
            get
            {
                return _selectedUser;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _selectedUser, value);
                this.RaisePropertyChanged("uFirstName");
                this.RaisePropertyChanged("uSecondName");
                this.RaisePropertyChanged("uThirdName");
                this.RaisePropertyChanged("uRegDate");
            }
        }
        public string uFirstName => KartotekaManage.ChitateliKartoteki[SelectedUser].User.FirstName;
        public string uSecondName => KartotekaManage.ChitateliKartoteki[SelectedUser].User.SecondName;
        public string uThirdName => KartotekaManage.ChitateliKartoteki[SelectedUser].User.ThirdName;
        public string uRegDate => KartotekaManage.ChitateliKartoteki[SelectedUser].RegisterDate.ToLongDateString();
        private int _selectedBook;
        public int SelectedBook
        {
            get
            {
                return _selectedBook;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _selectedBook, value);
                this.RaisePropertyChanged("bName");
                this.RaisePropertyChanged("bNumber");
                this.RaisePropertyChanged("bAuthor");
                this.RaisePropertyChanged("bUser");
            }
        }
        public string bName => KartotekaManage.BooksCatalogLight[SelectedBook].Name;
        public string bNumber => KartotekaManage.BooksCatalogLight[SelectedBook].InvNumber.ToString();
        public string bAuthor => KartotekaManage.BooksCatalogLight[SelectedBook].Author;
        public string bUser => (KartotekaManage.BooksCatalog[SelectedBook].UserIssued.FullName == KartotekaManage.ChitateliKartoteki[0].User.FullName) ? "в библиотеке" : KartotekaManage.BooksCatalog[SelectedBook].UserIssued.FullName;
        public ReactiveCommand ShowChitateliMainCommand { get; }
        public ReactiveCommand ExitFromApplicationCommand { get; }

        public MainFormViewModel()
        {
            ExitFromApplicationCommand = ReactiveCommand.Create(ExitFromApplication);
            ShowChitateliMainCommand = ReactiveCommand.Create(ShowChitateliMain);
        }

        private void ExitFromApplication()
        {
            //exit
        }
        private void ShowChitateliMain()
        {
            // Navigate to ChitateliMainForm
            Views.ChitateliMainForm chitateliMainForm = new Views.ChitateliMainForm(KartotekaManage);
            chitateliMainForm.ShowDialog();
        }

    }
}
