using System;
using System.Diagnostics;
using System.Threading;

namespace Watcher
{
    public class ProcessWatcher
    {
        public Process Process = new Process();

        public delegate void Delegate(Process process);
        public event Delegate Created;

        public bool GetProcess(string processName)
        {
            Process[] processes = Process.GetProcessesByName(processName);
            if (processes.Length < 1)
                return false;

            foreach (var process in processes)
            {
                if (String.IsNullOrWhiteSpace(process.MainWindowTitle))
                    continue;

                Process = process;
                return true;
            }

            return false;
        }

        public void Auto()
        {
            do
                Thread.Sleep(2000);
            while (!GetProcess());

            Created?.Invoke(Process);

            Process.EnableRaisingEvents = true;
            Process.Exited += (ignore, ignore2) =>
                Auto();
        }
    }
}