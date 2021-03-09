using System;

namespace JakContinueMapper
{
    public static class GameMemory
    {
        public const int GOAL_MAX_SYMBOLS = 0x2000;
        public const int BASIC_OFFSET = 4;
        public const int SymbolTableOffset = (GOAL_MAX_SYMBOLS / 2) * 8 + 0;
        public const int UsableSymbolCount = 8161;
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public class GameMemoryAttribute : Attribute
    {
        public string Name { get; private set; }
        public GameRegion Region { get; private set; }
        public int TargetPos { get; private set; }
        public int SymbolTable { get; private set; }

        public GameMemoryAttribute(string name, GameRegion region, int targetpos = 0, int s7 = 0)
        {
            Name = name;
            Region = region;
            TargetPos = targetpos;
            SymbolTable = s7 - GameMemory.SymbolTableOffset;
        }
    }
}
