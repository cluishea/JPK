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

        private GameManager gameManager;
        private Map map;
        private ProjectileManager projectileManager;
        private Player player;
        private EnemyManager enemyManager;
        
        public GameScene(GameSceneManager gsm) : base(gsm)
        {
        }

        internal override void Load(ContentManager content)
        {
            projectileManager = new ProjectileManager();
            projectileManager.Load(content);
            gameManager = new GameManager();
            gameManager.Load(content);

            map = new Map();
            map.Load(content);
            player = new Player(map,projectileManager);
            player.Load(content);

            enemyManager = new EnemyManager(player,map);
            enemyManager.Load(content);
        }

        internal override void Update(GameTime gameTime)
        {
            player.Update(gameTime);
            map.Update(gameTime);
            projectileManager.Update(gameTime);
            gameManager.Update(gameTime);    
            enemyManager.Update(gameTime);
        }

        internal override void Draw(SpriteBatch spriteBatch)
        {
            
            map.Draw(spriteBatch);
            projectileManager.Draw(spriteBatch);
            player.Draw(spriteBatch);
            gameManager.Draw(spriteBatch);
            enemyManager.Draw(spriteBatch);
        }
    }


}
