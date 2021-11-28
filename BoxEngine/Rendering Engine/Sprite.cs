namespace BoxEngine.Graphics
{
    public struct Sprite
    {
        public float X, Y, Width, Height;
        public Texture Texture { get; private set; }

        public Sprite(ref Texture texture, float x, float y, float width, float height)
        {
            Texture = texture;
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }
    }
}