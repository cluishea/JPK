using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MyGame.Core;

namespace MyGame.Managers
{
    class GameManager : Components
    {

        SpriteFont font;
        Texture2D texture;

        // Player lives
        int livesLeft;
        int MAX_LIVES = 10;
        int livesDrawWidthOffset = 350;
        int livesDrawHeightOffset = 600; // Most bottom 
 
        // Gamescore

        int score;
        int scoreDrawWidthOffset = 972;
        int scoreDrawHeightOffset = 150;
        Rectangle lifesSymbolTextureRectangle = new Rectangle(32,64,32,32);

        public GameManager(){
            score = 0;
            livesLeft = 3;
        }
        
        internal override void Load(ContentManager content)
        {
            font = content.Load<SpriteFont>("Font");
            texture = content.Load<Texture2D>("gameSheet");
        }

        internal override void Update(GameTime gameTime)
        {
        }
        internal override void Draw(SpriteBatch spriteBatch)
        {
            string scoreString = "Score: "+Convert.ToString(score);
            spriteBatch.DrawString(font,scoreString,new Vector2(scoreDrawWidthOffset,scoreDrawHeightOffset),Color.White);
        
            for (int i = 0; i<livesLeft; i++)
            {
                spriteBatch.Draw(texture,new Rectangle(livesDrawWidthOffset,livesDrawHeightOffset-i*32-16*i,32,32),lifesSymbolTextureRectangle,Color.White);
            }

        }

    }
}
