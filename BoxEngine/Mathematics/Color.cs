namespace BoxEngine.Mathematics
{
    public struct Color
    {
        public byte R, G, B, A, BR;

        public Color(byte r, byte g, byte b)
        {
            R = r; G = g; B = b; A = 255; BR = 0;
        }

        public Color(byte r, byte g, byte b, byte a)
        {
            R = r; G = g; B = b; A = a; BR = 0;
        }
        public Color(byte r, byte g, byte b, byte a, byte br)
        {
            R = r; G = g; B = b; A = a; BR = br;
        }

        public static Color White { get; } = new Color(255, 255, 255, 255, 0);
        public static Color Black { get; } = new Color(0, 0, 0, 255, 0);
        public static Color Transparent { get; } = new Color(0, 0, 0, 0, 0);
    }
}