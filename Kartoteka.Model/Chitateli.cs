using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;

namespace Kartoteka.Model
{
    public class Chitateli : ReactiveObject
    {
        public User User { get; }
        private int _id = 0;
        public int ID
        {
            get => _id;
            set => _id = value;
        }
        private DateTime _registerdate;
        public DateTime RegisterDate
        {
            get
            {
                return _registerdate;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _registerdate, value);
            }
        }

        public Chitateli(User user, DateTime regdate, int id)
        {
            User = user;
            _id = id;
            _registerdate = regdate;
        }

    }
}
