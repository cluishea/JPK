using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.Xna.Framework;
using MyGame.Utilities;

namespace MyGame.Sprites
{
    class Enemy : Sprite
    {
        protected Player player;
        protected int health;
        public bool isAlive;

        public int pointsOnDefeat; 
        
        public void DropHealth(int amount)
        {
            health-=amount;
        }

        protected Vector2 GetDirection()
        {
            RayCast ray = new RayCast(Origin,player.Origin);
            if (!ray.RayCastCheck(map.collisionTiles))
            {
                return ray.direction;
            }
            Randomizer.Shuffle<Rectangle>(player.rectanglesWithLineOfSight);            
            foreach (Rectangle rectangle in player.rectanglesWithLineOfSight)
            {
                ray = new RayCast(Origin,new Vector2(rectangle.X+map.tileWidth/2,rectangle.Y+map.tileHeight/2));
                if (!ray.RayCastCheck(map.collisionTiles))
                {
                    return ray.direction;
                }
            }
            return Randomizer.RandomVector2();
        }
    }
}
