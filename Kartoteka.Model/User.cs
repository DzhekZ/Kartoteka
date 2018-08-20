using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;

namespace Kartoteka.Model
{
    public class User : ReactiveObject
    {
        public static IReadOnlyCollection<User> users = new List<User>()
        {
            new User("Библиотекарь", "в", "библиотеке", 0, Genders.other, 100),
            new User("Пользователь1", "", "", 0, Genders.man, 0),
            new User("Пользователь2", "", "", 0, Genders.man, 0),
            new User("Пользователь3", "", "", 0, Genders.women, 0),
            new User("Пользователь4", "", "", 0, Genders.women, 0),
            new User("Пользователь5", "", "", 0, Genders.other, 0)
        };
        public enum Genders
        {
            man,
            women,
            other
        };
        private string _firstName;
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _firstName, value);
            }
        }
        private string _secondName;
        public string SecondName
        {
            get
            {
                return _secondName;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _secondName, value);
            }
        }
        private string _thirdName;
        public string ThirdName
        {
            get
            {
                return _thirdName;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _thirdName, value);
            }
        }
        private int _number;
        public int Number
        {
            get
            {
                return _number;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _number, value);
            }
        }
        private Genders _gender;
        public Genders Gender
        {
            get
            {
                return _gender;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _gender, value);
            }
        }
        private int _age;
        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _age, value);
            }
        }
        public string FullName => (FirstName + " " + SecondName + " " + ThirdName).Trim();

        public User(string firsname, string secondname, string thirdname)
        {
            FirstName = firsname;
            SecondName = secondname;
            ThirdName = thirdname;
            Number = 0;
            Gender = Genders.other;
            Age = 0;
        }

        private User(string firsname, string secondname, string thirdname, int number, Genders gender, int age)
        {
            FirstName = firsname;
            SecondName = secondname;
            ThirdName = thirdname;
            Number = number;
            Gender = gender;
            Age = age;
        }
    }
}
