
/*
Game scenes manager class
Partial class so code can be split to many files
*/

using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MyGame.Core;
using MyGame.Scenes;

namespace MyGame.Managers 
{
    internal partial class GameSceneManager : Components
    {
        
        ContentManager content;
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
                case GameConfig.Scenes.Pause:
                    GameConfig.currentScene = GameConfig.Scenes.Pause;
                    break;
                case GameConfig.Scenes.GameOver:
                    GameConfig.currentScene = GameConfig.Scenes.GameOver;
                    break;
            }
        }

        internal override void Load(ContentManager _content)
        {
            content = _content;

            gameScene = new GameScene(this);
            gameScene.Load(content);

            menuScene = new MenuScene(this);
            menuScene.Load(content);
        }

        internal override void Update(GameTime gameTime)
        {

            if (InputManager.keyboardState.IsKeyDown(Keys.Space) && GameConfig.currentScene==GameConfig.Scenes.Menu)
            {
                ChangeScene(GameConfig.Scenes.Game);
            }

            if (InputManager.IsKeyPressed(Keys.P) && GameConfig.currentScene==GameConfig.Scenes.Game)
            {
                ChangeScene(GameConfig.Scenes.Pause);
            }
            else if (InputManager.IsKeyPressed(Keys.P) && GameConfig.currentScene==GameConfig.Scenes.Pause)
            {
                ChangeScene(GameConfig.Scenes.Game);
            }


            if (InputManager.IsKeyPressed(Keys.Space) && GameConfig.currentScene==GameConfig.Scenes.GameOver)
            {
                ChangeScene(GameConfig.Scenes.Game);
                gameScene = new GameScene(this);
                gameScene.Load(content);
            }            


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
                case GameConfig.Scenes.Pause:
                    gameScene.Draw(spriteBatch);
                    break;
                case GameConfig.Scenes.GameOver:
                    break;
            }
        }
    }

}
