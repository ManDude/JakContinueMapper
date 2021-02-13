namespace JakContinueMapper.Games
{
    public class Jak1US : GameMemory
    {
        public override int TargetPos() => 0x0017A9F0;
        public override int SafeLevel() => 0;
    }

    public class Jak1PAL : GameMemory
    {
        public override int TargetPos() => 0x0017AAF0;
        public override int SafeLevel() => 0;
    }
}
