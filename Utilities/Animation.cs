using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace MyGame.Utilities
{
    class Animation
    {
        public int currentAnimationFrame;
        public List<Rectangle> animationFrames;
        int animationFrameTimer;
        int animationFrameDelay;
        public bool mustCompleteAnimation;
        public bool animationComplete;

        public string name;

        public Animation(string _name,List<Rectangle> _animationFrames,int _animationFrameDelay, bool _mustCompleteAnimation){
            currentAnimationFrame = 0;
            animationFrames = _animationFrames;
            animationFrameTimer = 0;
            animationFrameDelay = _animationFrameDelay;
            mustCompleteAnimation = _mustCompleteAnimation;
            animationComplete = false;   
            name = _name; 
        }

        public void FramePass()
        {
            animationFrameTimer++;

            if (animationFrameTimer == animationFrameDelay)
            {
                animationFrameTimer = 0;
                currentAnimationFrame++;
                if (currentAnimationFrame == animationFrames.Count)
                {
                    animationComplete = true;
                    currentAnimationFrame = 0;
                }
            }
        }

        public void Restart()
        {
            animationComplete = false;
            currentAnimationFrame = 0;
            animationFrameTimer = 0;
        }


    }

}
