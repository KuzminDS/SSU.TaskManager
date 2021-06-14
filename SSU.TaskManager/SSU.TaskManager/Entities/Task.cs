using SQLite;
using System;
using System.ComponentModel;

namespace SSU.TaskManager.Entities
{
    [Table("Tasks")]
    public class Task : INotifyPropertyChanged
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

        private string _title;

       
        public string Title
        {
            get
            {
                return _title;
            }

            set
            {
                this._title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
        private string _description;

        
        public string Description
        {
            get
            {
                return _description;
            }

            set
            {
                this._description = value;
                OnPropertyChanged(nameof(Description));
            }
        }
        private string _deadLine;

        
        public string DeadLine
        {
            get
            {
                return _deadLine;
            }

            set
            {
                this._deadLine = value;
                OnPropertyChanged(nameof(DeadLine));
            }
        }
        private int _boardId;

        
        public int BoardId
        {
            get
            {
                return _boardId;
            }

            set
            {
                this._boardId = value;
                OnPropertyChanged(nameof(BoardId));
            }
        }


        private int _userid;


        
        public int UserId
        {
            get
            {
                return _userid;
            }

            set
            {
                this._userid = value;
                OnPropertyChanged(nameof(UserId));
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
