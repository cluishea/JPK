
/* 
GameConfig class holds the crucial configurations of the game.
*/

using System.Net;

namespace MyGame.Core
{
    public static class GameConfig
    {
        public static int screenWidth {get;set;} = 1280;
        public static int screenHeight {get;set;} = 720;


        public enum Scenes {Menu, Game}
        public static Scenes currentScene {get;set;} = Scenes.Menu;

    }
}
