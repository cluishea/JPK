using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MyGame.Core;

namespace MyGame.GameElements
{
    class Item : Components
    {
        public Texture2D texture;
        public Rectangle textureRectangle;
        public int height = 16;
        public int width = 16;

        internal override void Load(ContentManager content)
        {
        }

        internal override void Update(GameTime gameTime)
        {
        }

        internal override void Draw(SpriteBatch spriteBatch)
        {
        }
    }
}
