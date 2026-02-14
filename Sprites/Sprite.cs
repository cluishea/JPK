/*
Template Sprite class
*/


using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MyGame.Core;

namespace MyGame.Sprites
{
    class Sprite : Components
    {
        
        private Texture2D texture;
        private Vector2 position;
        private Vector2 velocity;
        private Rectangle boundingRectangle;
        private float speed;
        private int sourceTextureRectangle;
        

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
