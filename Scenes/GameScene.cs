using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MyGame.Core;
using MyGame.Managers;
using MyGame.Sprites;
using MyGame.World;

namespace MyGame.Scenes
{
    class GameScene : Scene
    {
        bool isGameOver = false;

        private Map map;
        private ProjectileManager projectileManager;
        private Player player;
        
        public GameScene(GameSceneManager gsm) : base(gsm)
        {
        }

        internal override void Load(ContentManager content)
        {
            map = new Map();
            map.Load(content);
            projectileManager = new ProjectileManager();
            projectileManager.Load(content);
            player = new Player(map,projectileManager);
            player.Load(content);
        }

        internal override void Update(GameTime gameTime)
        {
            player.Update(gameTime);
            projectileManager.Update(gameTime);
            map.Update(gameTime);
        }

        internal override void Draw(SpriteBatch spriteBatch)
        {
            map.Draw(spriteBatch);
            player.Draw(spriteBatch);
            projectileManager.Draw(spriteBatch);
        }
    }


}
