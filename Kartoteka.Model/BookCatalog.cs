using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using ReactiveUI;

namespace Kartoteka.Model
{
    public class BookCatalog
    {

    #region Members
        private Book _book;
        private bool _bookPresent;
        private bool _bookChoose;
        private DateTime _whenBookOut;
        private User _userIssued;
        #endregion

        #region Properties
        public int ID { get; set; }
        public Book Book
        {
            get
            {
              return _book;
            }
            set
            {
              _book = value;
            }
        }
        public bool BookPresent
        {
            get
            {
                return _bookPresent;
            }
            set
            {
                //this.RaiseAndSetIfChanged(ref _bookPresent, value);
                _bookPresent = value;
            }
        }
        public bool BookChoose
        {
            get
            {
                return _bookChoose;
            }
            set
            {
        //this.RaiseAndSetIfChanged(ref _bookChoose, value);
        _bookChoose = value;
            }
        }
        public DateTime WhenBookOut
        {
            get
            {
                return _whenBookOut;
            }
            set
            {
        //this.RaiseAndSetIfChanged(ref _whenBookOut, value);
        _whenBookOut = value;
            }
        }
        public User UserIssued
        {
            get
            {
                return _userIssued;
            }
            set
            {
        //this.RaiseAndSetIfChanged(ref _userIssued, value);
        _userIssued = value;
            }
        }
    #endregion

        public BookCatalog(Book book, int id)
        {
            ID = id;
            Book = book;
            BookPresent = true;
            BookChoose = false;
            WhenBookOut = KartotekaSettings.Default.MinDate;
            UserIssued = User.users.FirstOrDefault();
        }

    }
}
