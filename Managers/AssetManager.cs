using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

static class AssetManager
{
    public static ContentManager content;

    public static void Initialize(ContentManager _content)
        {
            content = _content;
        }

        public static Texture2D LoadTexture(string name)
        {
            return content.Load<Texture2D>(name);
        }
}
