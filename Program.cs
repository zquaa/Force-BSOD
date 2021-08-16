using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace BSOD
{
    class Program
    {
        [DllImport("ntdll.dll", SetLastError = true)]
        private static extern int NtSetInformationProcess(IntPtr hProcess, int processInformationClass, ref int processInformation, int processInformationLength);

        static void Main(string[] args) 
        {
            Console.WriteLine("it forces BSOD on close.");
            try
            {
                int isCritical = 1;
                int BreakOnTermination = 0x1D;
                Process.EnterDebugMode();
                NtSetInformationProcess(Process.GetCurrentProcess().Handle, BreakOnTermination, ref isCritical, sizeof(int));
            }
            catch { }
            Console.ReadLine();
        }
    }
}
