using System.Numerics;
using BoxEngine.Graphics;
using BoxEngine.Mathematics;

namespace BoxEngine.Game
{
    public class ShapeRenderer : Component
    {
        public Color Color { get; set; } = Color.White;
        public Vector2 Pivot = new Vector2(0.5f, 0.5f);

        public override void OnDraw()
        {
            base.OnDraw();
            Transform transform = entity.GetComponent<Transform>();
            GameRenderer.DrawRectangle2D(transform.Position.X, transform.Position.Y, transform.Scale.X, transform.Scale.Y, Pivot.X, Pivot.Y, transform.Angle, Color);
        }
    }
}