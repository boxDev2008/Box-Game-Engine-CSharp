using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxEngine.Graphics.Shaders
{
    public class TriangleShader : GameShader
    {
        public TriangleShader() => CompileGLSLShader(VertexShaderSource, FragmentShaderSource);

        private string VertexShaderSource = @"
        #version 330 core
        layout (location = 0) in vec3 aPosition;
        layout (location = 1) in vec3 aColor;

        out vec3 Color;

        void main()
        {
            Color = aColor;
            gl_Position = vec4(aPosition, 1.0);
        }";

        private string FragmentShaderSource = @"
        #version 330 core
        out vec4 FragColor;

        in vec3 Color;

        void main()
        {
            FragColor = vec4(Color, 1.0f);
        }";
    }
}
