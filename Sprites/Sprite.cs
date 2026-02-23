/*
Template Sprite class
*/


using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MyGame.Core;
using MyGame.World;

namespace MyGame.Sprites
{
    internal class Sprite : Components
    {
        protected Map map;
        protected Texture2D texture;
        protected Vector2 position;
        protected Vector2 velocity;
        protected Rectangle boundingRectangle;
        protected Vector2 origin;
        protected Rectangle sourceTextureRectangle;
        protected int height;
        protected int width;
        protected int speed;
        

        public Vector2 Position
        {
            get
            {
                return position;
            }
        }
        public Vector2 Velocity
        {
            get
            {
                return velocity;
            }
        }
        public Rectangle BoundingRectangle
        {
            get
            {
                return boundingRectangle;
            }
        }

        public Vector2 Origin
        {
            get
            {
                return origin;
            }
        }

        protected void UpdateBoundingRectangle()
        {
            boundingRectangle = new Rectangle((int)position.X,(int)position.Y,width,height);
            origin = new Vector2(position.X+width/2,position.Y+height/2);
        }

        protected bool CheckCollision(Vector2 newPosition)
        {
            // Check boundary condition
            if (newPosition.X < 0 || newPosition.Y < 0 || newPosition.X+width > map.mapWidth || newPosition.Y+height > map.mapHeight)
            {
                return true;
            }

            // Check tilemap 
            // Theres a O<1> way to do this
            for (int i = 0; i < map.numRows; ++i)
            {
                for(int j = 0; j<map.numColumns; ++j)
                {
                    if (map.tileMap[i][j] == -1 && new Rectangle(j*map.tileWidth,i*map.tileHeight,map.tileWidth,map.tileHeight).Intersects(new Rectangle((int)newPosition.X,(int)newPosition.Y,width,height)))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        protected void Move()
        {
            Vector2 newPosition = new Vector2(position.X+velocity.X, position.Y+velocity.Y);

            if (!CheckCollision(newPosition))
            {
                position = newPosition;
            }
        }

        public Sprite()
        {
            
        }

        public Sprite(Vector2 _position)
        {
            position = _position;
        }


        internal override void Load(ContentManager content)
        {
        }

        internal override void Update(GameTime gameTime)
        {
        }

        internal override void Draw(SpriteBatch spriteBatch)
        {
        }
    }
}
