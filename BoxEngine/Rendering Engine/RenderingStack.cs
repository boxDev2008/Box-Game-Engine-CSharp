using OpenTK.Graphics.OpenGL;

namespace BoxEngine.Graphics
{
    public abstract class RenderingStack
    {
        public int VBO, VAO, EBO;
        private float[]? vertices;
        private uint[]? indices;

        public void GenerateBuffers(float[] vertices, uint[] indices)
        {
            this.vertices = vertices;
            this.indices = indices;

            VAO = GL.GenVertexArray();
            GL.BindVertexArray(VAO);

            VBO = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, VBO);
            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), this.vertices, BufferUsageHint.DynamicDraw);

            AddBufferData();

            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

            EBO = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, EBO);
            GL.BufferData(BufferTarget.ElementArrayBuffer, indices.Length * sizeof(uint), this.indices, BufferUsageHint.DynamicDraw);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);

            GL.BindVertexArray(0);
        }

        public virtual void AddBufferData()
        {
            
        }

        public void DrawBuffers()
        {
            GL.BindVertexArray(VAO);
            GL.DrawArrays(PrimitiveType.Triangles, 0, vertices.Length);
        }
    }
}
