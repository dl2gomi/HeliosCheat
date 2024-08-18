using System.Diagnostics;

namespace Helios.Memory
{
    public class MemoryManager
    {
        public static Process[] GetProcessList()
        {
            return Process.GetProcesses().Where(p => p.MainWindowHandle != IntPtr.Zero).ToArray();
        }

    }
}
