using System.Numerics;
using Box2DX.Collision;
using Box2DX.Common;
using Box2DX.Dynamics;
using BoxEngine.Game;
using Math = System.Math;

namespace BoxEngine.Physics
{
    public class DynamicPhysicsBody : Component
    {
        private Transform _transform = null!;

        private Body _body = null!;
        private BodyDef _bodyDef;

        public bool EnableRotation = false;
        public float Gravity = 7f, Mass = 1f;

        public DynamicPhysicsBody(Transform transform, float sx, float sy, float friction = 0.3f, FilterData filterData = default)
        {
            _transform = transform;
            CreateBody(sx, sy, friction, filterData);
        }

        private void CreateBody(float sx, float sy, float friction, FilterData filterData)
        {
            _bodyDef = new BodyDef();
            _bodyDef.Position = new Vec2(0f, 0f);
            _body = PhysicsManager.World.CreateBody(_bodyDef);
            PolygonDef polygonDef = new PolygonDef();
            polygonDef.SetAsBox(sx, sy);
            polygonDef.Density = 10f;
            polygonDef.Friction = friction;
            polygonDef.Filter = filterData;
            _body.CreateFixture(polygonDef);
            _body.SetMassFromShapes();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            UpdateVelocity();
            UpdateTransform();
        }

        private void UpdateVelocity()
        {
            Vec2 velocity = GetVelocity();
            SetVelocity(velocity.X, ((velocity.Y + ((Mass * 20f / 10f) * (Gravity * 20f)) * GameTime.UpdateDeltaTime)));
        }

        private void UpdateTransform()
        {
            float a = _body.GetAngle() * (180 / MathF.PI);
            Vec2 p = _body.GetPosition();
            _transform.Position = new Vector2(p.X, p.Y);

            if (EnableRotation) _transform.Angle = a;
            _body.SetFixedRotation(!EnableRotation);
        }

        public void SetPosition(float x, float y) => _body.SetPosition(new Vec2(x, y));

        public Vec2 GetPosition() => _body.GetPosition();

        public Vec2 GetVelocity() => _body.GetLinearVelocity();
        public void SetVelocity(float x, float y) => _body.SetLinearVelocity(new Vec2(x, y));
    }
}