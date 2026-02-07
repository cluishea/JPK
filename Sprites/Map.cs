


using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


class Map
{
    Random random = new Random();
    
    int rows = 16;
    int columns = 16;
    int tileHeight = 32;
    int tileWidth = 32;

    Texture2D texture;

    List<List<int>> tileMap = new List<List<int>>();

    public Map(){
        texture = AssetManager.LoadTexture("gameSheet");
        
        for (int i = 0; i < rows; ++i)
        {
            List<int> row = new List<int>();
            for (int j = 0; j<columns; ++j)
            {
                row.Add(random.Next(0,10));
            }
            tileMap.Add(row);
        }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        for (int i = 0; i < rows; ++i)
        {
            for (int j = 0; j<columns; ++j)
            {
                spriteBatch.Draw(texture,
                            new Rectangle(i*tileHeight, j* tileWidth,tileHeight,tileWidth),
                            new Rectangle(0*tileHeight, tileMap[i][j]* tileWidth,tileHeight,tileWidth),
                            Color.White
                            );
            }
        }
    }


   





}
