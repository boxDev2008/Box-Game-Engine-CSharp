namespace BoxEngine.Game
{
    public class GameScene
    {
        public GameSandbox GameSandbox;
        public GameScene()
        {
            GameSandbox = GameSceneManager.GameSandbox;
        }

        public virtual void OnStart() { }
        public virtual void OnUpdate() { }
        public virtual void OnDraw() { }
        public virtual void OnResize() { }
        public virtual void OnClosing() { }
        public virtual void OnClosed() { }
    }
}