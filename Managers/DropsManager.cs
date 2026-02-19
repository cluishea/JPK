using System.ComponentModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MyGame.Core;

namespace MyGame.Managers
{

    class DropsManager : Components
    {   
        Texture2D texture;        
        SpriteFont font16;
        SpriteFont font32;

        

        public DropsManager()
        {
            
        }

        internal override void Load(ContentManager content)
        {
            texture = content.Load<Texture2D>("gameSheet");
            font16 = content.Load<SpriteFont>("Font16");
            font32 = content.Load<SpriteFont>("Font32");
        }

        internal override void Update(GameTime gameTime)
        {
        }

        internal override void Draw(SpriteBatch spriteBatch)
        {
        }
    }



}
