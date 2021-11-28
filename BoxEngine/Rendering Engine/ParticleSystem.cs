using System.Numerics;

using BoxEngine.Graphics;
using BoxEngine.Mathematics;

namespace BoxEngine.Game
{
    public class ParticleSystem
    {
        private List<ParticleData> particleDatas;

        public ParticleSystem()
        {
            particleDatas = new List<ParticleData>();
        }

        public void OnUpdate()
        {
            for (int i = 0; i < particleDatas.Count; i++)
                particleDatas[i].OnUpdate();

            for (int i = 0; i < particleDatas.Count; i++)
                if (particleDatas[i].IsDead())
                    particleDatas.Remove(particleDatas[i]);
        }

        public void OnDraw()
        {
            for (int i = 0; i < particleDatas.Count; i++)
                particleDatas[i].OnDraw();
        }

        public void SpawnParticle(Vector2 startPosition, Vector2 velocity, Vector2 startScale, Vector2 endScale, float startAngle, float endAngle, Color startColor, Color endColor, float lifetime)
        {
            ParticleData data = new ParticleData();
            data.Position = startPosition;
            data.Velocity = velocity;
            data.Scale = startScale;
            data.EndScale = endScale;
            data.Angle = startAngle;
            data.EndAngle = endAngle;
            data.Color = startColor;
            data.EndColor = endColor;
            data.StartLifeTime = lifetime;
            data.LifeTime = lifetime;
            particleDatas.Add(data);
        }

        public void SpawnParticle(Vector2 startPosition, Vector2 velocity, Vector2 startScale, Vector2 endScale, float startAngle, float endAngle, Color startColor, Color endColor, Sprite sprite, float lifetime)
        {
            ParticleData data = new ParticleData();
            data.Position = startPosition;
            data.Velocity = velocity;
            data.Scale = startScale;
            data.EndScale = endScale;
            data.Angle = startAngle;
            data.EndAngle = endAngle;
            data.Color = startColor;
            data.EndColor = endColor;
            data.StartLifeTime = lifetime;
            data.LifeTime = lifetime;
            data.Sprite = sprite;
            particleDatas.Add(data);
        }
    }

    class ParticleData
    {
        public Vector2 Position;
        public Vector2 Velocity;
        public Vector2 Scale;
        public Vector2 EndScale;
        public float Angle;
        public float EndAngle;
        public Color Color;
        public Color EndColor;
        public float StartLifeTime;
        public float LifeTime;
        public Sprite Sprite;

        public ParticleData()
        {
            
        }

        public void OnUpdate()
        {
            UpdateState();
            UpdateVelocity();
        }

        public void OnDraw()
        {
            if (Sprite.Texture.ID != 0)
                GameRenderer.DrawSpriteRectangle2D(Position.X, Position.Y, Scale.X, Scale.Y, 0.5f, 0.5f, Angle, Color, Sprite);
            else
                GameRenderer.DrawRectangle2D(Position.X, Position.Y, Scale.X, Scale.Y, 0.5f, 0.5f, Angle, Color);
        }

        private void UpdateState()
        {
            float speed = (1f / StartLifeTime) * GameTime.UpdateDeltaTime;

            LifeTime = Lerp(LifeTime, 0f, speed);

            Scale = Lerp(Scale, EndScale, speed);
            Angle = Lerp(Angle, EndAngle, speed);
            Color = Lerp(Color, EndColor, speed);
        }

        private float Lerp(float firstFloat, float secondFloat, float by)
        {
            return firstFloat * (1 - by) + secondFloat * by;
        }

        private Vector2 Lerp(Vector2 firstVector, Vector2 secondVector, float by)
        {
            float retX = Lerp(firstVector.X, secondVector.X, by);
            float retY = Lerp(firstVector.Y, secondVector.Y, by);
            return new Vector2(retX, retY);
        }

        private Color Lerp(Color firstColor, Color secondColor, float by)
        {
            float R = Lerp(firstColor.R, secondColor.R, by);
            float G = Lerp(firstColor.G, secondColor.G, by);
            float B = Lerp(firstColor.B, secondColor.B, by);
            float A = Lerp(firstColor.A, secondColor.A, by);
            float BR = Lerp(firstColor.BR, secondColor.BR, by);

            return new Color((byte)R, (byte)G, (byte)B, (byte)A, (byte)BR);
        }

        private void UpdateVelocity() => Position += Velocity * GameTime.UpdateDeltaTime;

        public bool IsDead() => LifeTime <= 0.1f;
    }
}
