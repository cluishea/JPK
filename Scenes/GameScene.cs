using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MyGame.Core;
using MyGame.Managers;
using MyGame.World;

namespace MyGame.Scenes
{
    class GameScene : Scene
    {
        bool isGameOver = false;
        private Map map;
        public GameScene(GameSceneManager gsm) : base(gsm)
        {
        }

        internal override void Load(ContentManager content)
        {
            map = new Map();
            map.Load(content);
        }

        internal override void Update(GameTime gameTime)
        {
        }

        internal override void Draw(SpriteBatch spriteBatch)
        {
            map.Draw(spriteBatch);
        }
    }


}
