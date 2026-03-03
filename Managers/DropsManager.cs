using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MyGame.Core;
using MyGame.GameElements;
using MyGame.Sprites;
using MyGame.Utilities;

namespace MyGame.Managers
{

    class DropsManager : Components
    {   

        ContentManager content;
        Texture2D texture;         
        SpriteFont font16;
        SpriteFont font32;

        List<WorldItem> droppedItems = new List<WorldItem>();

        public void HandleMobDrop(Enemy enemy)
        {
            Coin coin = new Coin();
            coin.Load(content);
            WorldItem worldItem = new WorldItem(coin,enemy.Position);
            worldItem.Load(content);
            droppedItems.Add(worldItem);

        }

        public void RemoveAll()
        {
            droppedItems = new List<WorldItem>();
        }

        public DropsManager()
        {
            
        }

        internal override void Load(ContentManager _content)
        {
            content = _content;
            texture = content.Load<Texture2D>("gameSheet");
            font16 = content.Load<SpriteFont>("Font16");
            font32 = content.Load<SpriteFont>("Font32");
        }

        internal override void Update(GameTime gameTime)
        {
            foreach (WorldItem item in droppedItems)
            {
                item.Update(gameTime);
            }
        }

        internal override void Draw(SpriteBatch spriteBatch)
        {
            foreach (WorldItem item in droppedItems)
            {
                item.Draw(spriteBatch);
            }
        }
    }



}
