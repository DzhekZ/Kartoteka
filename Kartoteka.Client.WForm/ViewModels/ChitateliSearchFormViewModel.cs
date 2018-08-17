using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using System.Reactive.Threading.Tasks;
using Kartoteka.Model;

namespace Kartoteka.Client.WForm.ViewModels
{
    public class ChitateliSearchFormViewModel : ReactiveObject
    {
        public KartotekaManage KartotekaManage;
        private string _searchStr;
        public string SearchStr
        {
            get
            {
                return _searchStr;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _searchStr, value);
            }
        }
        public string Status { get; set; }
        public ReactiveCommand ShowCommand { get; }
        //public ReactiveCommand CancelCommand { get; }
        //public ReactiveCommand SelectCommand { get; }
        private List<User> _userForSearch;
        public ICollection<User> UsersForSearch
        {
            get
            {
                return _userForSearch;
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
                
            }
        }

        public ChitateliSearchFormViewModel(KartotekaManage kartotekaManage, ref int _selectedUser)
        {
            KartotekaManage = kartotekaManage;
            ShowCommand = ReactiveCommand.Create(ShowFunc);
            //CancelCommand = ReactiveCommand.Create(CancelFunc);
            //SelectCommand = ReactiveCommand.Create(SelectFunc);
            SearchStr = "";
            _userForSearch = new List<User>();
            ShowFunc();
        }

        private void ShowFunc()
        {
            //search
            _userForSearch.Clear();
            _userForSearch = KartotekaManage.ChitateliKartotekiLight.Where(u => u.FirstName.StartsWith(SearchStr.Trim())).ToList();
            //UsersForSearch = _userForSearch.CreateDerivedCollection(u => u);
            this.RaisePropertyChanged("UserForSearch");
        }

        private void CancelFunc()
        {
            //close
        }

        private void SelectFunc()
        {
            //select row id
        }
    }
}
