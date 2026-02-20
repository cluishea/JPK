using System.Net;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MyGame.Sprites
{
    
    class Slime : Sprite
    {
        Player player;
        int MAX_VELOCITY = 4;
        int JUMP_WAIT_TIMER = 60;
        int JUMP_TIMER = 30;
        bool isJumping;
        int currentActionTimer;
        Vector2 direction;

        int drawOffsetWidth = 400;
        int drawOffsetHeight = 120;


        public Slime(Vector2 _startPosition,  Player _player)
        {
            player = _player;

            position = _startPosition;
            width = 32;
            height = 32;
            sourceTextureRectangle = new Rectangle(288,32,width,height);

            isJumping = false;
            currentActionTimer = 0;
            direction = Vector2.Zero;
            speed = 0;

            UpdateBoundingRectangle();
        }

        private void UpdateBoundingRectangle()
        {
            boundingRectangle = new Rectangle((int)position.X,(int)position.Y,width,height);
        }

        void UpdateTimings()
        {
            currentActionTimer++;

            if (isJumping)
            {
                if (currentActionTimer == JUMP_TIMER)
                {
                    isJumping = false;
                    currentActionTimer = 0;
                    speed = 0;

                    velocity = direction*speed;
                }
            }
            else
            {
                if (currentActionTimer == JUMP_WAIT_TIMER)
                {
                    isJumping = true;
                    currentActionTimer = 0;
                    speed = MAX_VELOCITY;

                    direction = new Vector2(player.Position.X - position.X, player.Position.Y - position.Y);
                    if (direction != Vector2.Zero)
                    {
                        direction.Normalize();
                    }
                    velocity = direction*speed;

                }
            }
        }

        internal override void Load(ContentManager content)
        {
            texture = content.Load<Texture2D>("gameSheet");
        }

        internal override void Update(GameTime gameTime)
        {
            UpdateTimings();


            position.X += velocity.X;
            position.Y += velocity.Y;

            UpdateBoundingRectangle();
        }

        internal override void Draw(SpriteBatch spriteBatch)
        {
            Rectangle drawRectangle = new Rectangle(drawOffsetWidth+boundingRectangle.X,drawOffsetHeight+boundingRectangle.Y,width,height);
            spriteBatch.Draw(texture,drawRectangle,sourceTextureRectangle,Color.White);
        }
    }



}
