using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;

namespace Kartoteka.Model
{
    public class BookCatalog : ReactiveObject
    {
        public Book Book
        {
            get;
        }
        private bool _bookPresent;
        public bool BookPresent
        {
            get
            {
                return _bookPresent;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _bookPresent, value);
            }
        }
        private bool _bookChoose;
        public bool BookChoose
        {
            get
            {
                return _bookChoose;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _bookChoose, value);
            }
        }
        private DateTime _whenBookOut;
        public DateTime WhenBookOut
        {
            get
            {
                return _whenBookOut;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _whenBookOut, value);
            }
        }
        private User _userIssued;
        public User UserIssued
        {
            get
            {
                return _userIssued;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _userIssued, value);
            }
        }

        public BookCatalog(Book book)
        {
            Book = book;
            BookPresent = true;
            BookChoose = false;
            WhenBookOut = KartotekaSettings.Default.MinDate;
            UserIssued = User.users.FirstOrDefault();
        }

    }
}
