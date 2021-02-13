using System;

namespace JakContinueMapper
{
    public static class MathExt
    {
        public static float Dist3D(float x1, float y1, float z1, float x2, float y2, float z2)
        {
            var dx = x1 - x2;
            var dy = y1 - y2;
            var dz = z1 - z2;
            return (float)Math.Sqrt(dx * dx + dy * dy + dz * dz);
        }
    }
}
