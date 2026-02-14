using MyGame.Core;
using MyGame.Managers;

namespace MyGame.Scenes{
    internal abstract class Scene:Components{
        protected GameSceneManager gsm;

        public Scene(GameSceneManager gsm)
        {
        this.gsm = gsm;
        }
    }

}
