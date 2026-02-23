using System.ComponentModel.Design;
using Microsoft.Xna.Framework.Input;

/*
Handles the input of the game
*/

namespace MyGame.Managers{
    internal static class InputManager{
        
        static public KeyboardState keyboardState ;
        static public KeyboardState previousKeyboardState;

        static public MouseState mouseState;
        static public MouseState previousMouseState;

        public static void Update()
        {
            previousKeyboardState = keyboardState;
            keyboardState = Keyboard.GetState();

            previousMouseState = mouseState;
            mouseState = Mouse.GetState();

        }

        public static bool IsKeyPressed(Keys k)
        {
            if (keyboardState.IsKeyDown(k) && !previousKeyboardState.IsKeyDown(k))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }

}
