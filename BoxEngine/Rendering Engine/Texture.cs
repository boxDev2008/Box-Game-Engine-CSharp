using System.Drawing;
using System.Drawing.Imaging;

using OpenTK.Graphics.OpenGL;

namespace  BoxEngine.Graphics
{
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    public struct Texture
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
        public int ID { get; private set; }

        public Texture(int id, int width, int height)
        {
            ID = id;
            Width = width;
            Height = height;
        }

        public Texture(Image image, TextureWrapMode textureWrapMode = TextureWrapMode.ClampToBorder, TextureMinFilter textureMinFilter = TextureMinFilter.Nearest, TextureMagFilter textureMagFilter = TextureMagFilter.Nearest)
        {
            Bitmap bmp = new Bitmap(image);
            ID = GL.GenTexture();

            Width = bmp.Width;
            Height = bmp.Height;

            GL.BindTexture(TextureTarget.Texture2D, ID);
            BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)textureWrapMode);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)textureWrapMode);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)textureMinFilter);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)textureMagFilter);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bmp.Width, bmp.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);
            GL.BindTexture(TextureTarget.Texture2D, 0);
        }

        public Texture(string filePath, TextureWrapMode textureWrapMode = TextureWrapMode.ClampToBorder, TextureMinFilter textureMinFilter = TextureMinFilter.Nearest, TextureMagFilter textureMagFilter = TextureMagFilter.Nearest)
        {
            Bitmap bmp = new Bitmap(filePath);

            Width = bmp.Width;
            Height = bmp.Height;

            ID = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, ID);
            BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)textureWrapMode);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)textureWrapMode);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)textureMinFilter);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)textureMagFilter);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bmp.Width, bmp.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);
            GL.BindTexture(TextureTarget.Texture2D, 0);
        }
    }    
}
