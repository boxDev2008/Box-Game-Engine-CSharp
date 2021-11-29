# Requirements
### You will need to have .NET 6 SDK installed on your pc.

# Create the Game Application

Open the ```Program.cs``` file.

## First - Create a window.
We use the ```WindowFrame``` class to represent our window and you can create on like this:
```cs WindowFrame window = new WindowFrame();```

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
```cs 
GameSandbox gameSandbox = new MainSandbox();
```

##Last - Create the Application.
Now we just need to initialize the ```GameApplication``` class like this:
```cs GameApplication game = new GameApplication(window, gameSandbox);```
