using BoxEngine;
using BoxEngine.Game;
using BoxEngine.Graphics.Windowing;


GameApplication.SetConsoleState(true);

WindowFrame window = new WindowFrame
{
    VSync = OpenTK.Windowing.Common.VSyncMode.Off,
    RenderFrequency = 300,
    UpdateFrequency = 300,
    Title = "Game Window"
};

GameSandbox gameSandbox = new MainSandbox();
GameApplication game = new GameApplication(window, gameSandbox);
