using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxEngine.Graphics.Shaders
{
    public class SpriteShader : GameShader
    {
        public SpriteShader() => CompileGLSLShader(VertexShaderSource, FragmentShaderSource);

        private string VertexShaderSource = @"
        #version 330 core
        layout (location = 0) in vec3 aPosition;
        layout (location = 1) in vec4 aTexCoord;

        out vec4 TexCoord;

        uniform mat4 modelMatrix;
        uniform mat4 orthographicMatrix;

        uniform mat4 textureMatrix;

        void main()
        {
            TexCoord = textureMatrix * aTexCoord;
            gl_Position = orthographicMatrix * modelMatrix * vec4(aPosition, 1.0);
        }";

        private string FragmentShaderSource = @"
        #version 330 core
        out vec4 FragColor;

        in vec4 TexCoord;
        uniform sampler2D textureID;

        uniform vec4 spriteColor;

        uniform float br;

        void main()
        {
            vec2 t = vec2(TexCoord);
            FragColor = texture(textureID, t) * spriteColor + vec4(br, br, br, 0);
        }";
    }
}
