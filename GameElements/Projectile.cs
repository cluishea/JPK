using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MyGame.Sprites;
using MyGame.World;

namespace MyGame.GameElements
{
    class Projectile : Sprite
    {

        // Offsets while drawing
        int heightOffset = 120;
        int widthOffset = 400;

        Map map;
        Rectangle textureRectangle;
        public bool isOutOfBounds;
        int MAX_VELOCITY = 4;

        public Projectile(Vector2 _position, Vector2 _startvelocity, Map _map, Texture2D _texture) : base(_position)
        {
            velocity = _startvelocity*MAX_VELOCITY;
            map = _map;
            texture = _texture;
            height = 6;
            width = 6;
            textureRectangle = new Rectangle(0,64,width,height);
            isOutOfBounds = false;
            UpdateBoundingRectangle();
        }

        private void UpdateBoundingRectangle()
        {
            boundingRectangle = new Rectangle((int)position.X,(int)position.Y,height,width);
        }

        internal override void Load(ContentManager content)
        {
            texture = content.Load<Texture2D>("gameSheet");
            textureRectangle = new Rectangle(0,64,width,height);
        }
        internal override void Update(GameTime gameTime)
        {
            position.X += velocity.X;
            position.Y += velocity.Y;

            if (position.X < 0 || position.Y < 0 || position.X + width > map.mapWidth || position.Y+height> map.mapHeight)
            {
                isOutOfBounds = true;
            }
            UpdateBoundingRectangle();
        }

        internal override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture,new Rectangle(boundingRectangle.X+widthOffset,boundingRectangle.Y+heightOffset,width,height),textureRectangle,Color.White);
        }
    }
}
