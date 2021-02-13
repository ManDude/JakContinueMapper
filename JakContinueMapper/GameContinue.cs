namespace JakContinueMapper
{
    public sealed class GameContinue
    {
        public string Name { get; }
        public float X { get; }
        public float Y { get; }
        public float Z { get; }

        public GameContinue(string name, float x, float y, float z)
        {
            Name = name;
            X = x;
            Y = y;
            Z = z;
        }
    }
}
