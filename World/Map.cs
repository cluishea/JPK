using System.Collections.Generic;
using System.Globalization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MyGame.Core;
using MyGame.Utilities;

namespace MyGame.World
{
    class Map : Components
    {

        Texture2D mapTexture;
        Rectangle borderTextureRectangle;
        List<Rectangle> tilesTextureRectangle = new List<Rectangle>();

        int heightOffset = 0;
        int widthOffset = 0;

        
        int tileHeight = 32;
        int tileWidth = 32;
        int numRows = 16;
        int numColumns = 16;
        int mapHeight;
        int mapWidth;

        List<List<int>> tileMap = new List<List<int>>();
        List<List<int>> textureMap = new List<List<int>>();
        int numTextures = 6;

        private void CreateTileMap()
        {
            for(int i = 0; i < numRows; i++)
            {
                List<int> thisRow = new List<int>();
                List<int> thisRowTexture = new List<int>();
                for(int j = 0;j < numColumns; j++)
                {   
                    thisRowTexture.Add(Randomizer.RandomInteger(numTextures));
                    if(i == 0 || j == 0 || i == numRows-1 || j == numColumns-1)
                    {
                        thisRow.Add(-1);
                    }
                    else
                    {
                        thisRow.Add(0);
                    }
                }
                tileMap.Add(thisRow);
                textureMap.Add(thisRowTexture);
            }
        }

        internal override void Load(ContentManager content)
        {
            mapTexture = content.Load<Texture2D>("gameSheet");
            mapHeight = numRows*tileHeight;
            mapWidth = numColumns*tileWidth;

            borderTextureRectangle = new Rectangle(9*tileWidth,0,tileWidth,tileHeight);
            for (int temp = 0; temp<numTextures; ++temp)
            {
                tilesTextureRectangle.Add(new Rectangle(tileWidth*temp,0,tileWidth,tileHeight));
            }

            CreateTileMap();

        }
        
        internal override void Update(GameTime gameTime)
        {
        }


        internal override void Draw(SpriteBatch spriteBatch)
        {
            for(int i = 0; i< numRows; i++)
            {
                for(int j = 0; j < numColumns; j++)
                {
                    spriteBatch.Draw(mapTexture,new Rectangle(widthOffset+tileWidth*j,heightOffset+tileHeight*i,tileWidth,tileHeight),tilesTextureRectangle[textureMap[i][j]],Color.White);
                    if (tileMap[i][j] == -1)
                    {
                        spriteBatch.Draw(mapTexture,new Rectangle(widthOffset+tileWidth*j,heightOffset+tileHeight*i,tileWidth,tileHeight),borderTextureRectangle,Color.White);
                    }
                }
            }
        }

    }
}
