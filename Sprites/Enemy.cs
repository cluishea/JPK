namespace MyGame.Sprites
{
    class Enemy : Sprite
    {
        protected int health;
        public bool isAlive;

        public int pointsOnDefeat;
        
        public void DropHealth(int amount)
        {
            health-=amount;
        }
    }
}
