namespace BoxEngine.Game
{
    public class ECS
    {
        public static List<Entity> entities = null!;

        public ECS()
        {
            entities = new List<Entity>();
        }

        public static void AddEntity(Entity entity)
        {
            entities.Add(entity);
        }

        public static void RemoveEntity(Entity entity)
        {
            entities.Remove(entity);
        }

        public static void OnUpdate()
        {
            for (int i = 0; i < entities.Count; i++)
                entities[i].OnUpdate();
        }

        public static void OnDraw()
        {
            for (int i = 0; i < entities.Count; i++)
                entities[i].OnDraw();

            for (int i = 0; i < entities.Count; i++)
                entities[i].OnDrawGUI();
        }
    }
}