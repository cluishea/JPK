using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MyGame.Core;
using MyGame.GameElements;
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
        private DropsManager dropsManager;

        private void HandleKills()
        {
            foreach (Projectile projectile in projectileManager.projectiles)
            {
                foreach(Enemy enemy in enemyManager.enemies)
                {
                    if (projectile.BoundingRectangle.Intersects(enemy.BoundingRectangle))
                    {
                        projectile.isAlive = false;
                        enemy.DropHealth(1);
                        gameManager.AddScore(enemy.pointsOnDefeat);
                        dropsManager.HandleMobDrop(enemy);
                        break;                        
                    }
                }
            }

            foreach (Enemy enemy in enemyManager.enemies)
            {
                if (enemy.BoundingRectangle.Intersects(player.BoundingRectangle))
                {
                    player.Die();
                    gameManager.RemoveLife();
                    projectileManager.RemoveAll();
                    enemyManager.RemoveAll();
                    dropsManager.RemoveAll();
                    break;
                }
            }
        }
        
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

            dropsManager = new DropsManager();
            dropsManager.Load(content);
        }

        internal override void Update(GameTime gameTime)
        {

            player.Update(gameTime);
            map.Update(gameTime);
            projectileManager.Update(gameTime);
            gameManager.Update(gameTime);    
            enemyManager.Update(gameTime);
            dropsManager.Update(gameTime);

            HandleKills();

            if (gameManager.isGameOver)
            {
                gsm.ChangeScene(GameConfig.Scenes.GameOver);
            }

        }

        internal override void Draw(SpriteBatch spriteBatch)
        {
            gameManager.Draw(spriteBatch);
            map.Draw(spriteBatch);
            projectileManager.Draw(spriteBatch);
            dropsManager.Draw(spriteBatch);
            enemyManager.Draw(spriteBatch);
            player.Draw(spriteBatch);

        }
    }


}
