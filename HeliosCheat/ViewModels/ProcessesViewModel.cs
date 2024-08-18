using Helios.Memory;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeliosCheat.ViewModels
{
    public class ProcessesViewModel: INotifyPropertyChanged
    {
        public ObservableCollection<ProcessViewModel> ProcessList { get; }
        public ProcessesViewModel()
        {
            ProcessList = new ObservableCollection<ProcessViewModel>(MemoryManager.GetProcessList().Select(p => new ProcessViewModel(p)));
        }

        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
