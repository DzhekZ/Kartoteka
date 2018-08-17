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

        public Chitateli(User user, DateTime regdate)
        {
            User = user;
            _registerdate = regdate;
        }

    }
}
