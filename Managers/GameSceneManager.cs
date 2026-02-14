
/*
Game scenes manager class
Partial class so code can be split to many files
*/

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MyGame.Core;
using MyGame.Scenes;

namespace MyGame.Managers 
{
    internal partial class GameSceneManager : Components
    {

        MenuScene menuScene;
        GameScene gameScene;

        public void ChangeScene(GameConfig.Scenes scene)
        {
            switch (scene)
            {
                case GameConfig.Scenes.Menu:
                    GameConfig.currentScene = GameConfig.Scenes.Menu;
                    break;
                case GameConfig.Scenes.Game:
                    GameConfig.currentScene = GameConfig.Scenes.Game;
                    break;
            }
        }

        internal override void Load(ContentManager content)
        {
            gameScene = new GameScene(this);
            gameScene.Load(content);

            menuScene = new MenuScene(this);
            menuScene.Load(content);
        }

        internal override void Update(GameTime gameTime)
        {
            switch (GameConfig.currentScene)
            {
                case GameConfig.Scenes.Menu:
                    menuScene.Update(gameTime);
                    break;
                case GameConfig.Scenes.Game:
                    gameScene.Update(gameTime);
                    break;
            }
        }

        internal override void Draw(SpriteBatch spriteBatch)
        {
            switch (GameConfig.currentScene)
            {
                case GameConfig.Scenes.Menu:
                    menuScene.Draw(spriteBatch);
                    break;
                case GameConfig.Scenes.Game:
                    gameScene.Draw(spriteBatch);
                    break;
            }
        }
    }

}
