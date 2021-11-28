using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxEngine.Graphics.Shaders
{
    public class ShapeShader : GameShader
    {
        public ShapeShader() => CompileGLSLShader(VertexShaderSource, FragmentShaderSource);

        private string VertexShaderSource = @"
        #version 330 core
        layout (location = 0) in vec3 aPosition;

        uniform mat4 modelMatrix;
        uniform mat4 orthographicMatrix;

        void main()
        {
            gl_Position = orthographicMatrix * modelMatrix * vec4(aPosition, 1.0);
        }";

        private string FragmentShaderSource = @"
        #version 330 core
        out vec4 FragColor;

        uniform vec4 shapeColor;

        uniform int shapeID;

        uniform float br;

        void main()
        {
            FragColor = shapeColor + vec4(br, br, br, 0);
        }";
    }
}
