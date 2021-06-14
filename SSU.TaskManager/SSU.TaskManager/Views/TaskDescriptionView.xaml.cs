using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SSU.TaskManager.Entities;
using SSU.TaskManager.Common.Ioc;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SSU.TaskManager.BusinessLogic.ServiceInterface;
using System.Collections.ObjectModel;

namespace SSU.TaskManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TaskDescriptionView : ContentPage
    {
        private readonly Task _task;

        private readonly IBoardService  _boardService = DependenciesResolver.Kernel.GetService<IBoardService>();
        private readonly ITaskService _taskService = DependenciesResolver.Kernel.GetService<ITaskService>();


        private string _boardName;
        private string _deadline;
        private string _description;

        public TaskDescriptionView()
        {
            InitializeComponent();
        }
        private void Description_Completed(object sender, EventArgs e)
        {
            _description = ((Entry)sender).Text;
        }

        private void Deadline_Completed(object sender, EventArgs e)
        {
            _deadline = ((DatePicker)sender).Date.ToString();
        }

        public TaskDescriptionView(Task task, string boardName)
            :this()
        {
            _task = task;
            _boardName = boardName;
            taskTitle.Text = task.Title;
            description.Text = task.Description;
            datePicker.Date = DateTime.Parse(task.DeadLine);
            
        }

        public async void OnSaveChanges_Clicked(object sender, EventArgs e)
        {
            _task.Description = _description;
            _task.DeadLine = _deadline;
            _taskService.Update(_task);
            await Navigation.PopAsync();
        }

        public async void MoveInToDo_Clicked(object sender, EventArgs e)
        {
            _task.BoardId = _boardService.GetByCondition(b => b.Title == "TODO").FirstOrDefault().Id;
            _taskService.Update(_task);
            if(_boardName == "TODO")
            {
                ToDoListPage.Tasks.Remove(ToDoListPage.Tasks.Where(i => i.Id == _task.Id).Single());
            }
            else if(_boardName == "INPR")
            {
                InProgressListPage.Tasks.Remove(InProgressListPage.Tasks.Where(i => i.Id == _task.Id).Single());
            }
            else if(_boardName == "DONE")
            {
                DoneListPage.Tasks.Remove(DoneListPage.Tasks.Where(i => i.Id == _task.Id).Single());
            }
            ToDoListPage.Tasks.Add(_task);
            await Navigation.PopAsync();
        }

        public async void MoveInInProgress_Clicked(object sender, EventArgs e)
        {
            _task.BoardId = _boardService.GetByCondition(b => b.Title == "INPR").FirstOrDefault().Id;
            _taskService.Update(_task);
            if (_boardName == "TODO")
            {
                ToDoListPage.Tasks.Remove(ToDoListPage.Tasks.Where(i => i.Id == _task.Id).Single());
            }
            else if (_boardName == "INPR")
            {
                InProgressListPage.Tasks.Remove(InProgressListPage.Tasks.Where(i => i.Id == _task.Id).Single());
            }
            else if (_boardName == "DONE")
            {
                DoneListPage.Tasks.Remove(DoneListPage.Tasks.Where(i => i.Id == _task.Id).Single());
            }
            InProgressListPage.Tasks.Add(_task);
            await Navigation.PopAsync();
        }

        public async void MoveInDone_Clicked(object sender, EventArgs e)
        {
            _task.BoardId = _boardService.GetByCondition(b => b.Title == "DONE").FirstOrDefault().Id;
            _taskService.Update(_task);
            if (_boardName == "TODO")
            {
                ToDoListPage.Tasks.Remove(ToDoListPage.Tasks.Where(i => i.Id == _task.Id).Single());
            }
            else if (_boardName == "INPR")
            {
                InProgressListPage.Tasks.Remove(InProgressListPage.Tasks.Where(i => i.Id == _task.Id).Single());
            }
            else if (_boardName == "DONE")
            {
                DoneListPage.Tasks.Remove(DoneListPage.Tasks.Where(i => i.Id == _task.Id).Single());
            }
            DoneListPage.Tasks.Add(_task);
            await Navigation.PopAsync();
        }
    }
}