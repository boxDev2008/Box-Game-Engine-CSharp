using System;
using System.Numerics;
using BoxEngine.Graphics;
using BoxEngine.Mathematics;

namespace BoxEngine.Game
{
    public class SpriteRenderer : Component
    {
        public Color Color { get; set; } = Color.White;
        public Vector2 Pivot = new Vector2(0.5f, 0.5f);
        public Sprite CurrentSprite { get; set; }

        public override void OnDraw()
        {
            base.OnDraw();
            Transform transform = entity.GetComponent<Transform>();
            GameRenderer.DrawSpriteRectangle2D(transform.Position.X, transform.Position.Y, transform.Scale.X, transform.Scale.Y, Pivot.X, Pivot.Y, transform.Angle, Color, CurrentSprite);
        }
    }
}