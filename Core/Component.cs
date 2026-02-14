using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

/* 
Components class is an abstract class for creating classes.
Inherit this class, then Ctrl + , to implement the abstract methods of this class.
*/


namespace MyGame.Core
{
    
    internal abstract class Components
    {
        
        internal abstract void Load(ContentManager content);
        internal abstract void Update(GameTime gameTime);
        internal abstract void Draw(SpriteBatch spriteBatch);
        
    }

}
