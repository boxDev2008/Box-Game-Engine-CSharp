using BoxEngine.Graphics.Windowing;

namespace BoxEngine.Game
{
    public abstract class GameSandbox
    {
        public GameViewport GameViewport = new GameViewport();
        public WindowFrame WindowFrame;
        
        public virtual void OnStart() { }
        public virtual void OnUpdate() { }
        public virtual void OnDraw() { }
        public virtual void OnResize() { }
        public virtual void OnClosing() { }
        public virtual void OnClosed() { }

    }
}