using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using SQLite;

namespace SSU.TaskManager.Entities
{

    [Table("Users")]
    public class User : INotifyPropertyChanged
    {
        private int _id;

        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                this._id = value;
                OnPropertyChanged(nameof(Id));
            }
        }
        private string _firstName;

        [NotNull]
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                this._firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }
        private string _lastName;

        [NotNull]
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                this._lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }


        private string _login;

        [NotNull]
        public string Login
        {
            get
            {
                return _login;
            }
            set
            {
                this._login = value;
                OnPropertyChanged(nameof(Login));
            }
        }
        private string _password;

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                this._password = value;
                OnPropertyChanged(nameof(Password));
            }
        }





        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this,
              new PropertyChangedEventArgs(propertyName));
        }
    }

}

