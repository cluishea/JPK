using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MyGame.Core;
using MyGame.Sprites;
using MyGame.World;

namespace MyGame.Managers
{
    class EnemyManager : Components
    {

        ContentManager content;
        Player player;
        Map map;
        public List <Enemy> enemies = new List<Enemy>();

        int timeSinceLastSpawn;
        int lastSpawnCount;
        int currentEnemiesCount;



        public void RemoveAll()
        {
            enemies = new List<Enemy>();
        }

        public EnemyManager(Player _player,Map _map)
        {
            player = _player; 
            map = _map;

            timeSinceLastSpawn = 0;
            lastSpawnCount = 0;
            currentEnemiesCount = 0;


        }

        internal override void Load(ContentManager _content)
        {
            content = _content;
        }

        internal override void Update(GameTime gameTime)
        {

            if (timeSinceLastSpawn%48000 == 0){
                Slime slime = new Slime(new Vector2(50,50),player,map);
                slime.Load(content);
                enemies.Add(slime);
            }

            timeSinceLastSpawn++;

            for (int i = enemies.Count-1; i>=0 ; --i)
            {
                if (!enemies[i].isAlive)
                {
                    enemies.RemoveAt(i);
                }
            }

            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].Update(gameTime);
            }
        }

        internal override void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].Draw(spriteBatch);
            }
        }
    }
}
