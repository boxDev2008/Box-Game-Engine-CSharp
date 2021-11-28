using Box2DX.Collision;
using Box2DX.Dynamics;
using Box2DX.Common;
using BoxEngine.Game;

namespace BoxEngine.Physics
{
    public class PhysicsManager
    {
        public static World World = null!;

        private int velocityIterations = 8;
        private int positionIterations = 1;

        public PhysicsManager()
        {
            CreateWorld();
        }

        private void CreateWorld()
        {
            AABB worldAABB = new AABB
            {
                UpperBound = new Vec2(100000, 100000),
                LowerBound = new Vec2(-100000, -100000)
            };

            Vec2 gravity = new Vec2(0.0f, 0.0f);

            bool doSleep = true;

            World = new World(worldAABB, gravity, doSleep);
            World.SetContactFilter(new ContactFilter());
        }

        public void OnUpdate()
        {
            World.Step(GameTime.UpdateDeltaTime, velocityIterations, positionIterations);
        }
    }
}