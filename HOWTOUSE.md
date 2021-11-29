# Requirements
### You will need to have .NET 6 SDK installed on your pc.

# Create the Game Application

Open the ```Program.cs``` file.

## First - Create a window.
We use the ```WindowFrame``` class to represent our window and you can create on like this:

```WindowFrame window = new WindowFrame();```

We can also fill some aditional information about the window like this example:
```cs 
WindowFrame window = new WindowFrame
{
    VSync = OpenTK.Windowing.Common.VSyncMode.Off,
    RenderFrequency = 300,
    UpdateFrequency = 300,
    Title = "Game Window"
};
```

## Second - Create a sandbox.
We are almost there. Now we need to create a sandbox in which we can make our gameplay features.
We can simply do it like this:
```cs 
class MainSandbox : GameSandbox
{
  
}

```

After this we initialize the ```MainSandbox``` class by going back to where we were and typing this:
```
GameSandbox gameSandbox = new MainSandbox();
```

##Last - Create the Application.
Now we just need to initialize the ```GameApplication``` class like this:
```GameApplication game = new GameApplication(window, gameSandbox);```

# Setting up the gameplay loop
There are 3 main functions that we will use in this tutorial.

Called at the start of the game:
```cs 
    public override void OnStart()
    {
	    
    }
```

Called every update frame:
```cs 
    public override void OnUpdate()
    {
	    
    }
```

Called every draw frame:
```cs 
    public override void OnDraw()
    {
	    
    }
```

We put these in the ```MainSandbox``` class.

# Drawing on the screen
## Shapes
We need to go to our ```MainSandbox``` class and create a new ```OnDraw``` function.
Make sure you are ```using BoxEngine.Graphics;```.

Inside of the ```OnDraw``` function type the following:
```GameRenderer.DrawRectangle2D(0f, 0f, 20f, 20f, 0.5f, 0.5f, 45f, Color.White);```

- The first 2 parameters represent the position.
- The second 2 parameters represent the scale.
- The third 2 parameters represent the pivot.
- The fourth parameter represents the angle.
- The last parameter represents the Color.

You should be getting something like this:
![result1](https://imgur.com/a/32HAImO)
