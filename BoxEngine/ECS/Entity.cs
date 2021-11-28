using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoxEngine.Game
{
    public class Entity
    {
        public int ID { get; set; }
        private List<Component> components = new List<Component>();

        public Entity()
        {
            ECS.AddEntity(this);
        }

        public void OnUpdate()
        {
            for (int i = 0; i < components.Count; i++)
                components[i].OnUpdate();
        }

        public void OnDraw()
        {
            for (int i = 0; i < components.Count; i++)
                components[i].OnDraw();
        }

        public void OnDrawGUI()
        {
            for (int i = 0; i < components.Count; i++)
                components[i].OnDrawGUI();
        }

        public Component AddComponent(Component component)
        {
            component.entity = this;
            component.OnStart();
            components.Add(component);
            return component;
        }

        public T GetComponent<T>() where T : Component
        {
            foreach (Component component in components)
            {
                if (component.GetType().Equals(typeof(T)))
                {
                    return (T)component;
                }
            }
            return null;
        }
    }
}
