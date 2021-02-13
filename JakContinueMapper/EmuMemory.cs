using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;

namespace JakContinueMapper
{
    public abstract class EmuMemory
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [Out] byte[] lpBuffer, int dwSize, out IntPtr lpNumberOfBytesRead);
        [DllImport("kernel32.dll")]
        internal static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int dwSize, out IntPtr lpNumberOfBytesWritten);

        public enum EmuAddressType { Static, Dynamic }

        public abstract int EmuAddress { get; }
        protected abstract EmuAddressType AddressType { get; }
        public Process Process { get; protected set; } = null;
        public bool ProcessIsValid => !(Process == null || Process.HasExited);

        protected virtual void OnProcessHook() { /* do nothing! */ }

        public IntPtr GetAddress(int addr)
        {
            return AddressType switch
            {
                EmuAddressType.Dynamic => Process.MainModule.BaseAddress + EmuAddress + (addr & 0x7FFFFFFF),
                EmuAddressType.Static => (IntPtr)EmuAddress + (addr & 0x7FFFFFFF),
                _ => IntPtr.Zero,
            };
        }

        public void SetProcess(string name)
        {
            var processes = Process.GetProcessesByName(name);
            if (processes.FirstOrDefault() != default(Process))
            {
                Process = processes.First();
                OnProcessHook();
            }
        }

        public void UpdateProcess(string name)
        {
            if (!ProcessIsValid) SetProcess(name);
        }

        internal byte[] ReadMemBuf(int addr, int memsize)
        {
            if (!ProcessIsValid) return null;
            byte[] membuf = new byte[memsize];
            bool error = ReadProcessMemory(Process.Handle, GetAddress(addr), membuf, memsize, out IntPtr memcount);
            if (!error) throw new Win32Exception(Marshal.GetLastWin32Error());
            return membuf;
        }

        internal bool WriteMemBuf(int addr, byte[] membuf)
        {
            if (!ProcessIsValid) return false;
            bool error = WriteProcessMemory(Process.Handle, GetAddress(addr), membuf, membuf.Length, out IntPtr memcount);
            if (!error || memcount == IntPtr.Zero) throw new Win32Exception(Marshal.GetLastWin32Error());
            return error;
        }

        public bool ReadMem(int addr, int size, out byte[] result)
        {
            result = ReadMemBuf(addr, size);
            if (result == null) return false;
            return true;
        }

        public bool ReadInt32(int addr, out int result)
        {
            result = 0;
            byte[] membuf = ReadMemBuf(addr, 4);
            if (membuf == null) return false;
            result = BitConverter.ToInt32(membuf, 0);
            return true;
        }

        public bool ReadFloat(int addr, out float result)
        {
            result = 0;
            byte[] membuf = ReadMemBuf(addr, 4);
            if (membuf == null) return false;
            result = BitConverter.ToSingle(membuf, 0);
            return true;
        }

        public bool ReadFloat3(int addr, out float x, out float y, out float z)
        {
            x = y = z = 0;
            byte[] membuf = ReadMemBuf(addr, 12);
            if (membuf == null) return false;
            x = BitConverter.ToSingle(membuf, 0);
            y = BitConverter.ToSingle(membuf, 4);
            z = BitConverter.ToSingle(membuf, 8);
            return true;
        }

        public bool ReadMem(GameAddr addr, int size, out byte[] result) => ReadMem(addr.IteratePointer(this), size, out result);
        public bool ReadInt32(GameAddr addr, out int result) => ReadInt32(addr.IteratePointer(this), out result);
        public bool ReadFloat(GameAddr addr, out float result) => ReadFloat(addr.IteratePointer(this), out result);
        public bool ReadFloat3(GameAddr addr, out float x, out float y, out float z) => ReadFloat3(addr.IteratePointer(this), out x, out y, out z);

        public bool WriteInt32(GameAddr addr, uint val) => WriteMemBuf(addr.IteratePointer(this), BitConverter.GetBytes(val));
        public bool WriteFloat(GameAddr addr, float val) => WriteMemBuf(addr.IteratePointer(this), BitConverter.GetBytes(val));
    }
}
