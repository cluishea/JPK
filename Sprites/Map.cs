


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
    List<int> textureDistribution = new List<int> {0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,2,2,2,2,2,2,2,2,2,2,3,3,3,3,3,3,3,3,3,3,4,4,4,4,4,5,5,5,5,5,5,5,5,5,5,6,6,6,6,6};
    public Map(){
        texture = AssetManager.LoadTexture("gameSheet");
        
        for (int i = 0; i < rows; ++i)
        {
            List<int> row = new List<int>();
            for (int j = 0; j<columns; ++j)
            {   
                int temp = random.Next(0,textureDistribution.Count);
                row.Add(textureDistribution[temp]);

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
                            new Rectangle(i*tileWidth, j* tileHeight,tileWidth,tileHeight),
                            new Rectangle(tileMap[i][j]*tileWidth, 0* tileHeight,tileWidth,tileHeight),
                            Color.White
                            );
            }
        }
    }


   





}
