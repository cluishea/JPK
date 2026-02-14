using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MyGame.Core;
using MyGame.Managers;

namespace MyGame.Scenes
{

    internal partial class MenuScene : Scene
    {
        public MenuScene(GameSceneManager gsm) : base(gsm)
        {
        }

        internal override void Load(ContentManager content)
        {
        }

        internal override void Update(GameTime gameTime)
        {
            if (InputManager.keyboardState.IsKeyDown(Keys.Space))
            {
                gsm.ChangeScene(GameConfig.Scenes.Game);
            }
        }

        internal override void Draw(SpriteBatch spriteBatch)
        {
        }
    }

}
