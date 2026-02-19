using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MyGame.Core;
using MyGame.GameElements;
using MyGame.World;

namespace MyGame.Managers
{

    internal class ProjectileManager : Components
    {
        
        Texture2D texture;
        List<Projectile> projectiles = new List<Projectile>();

        public void CreateProjectile(Vector2 _startPosition,Vector2 _velocity, Map _map)
        {
            Projectile _temp = new Projectile(_startPosition,_velocity,_map,texture);
            projectiles.Add(_temp);
        }


        internal override void Load(ContentManager content)
        {
            texture = content.Load<Texture2D>("gameSheet");
        }

        internal override void Update(GameTime gameTime)
        {

            for (int i = projectiles.Count-1; i>=0 ; --i)
            {
                if (projectiles[i].isOutOfBounds)
                {
                    projectiles.RemoveAt(i);
                }
            }

            foreach (Projectile projectile in projectiles)
            {
                projectile.Update(gameTime);
            }
        }

        internal override void Draw(SpriteBatch spriteBatch)
        {
            foreach (Projectile projectile in projectiles)
            {
                projectile.Draw(spriteBatch);
            }
        }

    }

}
