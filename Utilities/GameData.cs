using System.Dynamic;
using System.Reflection.Metadata;

/* Static class GameData
Contains information about the width and height of the game
Current scane of the game
*/

internal static class GameData
{
    static internal int gameWidth {get;} = 512;
    static internal int gameHeight {get; } = 528;

    internal enum GameScene
    {
                menuScene,
                gameScene
    }   

    static internal GameScene currentScene {get; private set;} = GameScene.menuScene;

    static internal void ChangeScene (GameScene newScene)
    {
        currentScene = newScene;
    }




}
