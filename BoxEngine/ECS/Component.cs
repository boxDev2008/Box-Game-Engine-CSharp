namespace BoxEngine.Game
{
    public abstract class Component
    {
        public Entity entity = null!;

        public virtual void OnStart() { }
        public virtual void OnUpdate() { }
        public virtual void OnDraw() { }
        public virtual void OnDrawGUI() { }
    }
}