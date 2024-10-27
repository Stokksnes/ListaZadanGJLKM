using ListaZadanGJLKM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ListaZadanGJLKM.Json
{
    public static class DeSSerializacja
    {
        //Zapis do lokalnego katalogu
        private static readonly string filePath = Path.Combine(FileSystem.Current.AppDataDirectory, "tasks.json");

        public static async Task SaveTasksAsync(ObservableCollection<TaskItem> tasks)
        {
            var json = JsonSerializer.Serialize(tasks);
            await File.WriteAllTextAsync(filePath, json);
        }

        //Odczyt jsona z lokalnego katalogu
        public static async Task<ObservableCollection<TaskItem>> LoadTasksAsync()
        {
            if (!File.Exists(filePath))
            {
                return new ObservableCollection<TaskItem>();
            }
            var json = await File.ReadAllTextAsync(filePath);
            return JsonSerializer.Deserialize<ObservableCollection<TaskItem>>(json) ?? new ObservableCollection<TaskItem>();
        }
    }
}
