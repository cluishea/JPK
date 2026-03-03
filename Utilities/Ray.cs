using System.Collections.Generic;
using System.Runtime.InteropServices;
using Microsoft.Xna.Framework;

namespace MyGame.Utilities
{
    public class RayCast
    {
        Vector2 origin;
        Vector2 desination;
        public Vector2 joiningVector;
        public Vector2 direction;

        public float distance;

        public RayCast(Vector2 _origin, Vector2 _destination)
        {
            origin = _origin;
            desination = _destination;

            joiningVector = new Vector2(desination.X-origin.X,desination.Y-origin.Y);
            direction = joiningVector;

            distance = joiningVector.Length();

            if (direction != Vector2.Zero)
            {
                direction.Normalize();
            }
        }

        public bool RayCastCheck(List<Rectangle> collisionRectangles)
        {
            int numSteps = 100;

            for(int i = 0; i<numSteps; i++)
            {
                foreach(Rectangle rectangle in collisionRectangles)
                {
                    if (rectangle.Contains(new Vector2(origin.X + joiningVector.X / numSteps * i, origin.Y + joiningVector.Y / numSteps * i))){
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
