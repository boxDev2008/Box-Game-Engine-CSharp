using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL;

using BoxEngine.Mathematics;
using BoxEngine.Graphics.Shaders;

namespace BoxEngine.Graphics
{
    public class GameRenderer
    {
        private int _contextWidth, _contextHeight;

        #region Shaders

        private static GameShader _spriteShader = null!;
        private static GameShader _shapeShader = null!;

        #endregion

        #region Rendering Stacks

        private static SpriteBufferStack _spriteBufferStack = null!;
        private static ShapeBufferStack _shapeBufferStack = null!;

        #endregion

        private static TransformationStack _identityTransformationStack = null!;

        public GameRenderer()
        {
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc((BlendingFactor)BlendingFactorSrc.SrcAlpha, (BlendingFactor)BlendingFactorDest.OneMinusSrcAlpha);

            _spriteShader = new SpriteShader();
            _spriteBufferStack = new SpriteBufferStack();

            _shapeShader = new ShapeShader();
            _shapeBufferStack = new ShapeBufferStack();

            _identityTransformationStack = new TransformationStack();
        }
        
        public void OnRenderUpdate()
        {
            
        }

        public void OnResize(int width, int height)
        {
            _contextWidth = width;
            _contextHeight = height;
            GL.Viewport(0, 0, width, height);
        }

        public void CreateViewportTransform(float x, float y, float width, float height)
        {
            _spriteShader.UseShader();
            
            Matrix4 orthoMat4 = _identityTransformationStack.CreateOrthographicTransformation(_contextWidth, _contextHeight, x, y, width, height);
            int orthoMat4Location = GL.GetUniformLocation(_spriteShader.Handle, "orthographicMatrix");
            GL.UniformMatrix4(orthoMat4Location, false, ref orthoMat4);

            _shapeShader.UseShader();
            
            orthoMat4 = _identityTransformationStack.CreateOrthographicTransformation(_contextWidth, _contextHeight, x, y, width, height);
            orthoMat4Location = GL.GetUniformLocation(_shapeShader.Handle, "orthographicMatrix");
            GL.UniformMatrix4(orthoMat4Location, false, ref orthoMat4);
        }

        public static void SetBackgroundColor(Color color)
        {
            GL.ClearColor(color.R / 255f, color.G / 255f, color.B / 255f, color.A / 255f);
        }

        public static void DrawRectangle2D(float x, float y, float width, float height, float pivotX, float pivotY, float angle, Color color)
        {
            _shapeShader.UseShader();

            Matrix4 modelMat4 = _identityTransformationStack.CreateSpriteTransformation(x, y, width, height, pivotX, pivotY, angle);
            int modelMat4Location = GL.GetUniformLocation(_shapeShader.Handle, "modelMatrix");
            GL.UniformMatrix4(modelMat4Location, false, ref modelMat4);

            int shapeColorLocation = GL.GetUniformLocation(_shapeShader.Handle, "shapeColor");
            GL.Uniform4(shapeColorLocation, color.R / 255f, color.G / 255f, color.B / 255f, color.A / 255f);

            int brColorLocation = GL.GetUniformLocation(_shapeShader.Handle, "br");
            GL.Uniform1(brColorLocation, color.BR / 255f);

            GL.BindTexture(TextureTarget.Texture2D, 0);
            _shapeBufferStack.DrawElements();
        }

        public static void DrawTexturedRectangle2D(float x, float y, float width, float height, float pivotX, float pivotY, float angle, Color color, Texture texture)
        {
            _spriteShader.UseShader();

            Matrix4 modelMat4 = _identityTransformationStack.CreateSpriteTransformation(x, y, width, height, pivotX, pivotY, angle);
            int modelMat4Location = GL.GetUniformLocation(_spriteShader.Handle, "modelMatrix");
            GL.UniformMatrix4(modelMat4Location, false, ref modelMat4);

            Matrix4 textureMat4 = _identityTransformationStack.CreateTextureTransformation(0, 0, 1, 1, 1, 1);
            int textureMat4Location = GL.GetUniformLocation(_spriteShader.Handle, "textureMatrix");
            GL.UniformMatrix4(textureMat4Location, false, ref textureMat4);

            int spriteColorLocation = GL.GetUniformLocation(_spriteShader.Handle, "spriteColor");
            GL.Uniform4(spriteColorLocation, color.R / 255f, color.G / 255f, color.B / 255f, color.A / 255f);

            int brColorLocation = GL.GetUniformLocation(_spriteShader.Handle, "br");
            GL.Uniform1(brColorLocation, color.BR / 255f);

            GL.BindTexture(TextureTarget.Texture2D, texture.ID);
            _spriteBufferStack.DrawElements();
        }

        public static void DrawSpriteRectangle2D(float x, float y, float width, float height, float pivotX, float pivotY, float angle, Color color, Sprite sprite)
        {
            _spriteShader.UseShader();

            Matrix4 modelMat4 = _identityTransformationStack.CreateSpriteTransformation(x, y, width, height, pivotX, pivotY, angle);
            int modelMat4Location = GL.GetUniformLocation(_spriteShader.Handle, "modelMatrix");
            GL.UniformMatrix4(modelMat4Location, false, ref modelMat4);

            Matrix4 textureMat4 = _identityTransformationStack.CreateTextureTransformation(sprite.X, sprite.Y, sprite.Width, sprite.Height, sprite.Texture.Width, sprite.Texture.Height);
            int textureMat4Location = GL.GetUniformLocation(_spriteShader.Handle, "textureMatrix");
            GL.UniformMatrix4(textureMat4Location, false, ref textureMat4);

            int spriteColorLocation = GL.GetUniformLocation(_spriteShader.Handle, "spriteColor");
            GL.Uniform4(spriteColorLocation, color.R / 255f, color.G / 255f, color.B / 255f, color.A / 255f);

            int brColorLocation = GL.GetUniformLocation(_spriteShader.Handle, "br");
            GL.Uniform1(brColorLocation, color.BR / 255f);

            GL.BindTexture(TextureTarget.Texture2D, sprite.Texture.ID);
            _spriteBufferStack.DrawElements();
        }
    }
}