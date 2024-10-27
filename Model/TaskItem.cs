using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaZadanGJLKM.Model
{
    public partial class TaskItem : ObservableObject
    {
        [ObservableProperty]
        private string name, desctription;

        [ObservableProperty]
        private bool isCompleted;
    }
}
