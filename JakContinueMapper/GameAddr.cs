namespace JakContinueMapper
{
    public struct GameAddr
    {
        public GameAddr(int addr, params int[] ptroff)
        {
            Addr = addr;
            PtrOff = ptroff;
        }

        public int Addr { get; set; }
        public int[] PtrOff { get; }

        public int IteratePointer(EmuMemory emu)
        {
            int finaladdr = Addr;
            for (int i = 0; i < PtrOff.Length; ++i)
            {
                if (!emu.ReadInt32(finaladdr, out finaladdr) || finaladdr == 0) throw new System.Exception();
                finaladdr += PtrOff[i];
            }
            return finaladdr;
        }

        public static GameAddr operator +(GameAddr addr, int value) => new GameAddr(addr.Addr + value);
    }
}
