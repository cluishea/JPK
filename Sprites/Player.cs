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
using MyGame.Utilities;
using MyGame.World;

namespace MyGame.Sprites
{
    class Player : Sprite
    {
        ProjectileManager projectileManager;
        Vector2 defaultStartPosition = new Vector2(8*32,8*32);

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
        List<Rectangle> IDLE_ANIMATION_FRAMES;
        List <Rectangle> SHOOTING_ANIMATION_FRAMES;

        Animation currentAnimation;
        Animation idleAnimation;
        Animation shootingAnimation;

        int lineOfSightDistance = 100; // Performance issues
        public List<Rectangle> rectanglesWithLineOfSight = new List<Rectangle>();


        void UpdateLineOfSight()
        {
            rectanglesWithLineOfSight = new List<Rectangle>();
            foreach (Rectangle rectangle in map.emptyTiles)
            {
                Vector2 tileOrigin = new Vector2(rectangle.X+map.tileWidth/2,rectangle.Y+map.tileHeight/2);
                RayCast ray = new RayCast(Origin,tileOrigin);
                if(ray.distance < lineOfSightDistance){
                    if(!ray.RayCastCheck(map.collisionTiles))
                    {
                        rectanglesWithLineOfSight.Add(rectangle);
                    }
                }
            }
        }


        public void Die()
        {
            position = defaultStartPosition;

            velocity = Vector2.Zero;
            
            shootTimer = DEFAULT_SHOOT_TIMER;
            timeSinceLastShoot = 0;

            currentAnimation = idleAnimation;

            UpdateBoundingRectangle();
        }

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
            speed = 2;


            idleAnimation = new Animation("Idle",IDLE_ANIMATION_FRAMES,60,false);
            shootingAnimation = new Animation("Shooting",SHOOTING_ANIMATION_FRAMES, 30, true);

            currentAnimation = idleAnimation;
 

            UpdateBoundingRectangle();
        }

        private void UpdateAnimation()
        {   

            currentAnimation.FramePass();

            // Updating what animation plays (Special animations other than run/idle)

            if (isShooting)
            {
                currentAnimation = shootingAnimation;
                shootingAnimation.Restart();
            }

            // Updating the animation

            if(currentAnimation.animationComplete || !currentAnimation.mustCompleteAnimation)
            {
                if (isIdle && currentAnimation.name!="Idle")
                    {
                        currentAnimation = idleAnimation;
                        idleAnimation.Restart();
                    }
            }
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

            if (velocity!= Vector2.Zero){
                velocity.Normalize();
                velocity*=speed;
                isIdle = false;
            }
            else
            {
                isIdle = true;
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

            Move();

            UpdateAnimation();
           
            UpdateBoundingRectangle();

            UpdateLineOfSight();
        }

        internal override void Draw(SpriteBatch spriteBatch)
        {  
            Rectangle drawingRectangle = new Rectangle(boundingRectangle.X+widthOffset,boundingRectangle.Y+heightOffset,width,height);
            spriteBatch.Draw(texture,drawingRectangle,currentAnimation.animationFrames[currentAnimation.currentAnimationFrame],Color.White);
        }
    }
}

