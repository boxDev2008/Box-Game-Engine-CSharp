using OpenTK.Graphics.OpenGL;

namespace BoxEngine.Graphics
{
    public class ShapeBufferStack : BufferStack
    {
        private float[] _vertices =
        {
            0f, 0f, 0f,
            1f, 0f, 0f,
            1f, 1f, 0f,
            0f, 1f, 0f,
        };

        private uint[] _indices =
        {
            0, 1, 3,
            1, 2, 3
        };

        public ShapeBufferStack()
        {
            GenerateBuffers(_vertices, _indices);
        }
        public override void AddBufferData()
        {
            base.AddBufferData();
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);
        }
    }
}
