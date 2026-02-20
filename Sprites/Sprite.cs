/*
Template Sprite class
*/


using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MyGame.Core;

namespace MyGame.Sprites
{
    internal class Sprite : Components
    {
        
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
