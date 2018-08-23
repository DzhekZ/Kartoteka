using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;

namespace Kartoteka.Model
{
    public class Book : ReactiveObject
    {
        #region Members
        public static IReadOnlyCollection<Book> books = new List<Book>()
        {
            new Book("book1", 1, "author1", 1950),
            new Book("book2", 2, "author2", 1970),
            new Book("book3", 3, "author3", 1985),
            new Book("book4", 4, "author4", 1930),
            new Book("book5", 5, "author5", 1917)
        };
        private string _name;
        private int _invNumber;
        private string _author;
        private int _yearPrint;
        #endregion

        #region Properties
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _name, value);
            }
        }
        public int InvNumber
        {
            get
            {
                return _invNumber;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _invNumber, value);
            }
        }
        public string Author
        {
            get
            {
                return _author;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _author, value);
            }
        }
        public int YearPrint
        {
            get
            {
                return _yearPrint;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _yearPrint, value);
            }
        }
        #endregion

        #region Construction
        public Book(string name)
        {
            Name = name;
            InvNumber = 0;
            Author = "";
            YearPrint = DateTime.Now.Year;
        }

        private Book(string name, int number, string author, int yearprint)
        {
            Name = name;
            InvNumber = number;
            Author = author;
            YearPrint = yearprint;
        }
        #endregion
  }
}
