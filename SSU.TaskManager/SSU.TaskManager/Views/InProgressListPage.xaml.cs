using SSU.TaskManager.BusinessLogic.ServiceInterface;
using SSU.TaskManager.Common.Ioc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SSU.TaskManager.Entities;
using System.Collections.Specialized;

namespace SSU.TaskManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InProgressListPage : ContentPage
    {
        private readonly ITaskService _taskService;
        private readonly IBoardService _boardService;
        private readonly IUserService _userService;

        private string _taskName;

        private int _idUser = LoginPage.IdUser;
        public static ObservableCollection<Task> Tasks { get; set; } = new ObservableCollection<Task>();
        public InProgressListPage()
        {

            InitializeComponent();
            _taskService = DependenciesResolver.Kernel.GetService<ITaskService>();
            _boardService = DependenciesResolver.Kernel.GetService<IBoardService>();
            Tasks.CollectionChanged += Tasks_CollectionChanged;

            Tasks = new ObservableCollection<Task>(_taskService.GetAll().Where(t => t.UserId == _idUser && t.BoardId == 2).ToList());

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

        public async void OnDescription_Clicked(object sender, EventArgs e)
        {
            var btn = sender as Button;
            var stackLayout = btn.Parent as StackLayout;
            var label = stackLayout.FindByName<Label>("LabelTask");
            Task task = _taskService.GetByCondition(t => t.Title == label.Text && t.UserId == _idUser).FirstOrDefault();
            //var task = new Task
            //{
            //    Title = btn.Text,
            //    Description = "Типа описание",
            //    DeadLine = DateTime.Now.ToString(),
            //};

            var taskDescriptionView = new TaskDescriptionView(task, "INPR");

            await Navigation.PushAsync(taskDescriptionView);
        }
    }
}