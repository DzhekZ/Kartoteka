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
        public static IReadOnlyCollection<Book> books = new List<Book>()
        {
            new Book("book1", 1, "author1", 1950),
            new Book("book2", 2, "author2", 1970),
            new Book("book3", 3, "author3", 1985),
            new Book("book4", 4, "author4", 1930),
            new Book("book5", 5, "author5", 1917)
        };
        private string _name;
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
        private int _invNumber;
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
        private string _author;
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
        private int _yearPrint;
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
    }
}
