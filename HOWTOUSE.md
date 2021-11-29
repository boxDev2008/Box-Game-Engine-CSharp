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

# Drawing on the screen
## Shapes
We need to go to our ```MainSandbox``` class and create a new ```OnDraw``` function.
Make sure you are ```using BoxEngine.Graphics;```.
```cs 
    public override void OnDraw()
    {
	    
    }
```
Inside of the function type the following:
```GameRenderer.DrawRectangle2D(0f, 0f, 20f, 20f, 0.5f, 0.5f, 45f, Color.White);```
