using System.Collections.Generic;

namespace BoxEngine.Game
{
    public class GameSceneManager
    {
        public static List<GameScene> GameScenes = new List<GameScene>();
        public static GameScene CurrentGameScene = null!;
        public static GameSandbox GameSandbox = null!;

        public GameSceneManager(GameSandbox gameSandbox) =>  GameSandbox = gameSandbox;
        public static void AddGameScene(GameScene gameScene) => GameScenes.Add(gameScene);

        public static void ChangeGameScene(int index) => CurrentGameScene = GameScenes[index];
    }
}