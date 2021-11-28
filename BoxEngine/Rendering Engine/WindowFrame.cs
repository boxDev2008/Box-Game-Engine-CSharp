using OpenTK.Windowing.Desktop;

namespace BoxEngine.Graphics.Windowing
{
    public class WindowFrame : GameWindow
    {
        public WindowFrame():base(GameWindowSettings.Default, NativeWindowSettings.Default) { }
        public WindowFrame(NativeWindowSettings nativeWindowSettings) : base(GameWindowSettings.Default, nativeWindowSettings) { }
    }   
}