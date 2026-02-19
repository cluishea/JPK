using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MyGame.Core;

namespace MyGame.Managers
{
    class GameManager : Components
    {

        SpriteFont font32;
        SpriteFont font16;
        Texture2D texture;

        // Player lives
        int livesLeft;
        int MAX_LIVES = 10;
        int livesDrawWidthOffset = 350;
        int livesDrawHeightOffset = 600; // Most bottom 
 
        // Gamescore

        int score;
        int scoreDrawWidthOffset = 950;
        int scoreDrawHeightOffset = 120;
        Rectangle lifesSymbolTextureRectangle = new Rectangle(32,64,32,32);

        // Coins
        int numberOfCoins;
        Rectangle coinTextureRectangle = new Rectangle(16,64,16,16);
        int coinDrawWidthOffset = 850;
        int coinDrawHeightOffset = 650;

        public GameManager(){
            score = 0;
            livesLeft = 3;
            numberOfCoins = 0;
        }
        
        internal override void Load(ContentManager content)
        {
            font32 = content.Load<SpriteFont>("Font32");
            font16 = content.Load<SpriteFont>("Font16");
            texture = content.Load<Texture2D>("gameSheet");
            
        }

        internal override void Update(GameTime gameTime)
        {
        }
        internal override void Draw(SpriteBatch spriteBatch)
        {
            string scoreString = "Score: "+Convert.ToString(score);
            spriteBatch.DrawString(font32,scoreString,new Vector2(scoreDrawWidthOffset,scoreDrawHeightOffset),Color.White);

            string coinsString = Convert.ToString(numberOfCoins);
            spriteBatch.Draw(texture,new Rectangle(coinDrawWidthOffset,coinDrawHeightOffset,16,16),coinTextureRectangle,Color.White);
            spriteBatch.DrawString(font16,coinsString, new Vector2(coinDrawWidthOffset + 24, coinDrawHeightOffset),Color.White);


            for (int i = 0; i<livesLeft; i++)
            {
                spriteBatch.Draw(texture,new Rectangle(livesDrawWidthOffset,livesDrawHeightOffset-i*32-16*i,32,32),lifesSymbolTextureRectangle,Color.White);
            }

        }

    }
}
