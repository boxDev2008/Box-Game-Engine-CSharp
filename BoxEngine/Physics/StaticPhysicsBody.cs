using System.Numerics;
using Box2DX.Collision;
using Box2DX.Common;
using Box2DX.Dynamics;
using BoxEngine.Game;

namespace BoxEngine.Physics
{
    public class StaticPhysicsBody : Component
    {
        private Transform _transform = null!;

        private Body _body = null!;
        private BodyDef _bodyDef;

        public StaticPhysicsBody(Transform transform, float sx, float sy, FilterData filterData = default)
        {
            _transform = transform;
            CreateBody(sx, sy, filterData);
        }

        private void CreateBody(float sx, float sy, FilterData filterData)
        {
            _bodyDef = new BodyDef();
            _bodyDef.Position = new Vec2(0f, 0f);
            _body = PhysicsManager.World.CreateBody(_bodyDef);
            PolygonDef polygonDef = new PolygonDef();
            polygonDef.Filter = filterData;
            polygonDef.SetAsBox(sx, sy);
            _body.CreateFixture(polygonDef);
            _body.SetMassFromShapes();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            UpdatePosition();
        }

        private void UpdatePosition()
        {
            Vec2 p = _body.GetPosition();
            _transform.Position = new Vector2(p.X, p.Y);
        }

        public void SetPosition(float x, float y) => _body.SetPosition(new Vec2(x, y));

        public Vec2 GetPosition() => _body.GetPosition();
    }
}