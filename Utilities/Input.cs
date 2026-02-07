using System.ComponentModel.Design;
using Microsoft.Xna.Framework.Input;

/*
Handles the input of the game
*/

internal static class Input{
    
    static KeyboardState keyboardState ;
    static KeyboardState previousKeyboardState;

    static MouseState mouseState;
    static MouseState previousMouseState;

    public static void Update()
    {
        previousKeyboardState = keyboardState;
        keyboardState = Keyboard.GetState();

        previousMouseState = mouseState;
        mouseState = Mouse.GetState();

    }

}
