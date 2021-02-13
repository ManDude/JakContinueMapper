using System;

namespace JakContinueMapper
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public class GameMemoryAttribute : Attribute
    {
        public string Name { get; private set; }
        public GameRegion Region { get; private set; }
        public int TargetPos { get; private set; }
        public int SafeLevel { get; private set; }

        public GameMemoryAttribute(string name, GameRegion region, int targetpos = 0, int safelevel = 0)
        {
            Name = name;
            Region = region;
            TargetPos = targetpos;
            SafeLevel = safelevel;
        }
    }
}
