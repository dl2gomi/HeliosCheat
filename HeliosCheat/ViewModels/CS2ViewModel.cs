using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Helios.GameInfo;
using HeliosCheat.Commands;

namespace HeliosCheat.ViewModels
{
    public class CS2ViewModel: INotifyPropertyChanged
    {
        public ProcessesViewModel? _processes;

        // properties
        public string SelectProcessTitle => $"Select a {CS2.Name} Process. ({CS2.ExeName} is selected by default.)";
        public ProcessesViewModel Processes => _processes;
        public ProcessViewModel? CS2Process {  get; private set; }
        public int CS2ProcessIndex
        {
            get
            {
                return CS2Process == null ? -1 : Processes.ProcessList.IndexOf(CS2Process);
            }
            set
            {
                CS2Process = Processes.ProcessList[value];
            }
        }

        // commands
        public ICommand ConnectCommand { get; private set; }

        // constructors
        public CS2ViewModel()
        {
            _processes = (ProcessesViewModel?)App.ServiceProvider.GetService(typeof(ProcessesViewModel));
            CS2Process = Processes.ProcessList.FirstOrDefault(p => p.Process.MainModule.FileName.ToLower().EndsWith(CS2.ExeName.ToLower()));

            // commmands
            ConnectCommand = new RelayCommand(
                (param) => {
                    try
                    {
                        foreach (ProcessModule module in CS2Process.Process.Modules)
                        {
                            if (string.Equals(module.ModuleName, CS2.ClientModuleName, StringComparison.OrdinalIgnoreCase))
                            {
                                // should implement logic to connect client dll
                                break;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Accessing modules of some processes may throw exceptions (e.g., due to access rights)
                    }
                },
                (param) =>
                {
                    return CS2Process != null;
                }
                );
        }

        public CS2ViewModel(ProcessesViewModel processesViewModel): this()
        {
            _processes = processesViewModel;
        }

        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Commands
    }
}
