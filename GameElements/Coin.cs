
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MyGame.GameElements
{
    class Coin : Item
    {
        internal override void Load(ContentManager content)
        {
            texture = content.Load<Texture2D>("gameSheet");
            textureRectangle = new Rectangle(16,64,height,width);
        }
    }
}
