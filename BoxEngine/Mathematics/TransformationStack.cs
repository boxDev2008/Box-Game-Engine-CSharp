using System;
using OpenTK.Mathematics;

namespace BoxEngine.Mathematics
{
    public class TransformationStack
    {
        public TransformationStack()
        {

        }

        public Matrix4 CreateSpriteTransformation(float x, float y, float width, float height, float pivotX, float pivotY, float angle)
        {
            var mat4 = Matrix4.Identity;
            mat4 = Matrix4.Mult(mat4, Matrix4.CreateScale(width, height, 1f));
            mat4 = Matrix4.Mult(mat4, Matrix4.CreateTranslation(-pivotX * width, -pivotY * height, 0f));
            mat4 = Matrix4.Mult(mat4, Matrix4.CreateRotationZ(angle / (180f / MathF.PI)));
            OpenTK.Graphics.OpenGL.GL.LoadIdentity();
            mat4 = Matrix4.Mult(mat4, Matrix4.CreateTranslation(x, y, 0f));
            return mat4;
        }

        public Matrix4 CreateTextureTransformation(float x, float y, float width, float height, float tw, float th)
        {
            var mat4 = Matrix4.Identity;
            mat4 = Matrix4.Mult(mat4, Matrix4.CreateScale(width / tw, height / th, 1f));
            mat4 = Matrix4.Mult(mat4, Matrix4.CreateTranslation(x / tw, y / th, 1f));
            return mat4;
        }

        public Matrix4 CreateOrthographicTransformation(int cotextWidth, int contextHeight, float x, float y, float width, float height)
        {
            var mat4 = Matrix4.CreateOrthographic(cotextWidth, -contextHeight, 1, -1);
            mat4 = Matrix4.Mult(mat4, Matrix4.CreateTranslation(-x / cotextWidth, -y / contextHeight , 0f));
            mat4 = Matrix4.Mult(mat4, Matrix4.CreateScale(width, height, 1f));
            return mat4;
        }
    }
}