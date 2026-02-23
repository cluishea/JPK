using System.Collections.Generic;
using System.Net;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MyGame.Utilities;
using MyGame.World;

namespace MyGame.Sprites
{
    
    class Slime : Enemy
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

        int MAX_HEALTH = 1;

        Animation idleAnimation;
        Animation jumpingAnimation;
        Animation currentAnimation;


        public Slime(Vector2 _startPosition,  Player _player,Map _map)
        {
            player = _player;
            map = _map;

            position = _startPosition;
            width = 32;
            height = 32;

            isJumping = false;
            currentActionTimer = 0;
            direction = Vector2.Zero;
            speed = 0;

            health = 1;
            isAlive = true;

            pointsOnDefeat = 10;

            List<Rectangle> IDLE_ANIMATION_FRAMES = new List<Rectangle>
            {
                new Rectangle(0,96,width,height),
                new Rectangle(32,96,width,height)
            };
            List<Rectangle> JUMPING_ANIMATION_FRAMES = new List<Rectangle>
            {
                new Rectangle(64,96,width,height),
            };

            idleAnimation =new Animation("Idle",IDLE_ANIMATION_FRAMES,30,false);
            jumpingAnimation = new Animation("Jumping",JUMPING_ANIMATION_FRAMES,30,true);

            currentAnimation = idleAnimation;
            UpdateBoundingRectangle();
        }

        void UpdateTimings()
        {
            currentActionTimer++;
            currentAnimation.FramePass();

            if (isJumping)
            {
                if (currentActionTimer == JUMP_TIMER)
                {
                    isJumping = false;
                    currentActionTimer = 0;
                    speed = 0;

                    velocity = direction*speed;

                    currentAnimation = idleAnimation;
                    currentAnimation.Restart();
                }
            }
            else
            {
                if (currentActionTimer == JUMP_WAIT_TIMER)
                {
                    isJumping = true;
                    currentActionTimer = 0;
                    speed = MAX_VELOCITY;

                    direction = new Vector2(player.Origin.X - position.X, player.Origin.Y - position.Y);
                    if (direction != Vector2.Zero)
                    {
                        direction.Normalize();
                    }
                    velocity = direction*speed;

                    currentAnimation = jumpingAnimation;
                    currentAnimation.Restart();

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

            if (health == 0 || health <0)
            {
                isAlive = false;
            }

            Move();

            UpdateBoundingRectangle();
        }

        internal override void Draw(SpriteBatch spriteBatch)
        {
            Rectangle drawRectangle = new Rectangle(drawOffsetWidth+boundingRectangle.X,drawOffsetHeight+boundingRectangle.Y,width,height);
            Rectangle textureRectangle = currentAnimation.animationFrames[currentAnimation.currentAnimationFrame];
            if (isAlive){
                spriteBatch.Draw(texture,drawRectangle,textureRectangle,Color.White);
            }
            else
            {
                spriteBatch.Draw(texture,drawRectangle,textureRectangle,Color.Red);
            }
        }
    }



}
