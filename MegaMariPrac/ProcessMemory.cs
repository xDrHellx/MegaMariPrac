using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace MegaMariPrac
{
    class ProcessMemory
    {
        #region process & address
        // Function imports
        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);
        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(int hProcess, int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteProcessMemory(int hProcess, int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesWritten);

        // Access values
        const int PROCESS_ALL_ACCESS = 0x1F0FFF;

        // Process handle
        static Process p = Process.GetProcessesByName("megamari")[0];
        IntPtr _processHandle = OpenProcess(PROCESS_ALL_ACCESS, false, p.Id);
        public static int FirstProcessModuleMemorySize;

        // Amount of bytes written/read
        private int _bytesWritten = 0,
            _bytesRead = 0;
        #endregion

        public ProcessMemory()
        {
            // Start thread with method ProcessRun
            new Thread(ProcessRun) { IsBackground = true }.Start();

            ProcessModule pm = p.Modules[0];
            FirstProcessModuleMemorySize = pm.ModuleMemorySize;
            Console.WriteLine("ModuleMemorySize: " + pm.ModuleMemorySize);
        }

        void ProcessRun()
        {
            // Check if the program is running
            while (true)
            {
                if (p.HasExited)
                    Environment.Exit(1);
                Thread.Sleep(50);
            }
        }

        public void WriteStatic(int address, byte[] buffer)
        {
            WriteProcessMemory((int)_processHandle, (int)p.Modules[0].BaseAddress + address, buffer, buffer.Length, ref _bytesWritten);
        }

        public byte[] ReadStatic(int address, byte[] buffer)
        {
            ReadProcessMemory((int)_processHandle, (int)p.Modules[0].BaseAddress + address, buffer, buffer.Length, ref _bytesRead);
            return buffer;
        }

        public void Write(int first_off, int last_off, byte[] value)
        {
            byte[] buffer = new byte[4];

            /**
             * Read address pointed by the game + first initial offset -> equivalent to 'Game.exe+first offset' in cheat engine
             * Then offset new pointer
             * And write value from the new pointer address
             */
            ReadProcessMemory((int)_processHandle, (int)p.Modules[0].BaseAddress + first_off, buffer, buffer.Length, ref _bytesRead);
            IntPtr curAdd = (IntPtr)BitConverter.ToInt32(buffer, 0);
            curAdd += last_off;
            WriteProcessMemory((int)_processHandle, (int)curAdd, value, value.Length, ref _bytesWritten);
        }

        public byte[] Read(int first_off, int last_off)
        {
            byte[] buffer = new byte[4];

            /**
             * Read address pointed by the game + first initial offset -> equivalent to 'Game.exe+first offset' in cheat engine
             * Then offset new pointer
             * And read & return value from the new pointer address
             */
            ReadProcessMemory((int)_processHandle, (int)p.Modules[0].BaseAddress + first_off, buffer, buffer.Length, ref _bytesRead);
            IntPtr curAdd = (IntPtr)BitConverter.ToInt32(buffer, 0);
            curAdd += last_off;
            ReadProcessMemory((int)_processHandle, (int)curAdd, buffer, buffer.Length, ref _bytesRead);
            return buffer;
        }
    }
}
