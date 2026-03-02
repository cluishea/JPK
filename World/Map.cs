using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MyGame.Core;
using MyGame.Utilities;

namespace MyGame.World
{
    class Map : Components
    {

        Texture2D texture;
        Rectangle borderTextureRectangle;
        Rectangle enemySpawnTextureRectangle;
        List<Rectangle> tilesTextureRectangle = new List<Rectangle>();

        int heightOffset = 120;
        int widthOffset = 400;

        
        public int tileHeight = 32;
        public int tileWidth = 32;
        public int numRows;
        public int numColumns;
        public int mapHeight;
        public int mapWidth;

        public List<List<int>> tileMap = new List<List<int>>();
        // 2 = Spawning point, 1 = Cactus, 0 = Open space
        List<List<int>> textureMap = new List<List<int>>();
        int numTextures = 8;

        public List <Rectangle> enemySpawnableTiles = new List<Rectangle>();
        public List <Rectangle> collisionTiles = new List<Rectangle>();

        string filePath = "World/Map.txt";

        private void CreateTileMap()
        {

            string[] linesTileMap = File.ReadAllLines(filePath);

            numRows = linesTileMap.Length;
            numColumns = linesTileMap[0].Split(',').Length;

            for(int i = 0; i < numRows; i++)
            {

                string[] line = linesTileMap[i].Split(',');

                List<int> thisRow = new List<int>();
                List<int> thisRowTexture = new List<int>();
                for(int j = 0;j < numColumns; j++)
                {   
                    thisRowTexture.Add(Randomizer.RandomInteger(numTextures));
                    thisRow.Add(int.Parse(line[j]));
                    if (line[j] == "2")
                    {
                        enemySpawnableTiles.Add(new Rectangle(j*tileWidth,i*tileHeight,tileWidth,tileHeight));
                    }
                    else if (line[j] == "1")
                    {
                        collisionTiles.Add(new Rectangle(j*tileWidth,i*tileHeight,tileWidth,tileHeight));
                    }
                }
                tileMap.Add(thisRow);
                textureMap.Add(thisRowTexture);
            }
        }

        internal override void Load(ContentManager content)
        {

            CreateTileMap();


            texture = content.Load<Texture2D>("gameSheet");
            mapHeight = numRows*tileHeight;
            mapWidth = numColumns*tileWidth;

            borderTextureRectangle = new Rectangle(9*tileWidth,0,tileWidth,tileHeight);
            enemySpawnTextureRectangle = new Rectangle(8*tileWidth,0,tileWidth,tileHeight);
            for (int temp = 0; temp<numTextures; ++temp)
            {
                tilesTextureRectangle.Add(new Rectangle(tileWidth*temp,0,tileWidth,tileHeight));
            }


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
                    spriteBatch.Draw(texture,new Rectangle(widthOffset+tileWidth*j,heightOffset+tileHeight*i,tileWidth,tileHeight),tilesTextureRectangle[textureMap[i][j]],Color.White);
                    if (tileMap[i][j] == 1)
                    {
                        spriteBatch.Draw(texture,new Rectangle(widthOffset+tileWidth*j,heightOffset+tileHeight*i,tileWidth,tileHeight),borderTextureRectangle,Color.White);
                    }
                    else if (tileMap[i][j]== 2)
                    {
                        spriteBatch.Draw(texture,new Rectangle(widthOffset+tileWidth*j,heightOffset+tileHeight*i,tileWidth,tileHeight),enemySpawnTextureRectangle,Color.White);
                    }
                }
            }
        }

    }
}
