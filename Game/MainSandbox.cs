using System.Numerics;
using BoxEngine.Mathematics;
using BoxEngine.Game;
using BoxEngine.Input;
using BoxEngine.Graphics;
using BoxEngine.Graphics.Windowing;
using OpenTK.Windowing.Common;

class MainSandbox : GameSandbox
{
    public override void OnStart()
    {
        base.OnStart();

        WindowFrame.Size = new OpenTK.Mathematics.Vector2i(1200, 720);
        WindowFrame.WindowBorder = WindowBorder.Fixed;
        
        GameViewport.Width = 4.5f;
        GameViewport.Height = 4.5f;
    }

    public override void OnDraw()
    {
	GameRenderer.DrawRectangle2D(0f, 0f, 20f, 20f, 0.5f, 0.5f, 45f, Color.White);
    }
}
