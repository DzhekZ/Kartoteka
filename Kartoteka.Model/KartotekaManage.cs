using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using ReactiveUI;

namespace Kartoteka.Model
{
    public class KartotekaManage
    {
    #region Members
    private static readonly Random getrandom = new Random();
    private DateTime _currentDate;
    private List<Chitateli> _chitateliKartoteki;
    private List<User> _chitateliKartotekiLight;
    private List<BookCatalog> _booksCatalog;
    private List<Book> _booksCatalogLight;
    #endregion

    #region Properties
    public List<Chitateli> ChitateliKartoteki
    {
      get
      {
        return _chitateliKartoteki;
      }
      set
      {
        //this.RaiseAndSetIfChanged(ref _chitateliKartoteki, value);
        _chitateliKartoteki = value;
      }
    }
    public List<User> ChitateliKartotekiLight
    {
      get
      {
        return _chitateliKartotekiLight;
      }
      set
      {
        //this.RaiseAndSetIfChanged(ref _chitateliKartotekiLight, value);
        _chitateliKartotekiLight = value;
      }
    }
    public List<BookCatalog> BooksCatalog
    {
      get
      {
        return _booksCatalog;
      }
      set
      {
        //this.RaiseAndSetIfChanged(ref _booksCatalog, value);
        _booksCatalog = value;
      }
    }
    public List<Book> BooksCatalogLight
    {
      get
      {
        return _booksCatalogLight;
      }
      set
      {
        //this.RaiseAndSetIfChanged(ref _booksCatalogLight, value);
        _booksCatalogLight = value;
      }
    }
    public DateTime CurrentDate
    {
      get
      {
        return _currentDate;
      }
      set
      {
        //this.RaiseAndSetIfChanged(ref _currentDate, value);
        _currentDate = value;
      }
    }
    #endregion

    #region Construction
    public KartotekaManage()
    {
      CurrentDate = DateTime.Now.Date.AddDays(-3);
      ChitateliKartoteki = new List<Chitateli>(User.users.Select(u => new Chitateli(u, DateTime.Now.AddYears(-GetRandomNumber(1, 10)), GetNewIDInChitateli())));
      ChitateliKartotekiLight = new List<User>(User.users.Select(u => u));
      BooksCatalog = new List<BookCatalog>(Book.books.Select(b => new BookCatalog(b,GetNewIDInBookCatalog())));
      BooksCatalogLight = new List<Book>(Book.books.Select(b => b));
    }
    #endregion

    #region Commands and Procedures
    public static int GetRandomNumber(int min, int max)
    {
      lock (getrandom) // synchronize
      {
        return getrandom.Next(min, max);
      }
    }

    private int GetNewIDInChitateli()
    {
      return (ChitateliKartoteki != null) ? (ChitateliKartoteki.Max(x => x.ID) + 1) : 1;
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

    private int GetNewIDInBookCatalog()
    {
      return (BooksCatalog != null) ? (BooksCatalog.Max(x => x.ID) + 1) : 1;
    }

    public void AddNewBook(Book book)
    {
      //BooksCatalog.Add(new BookCatalog(book));
    }

    public void BookChoose(int index)
    {
      //BookCatalog.ChangeBookChoose(index);
    }

    public void TransferBooksToAnotherUser(User user)
    {
      //
    }
    #endregion


  }
}
