using System;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Fridge.XNA.IO
{
    public static class Inputs
    {
        public static Vector2 RightThumb(PlayerIndex player)
        {
            return GamePad.GetState(player).ThumbSticks.Right;
        }

        public static Vector2 LeftThumb(PlayerIndex player)
        {
            return GamePad.GetState(player).ThumbSticks.Left;
        }

        public static bool ButtonWasPressed(PlayerIndex player, Keys key)
        {
            return false;
        }

        public static bool ButtonIsDown(PlayerIndex player, Buttons button)
        {
            var state = GamePad.GetState(player);
            switch (button)
            {
                case Buttons.A:
                    return state.Buttons.A == ButtonState.Pressed;
                case Buttons.B:
                    return state.Buttons.B == ButtonState.Pressed;
                case Buttons.X:
                    return state.Buttons.X == ButtonState.Pressed;
                case Buttons.Y:
                    return state.Buttons.Y == ButtonState.Pressed;
                case Buttons.Back:
                    return state.Buttons.Back == ButtonState.Pressed;
                case Buttons.BigButton:
                    return state.Buttons.BigButton == ButtonState.Pressed;
                case Buttons.Start:
                    return state.Buttons.Start == ButtonState.Pressed;
                default:
                    throw new NotImplementedException("Implement button states nicely");
            }
        }
    }
}
