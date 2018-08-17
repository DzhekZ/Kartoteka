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
        private ReactiveList<Chitateli> _ChitateliKartoteki { get; }
        private ReactiveList<BookCatalog> _BooksCatalog { get; }
        public IReactiveDerivedList<Chitateli> ChitateliKartoteki;
        public IReactiveDerivedList<User> ChitateliKartotekiLight;
        public IReactiveDerivedList<BookCatalog> BooksCatalog;
        public IReactiveDerivedList<Book> BooksCatalogLight;
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
            _ChitateliKartoteki = new ReactiveList<Chitateli>(User.users.Select(u => new Chitateli(u, DateTime.Now.AddYears(-GetRandomNumber(1, 10)))));
            ChitateliKartoteki = _ChitateliKartoteki.CreateDerivedCollection(x => x);
            ChitateliKartotekiLight = _ChitateliKartoteki.CreateDerivedCollection(x => x.User);
            _BooksCatalog = new ReactiveList<BookCatalog>(Book.books.Select(b => new BookCatalog(b)));
            BooksCatalog = _BooksCatalog.CreateDerivedCollection(b => b);
            BooksCatalogLight = _BooksCatalog.CreateDerivedCollection(b => b.Book);
        }

        public static int GetRandomNumber(int min, int max)
        {
            lock (getrandom) // synchronize
            {
                return getrandom.Next(min, max);
            }
        }

        public bool CanAddNewUser(User user)
        {
            return _ChitateliKartoteki.Where(u => u.User.FullName == user.FullName.Trim()).Count() > 0 ? false : true;
        }

        public void AddNewUser(User user)
        {
            _ChitateliKartoteki.Add(new Chitateli(user, CurrentDate));
            this.RaisePropertyChanged("_ChitateliKartoteki");
        }

        public void EditCurrentUser(User user, int num)
        {
            _ChitateliKartoteki[num].User.FirstName = user.FirstName;
            _ChitateliKartoteki[num].User.SecondName = user.SecondName;
            _ChitateliKartoteki[num].User.ThirdName = user.ThirdName;
            _ChitateliKartoteki[num].User.Age = user.Age;
            this.RaisePropertyChanged("_ChitateliKartoteki");
        }

        public void AddNewBook(Book book)
        {
            _BooksCatalog.Add(new BookCatalog(book));
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
