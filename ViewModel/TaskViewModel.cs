using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListaZadanGJLKM.Model;
using CommunityToolkit.Mvvm.Input;
using ListaZadanGJLKM.Json;

namespace ListaZadanGJLKM.ViewModel
{
    public partial class TaskViewModel : ObservableObject
    {
        [ObservableProperty]
        // Lista
        public ObservableCollection<TaskItem> tasks = new ObservableCollection<TaskItem>();

        [ObservableProperty]
        private string newTaskName, newTaskDescription;

        // Załadowanie listy
        public TaskViewModel()
        {
            DeSSerializacja.LoadTasksAsync();   
        }

        // Dodawanie do listy
        [RelayCommand]
        private async void AddTask()
        {
            Tasks.Add(new TaskItem { Name = NewTaskName, Desctription = NewTaskDescription, IsCompleted = false });
            NewTaskName = string.Empty;
            NewTaskDescription = string.Empty;
            await DeSSerializacja.SaveTasksAsync(Tasks);
        }

        // Usuwanie z listy
        [RelayCommand]
        private async void RemoveTask(TaskItem task)
        {
            if (Tasks.Contains(task))
            {
                Tasks.Remove(task);
                await SaveTasksAsync();
            }
        }

        private async Task LoadTasksAsync()
        {
            Tasks = await DeSSerializacja.LoadTasksAsync();
        }

        private async Task SaveTasksAsync()
        {
            await DeSSerializacja.SaveTasksAsync(Tasks);
        }
    }
}
