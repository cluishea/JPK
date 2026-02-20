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
        Player player;
        Map map;
        List <Sprite> enemies = new List<Sprite>();

        int timeSinceLastSpawn;
        int lastSpawnCount;

        public EnemyManager(Player _player,Map _map)
        {
            player = _player; 
            map = _map;

            timeSinceLastSpawn = 0;
            lastSpawnCount = 0;
        }

        internal override void Load(ContentManager content)
        {
            Slime slime = new Slime(new Vector2(0,0),player);
            slime.Load(content);
            enemies.Add(slime);

        }

        internal override void Update(GameTime gameTime)
        {
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
