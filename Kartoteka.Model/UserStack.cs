using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive;
using ReactiveUI;

namespace Kartoteka.Model
{
    public class UserStack : ReactiveObject
    {
        private DateTime _registerdate;
        public User User
        {
            get;
        }

        public UserStack (User user, DateTime regdate)
        {
            User = user;
            _registerdate = regdate;
        }

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
    }
}
