using BoxEngine.Game;
using BoxEngine.Graphics;

public class AnimationsSystem
{
       public Animation[] Animations;
       private int currentFrame;
       private float _playTimer;
       
       public AnimationsSystem(Animation[] animations)
       {
              Animations = animations;
       }

       public void PlayAnimation(int index, float speed, out Sprite frame)
       {
              _playTimer += speed * 10f * GameTime.UpdateDeltaTime;

              if (_playTimer > 1f)
              {
                     currentFrame++;
                     _playTimer = 0f;
              }

              if (currentFrame >= Animations[index].Frames.Length)
                     currentFrame = 0;

              frame = Animations[index].Frames[currentFrame];
       }
}

public struct Animation
{
       public Sprite[] Frames;
}