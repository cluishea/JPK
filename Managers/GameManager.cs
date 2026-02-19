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

        int score;
        int scoreDrawWidthOffset = 972;
        int scoreDrawHeightOffset = 150;

        public GameManager(){
            score = 0;
        }
        
        internal override void Load(ContentManager content)
        {
            font = content.Load<SpriteFont>("Font");
        }

        internal override void Update(GameTime gameTime)
        {
        }
        internal override void Draw(SpriteBatch spriteBatch)
        {
            string scoreString = "Score: "+Convert.ToString(score);
            spriteBatch.DrawString(font,scoreString,new Vector2(scoreDrawWidthOffset,scoreDrawHeightOffset),Color.White);
        }

    }
}
