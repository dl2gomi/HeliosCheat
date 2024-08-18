using System;
using System.Collections.Generic;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using HeliosCheat.Helpers;
using System.ComponentModel;

namespace HeliosCheat.ViewModels
{
    public class ProcessViewModel: INotifyPropertyChanged
    {
        public Process Process { get; set; }
        public string DisplayName => $"{Process.ProcessName} ({Process.Id} - {Process.MainWindowTitle})";
        public BitmapImage? IconImage => MediaHelper.ConvertIconToBitmapImage(Icon.ExtractAssociatedIcon(Process.MainModule?.FileName));

        public ProcessViewModel(Process proc)
        {
            this.Process = proc;
        }

        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
