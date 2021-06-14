using SSU.TaskManager.BusinessLogic.ServiceInterface;
using SSU.TaskManager.Common.Ioc;
using SSU.TaskManager.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SSU.TaskManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DoneListPage : ContentPage
    {
        private readonly ITaskService _taskService;
        private readonly IBoardService _boardService;
        private readonly IUserService _userService;

        private string _taskName;

        private int _idUser = LoginPage.IdUser;
        public static ObservableCollection<Task> Tasks { get; set; } = new ObservableCollection<Task>();
        public DoneListPage()
        {
            InitializeComponent();
            _taskService = DependenciesResolver.Kernel.GetService<ITaskService>();
            _boardService = DependenciesResolver.Kernel.GetService<IBoardService>();
            Tasks.CollectionChanged += Tasks_CollectionChanged;

            Tasks = new ObservableCollection<Task>(_taskService.GetAll().Where(t => t.UserId == _idUser && t.BoardId == 3).ToList());

            TaskListView.ItemsSource = null;
            TaskListView.ItemsSource = Tasks;
        }

        private void Tasks_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                TaskListView.ItemsSource = null;
                TaskListView.ItemsSource = Tasks;
            }
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                TaskListView.ItemsSource = null;
                TaskListView.ItemsSource = Tasks;
            }
        }
    }
}