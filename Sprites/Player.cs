using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using MyGame.Managers;
using MyGame.World;

namespace MyGame.Sprites
{
    class Player : Sprite
    {
        Map map;
        ProjectileManager projectileManager;
        Vector2 defaultStartPosition = new Vector2(8*32,8*32);

        int MAX_VELOCITY = 2;

        // Offsets while drawing
        int heightOffset = 120;
        int widthOffset = 400;

        // Number of frames between shooting
        int DEFAULT_SHOOT_TIMER = 20;
        int shootTimer;
        int timeSinceLastShoot;
        bool isShooting = false;
        bool canShoot = true;

        // Player state
        bool isIdle = true;

        // Animations
        enum Animations {Idle, Shooting};

        List<Rectangle> IDLE_ANIMATION_FRAMES;
        List <Rectangle> SHOOTING_ANIMATION_FRAMES;

        Animations currentAnimation;
        List<Rectangle> currentAnimationFrames;
        int currentAnimationFrame;
        int animationFrameTimer;
        // The animation works like Stardew Valley (I think) where animation needs to finish before playing another one
        int animationFrameDelay;
        bool mustCompleteAnimation;
        bool animationComplete;
        int FRAME_DELAY_IDLE = 30;
        int FRAME_DELAY_SHOOTING = 30;

        
        private void Initialize()
        {

            // Animation frames 

            height = 32;
            width = 32;

            IDLE_ANIMATION_FRAMES = new List<Rectangle>()
            {
              new Rectangle(0,32,width,height),
              new Rectangle(32,32,width,height)  
            };

            SHOOTING_ANIMATION_FRAMES = new List<Rectangle>()
            {
              new Rectangle(64,32,width,height)  
            };

            velocity = Vector2.Zero;
            
            shootTimer = DEFAULT_SHOOT_TIMER;
            timeSinceLastShoot = 0;

            currentAnimation = Animations.Idle;
            currentAnimationFrame = 0;
            animationFrameDelay = FRAME_DELAY_IDLE;
            animationFrameTimer = 0;
            currentAnimationFrames = IDLE_ANIMATION_FRAMES;
            mustCompleteAnimation = false;
            animationComplete = false;

            UpdateBoundingRectangle();
        }

        private void UpdateAnimation()
        {   

            animationFrameTimer++;
            if (animationFrameTimer == animationFrameDelay)
            {
                animationFrameTimer = 0;
                currentAnimationFrame++;
                if (currentAnimationFrame == currentAnimationFrames.Count)
                {
                    animationComplete = true;
                    currentAnimationFrame = 0;
                }
            }


            // Updating what animation plays (Special animations other than run/idle)

            if (isShooting)
            {
                currentAnimation = Animations.Shooting;
                currentAnimationFrame = 0;
                animationFrameDelay = FRAME_DELAY_SHOOTING;
                animationFrameTimer = 0;
                currentAnimationFrames = SHOOTING_ANIMATION_FRAMES;
                mustCompleteAnimation = true;
                animationComplete = false;
            }

            // Updating the animation

            if(animationComplete || !mustCompleteAnimation)
            {
                if (isIdle && currentAnimation!=Animations.Idle)
                    {
                        currentAnimation = Animations.Idle;
                        currentAnimationFrame = 0;
                        animationFrameDelay = FRAME_DELAY_IDLE;
                        animationFrameTimer = 0;
                        currentAnimationFrames = IDLE_ANIMATION_FRAMES;
                        mustCompleteAnimation = false;
                        animationComplete = false;
                    }
            }
        }

        private void UpdateBoundingRectangle()
        {
            boundingRectangle = new Rectangle((int)position.X,(int)position.Y,width,height);
            origin = new Vector2(position.X+width/2,position.Y+height/2);
        }

        private void HandleShootingInput()
        {
            isShooting = false;
            Vector2 projectileDirection = Vector2.Zero;

            if (timeSinceLastShoot > shootTimer)
            {
                canShoot = true;
            }
            if (canShoot)
            {
                if (InputManager.keyboardState.IsKeyDown(Keys.Right))
                {
                    projectileDirection.X = 1;
                    timeSinceLastShoot = 0;
                    isShooting = true;
                }
                if (InputManager.keyboardState.IsKeyDown(Keys.Left))
                {
                    projectileDirection.X = -1;
                    timeSinceLastShoot = 0;
                    isShooting = true;
                }
                if (InputManager.keyboardState.IsKeyDown(Keys.Up))
                {
                    projectileDirection.Y = -1;
                    timeSinceLastShoot = 0;
                    isShooting = true;
                }
                if (InputManager.keyboardState.IsKeyDown(Keys.Down))
                {
                    projectileDirection.Y = 1;
                    timeSinceLastShoot = 0;
                    isShooting = true;
                }
                if (projectileDirection!=Vector2.Zero){
                    projectileDirection.Normalize();
                }
            }

            if (isShooting)
            {
                projectileManager.CreateProjectile(origin,projectileDirection,map);
                timeSinceLastShoot = 0;
                canShoot = false;
            }
            else
            {
                timeSinceLastShoot++;
            }
        }
        private void HandleMovementInput()
        {
            velocity = Vector2.Zero;
            if (InputManager.keyboardState.IsKeyDown(Keys.A))
            {
                velocity.X = -1f; 
            }
            if (InputManager.keyboardState.IsKeyDown(Keys.W))
            {
                velocity.Y = -1f; 
            }
            if (InputManager.keyboardState.IsKeyDown(Keys.S))
            {
                velocity.Y = 1f; 
            }
            if (InputManager.keyboardState.IsKeyDown(Keys.D))
            {
                velocity.X = 1f; 
            }

            // Normalize velocity
            if (velocity!= Vector2.Zero){
                velocity.Normalize();
                velocity*=MAX_VELOCITY;
                isIdle = false;
            }
            else
            {
                isIdle = true;
            }
        }   
        
        private bool CheckCollision(Vector2 newPosition)
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
        private void MovePlayer()
        {
            Vector2 newPosition = new Vector2(position.X+velocity.X, position.Y+velocity.Y);

            if (!CheckCollision(newPosition))
            {
                position = newPosition;
            }

        }
        
        public Player(Map _map, ProjectileManager _projectileManager){
            position = defaultStartPosition;
            map = _map;
            projectileManager = _projectileManager;
            Initialize();
        }


        public Player(Vector2 _startPosition,Map _map, ProjectileManager _projectileManager) : base(_startPosition){
            map = _map;
            projectileManager = _projectileManager;
            Initialize();
        }

       
        internal override void Load(ContentManager content)
        {
            texture = content.Load<Texture2D>("gameSheet");
           
        }

        internal override void Update(GameTime gameTime)
        {
            HandleMovementInput();
            HandleShootingInput();

            MovePlayer();

            UpdateAnimation();
           
            UpdateBoundingRectangle();
        }

        internal override void Draw(SpriteBatch spriteBatch)
        {  
            Rectangle drawingRectangle = new Rectangle(boundingRectangle.X+widthOffset,boundingRectangle.Y+heightOffset,width,height);
            spriteBatch.Draw(texture,drawingRectangle,currentAnimationFrames[currentAnimationFrame],Color.White);
        }
    }
}

