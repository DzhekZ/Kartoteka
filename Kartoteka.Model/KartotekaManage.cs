using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;

namespace Kartoteka.Model
{
    public class KartotekaManage : ReactiveObject
    {
        private static readonly Random getrandom = new Random();
        public List<Chitateli> ChitateliKartoteki { get; }
        public IReactiveList<BookCatalog> BooksCatalog { get; }
        //public IReactiveDerivedList<Chitateli> ChitateliKartoteki;
        //public IReactiveDerivedList<User> ChitateliKartotekiLight;
        //public IReactiveDerivedList<BookCatalog> BooksCatalog;
        //public IReactiveDerivedList<Book> BooksCatalogLight;
        private DateTime _currentDate;
        public DateTime CurrentDate
        {
            get
            {
                return _currentDate;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _currentDate, value);
            }
        }

        public KartotekaManage()
        {
            CurrentDate = DateTime.Now.Date.AddDays(-3);
            //ChitateliKartoteki = new ReactiveList<Chitateli>(User.users.Select(u => new Chitateli(u, DateTime.Now.AddYears(-GetRandomNumber(1, 10)), GetLastIDInChitateli())));
            ChitateliKartoteki = new List<Chitateli>(User.users.Select(u => new Chitateli(u, DateTime.Now.AddYears(-GetRandomNumber(1, 10)), GetNewIDInChitateli())));
            //ChitateliKartoteki = ChitateliKartoteki.CreateDerivedCollection(x => x);
            //ChitateliKartotekiLight = ChitateliKartoteki.CreateDerivedCollection(x => x.User);
            BooksCatalog = new ReactiveList<BookCatalog>(Book.books.Select(b => new BookCatalog(b)));
            //BooksCatalog = BooksCatalog.CreateDerivedCollection(b => b);
            //BooksCatalogLight = BooksCatalog.CreateDerivedCollection(b => b.Book);
        }

        public static int GetRandomNumber(int min, int max)
        {
            lock (getrandom) // synchronize
            {
                return getrandom.Next(min, max);
            }
        }

        private int GetNewIDInChitateli()
        {
            return (ChitateliKartoteki != null) ? (ChitateliKartoteki.Max(x => x.ID)+1) : 1;
        }

        public bool CanAddNewUser(User user)
        {
            return ChitateliKartoteki.Where(u => u.User.FullName == user.FullName.Trim()).Count() > 0 ? false : true;
        }

        public void AddNewUser(User user)
        {
            ChitateliKartoteki.Add(new Chitateli(user, CurrentDate, GetNewIDInChitateli()));
            //this.RaisePropertyChanged("_ChitateliKartoteki");
        }
        public void AddNewUser(string fN, string sN, string tN)
        {
            User user = new User(fN, sN, tN);
            Chitateli chitateli = new Chitateli(user, CurrentDate, GetNewIDInChitateli());
            ChitateliKartoteki.Add(chitateli);
        }

        public void EditCurrentUser(User user, int num)
        {
            ChitateliKartoteki[num].User.FirstName = user.FirstName;
            ChitateliKartoteki[num].User.SecondName = user.SecondName;
            ChitateliKartoteki[num].User.ThirdName = user.ThirdName;
            ChitateliKartoteki[num].User.Age = user.Age;
            //this.RaisePropertyChanged("_ChitateliKartoteki");
        }

        public void AddNewBook(Book book)
        {
            BooksCatalog.Add(new BookCatalog(book));
        }

        public void BookChoose(int index)
        {
            //BookCatalog.ChangeBookChoose(index);
        }

        public void TransferBooksToAnotherUser(User user)
        {

        }
    }
}
