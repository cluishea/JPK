using System.ComponentModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MyGame.Core;

namespace MyGame.GameElements
{
    class WorldItem : Components
    {
        protected Item item;
        protected Vector2 position;

        int heightOffset = 120;
        int widthOffset = 400;


        public WorldItem(Item _item,Vector2 _position)
        {
            item = _item;
            position = _position;
        }

        internal override void Load(ContentManager content)
        {
        }

        internal override void Update(GameTime gameTime)
        {
        }

        internal override void Draw(SpriteBatch spriteBatch)
        {
            Rectangle displayRectangle = new Rectangle((int)position.X+widthOffset,(int)position.Y+heightOffset,item.width,item.height);
            spriteBatch.Draw(item.texture,displayRectangle,item.textureRectangle,Color.White);
        }
    }



}
