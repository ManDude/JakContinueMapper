using System.ComponentModel;

namespace JakContinueMapper.Emulators
{
    public sealed class PCSX2 : EmuMemory
    {
        public override int EmuAddress => 0x10000000 * BaseAddressMult;
        protected override EmuAddressType AddressType => EmuAddressType.Static;

        public int BaseAddressMult { get; private set; } = 3;

        internal static readonly byte?[] BIOSMem = new byte?[] { 0x01, 0x80, 0x1A, 0x3C, null, null, 0x59, 0xFF, 0x00, 0x68, 0x19, 0x40, 0x01, 0x80, 0x1A, 0x3C, 0x7C, 0x00, 0x39, 0x33, 0x21, 0xD0, 0x59, 0x03, null, null, null, 0x8F, 0x01, 0x80, 0x19, 0x3C, 0x08, 0x00, 0x40, 0x03, null, null, 0x39, 0xDF };

        protected override void OnProcessHook()
        {
            GameAddr biosAddr = new GameAddr(0);
            for (int i = 1; i < 8; ++i)
            {
                BaseAddressMult = i;
                byte[] mem;
                try
                {
                    ReadMem(biosAddr, BIOSMem.Length, out mem);
                }
                catch (Win32Exception ex)
                {
                    mem = null;
                }
                if (mem == null) continue; // invalid address
                for (int b = 0; b < BIOSMem.Length; ++b)
                {
                    if (BIOSMem[b] == null) continue; // skip byte
                    if (BIOSMem[b] != mem[b]) goto no_success; // break out of loop, not bios memory
                }
                return; // bios memory found!
            no_success:;
            }
            Process = null; // invalid process or invalid state, try again later (TODO optimize this)
        }
    }
}
