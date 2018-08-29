using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using ReactiveUI;

namespace Kartoteka.Model
{
  public class Chitateli
  {
    #region Members
    private DateTime _registerdate;
    private User _user;
    #endregion

    #region Properties
    public int ID { get; set; } = 0;
    public DateTime RegisterDate
    {
      get
      {
        return _registerdate;
      }
      set
      {
        //this.RaiseAndSetIfChanged(ref _registerdate, value);
        _registerdate = value;
      }
    }
    public User User
    {
      get
      {
        return _user;
      }
      set
      {
        //this.RaiseAndSetIfChanged(ref _user, value);
        _user = value;
      }
    }
        #endregion

    #region Construction
    public Chitateli(User user, DateTime regdate, int id)
        {
            _user = user;
            ID = id;
            _registerdate = regdate;
        }
    #endregion
  }
}
