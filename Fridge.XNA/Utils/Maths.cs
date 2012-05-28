using System;
using Microsoft.Xna.Framework;

namespace Fridge.XNA.Utils
{
    public class Maths
    {
        /// <summary>
        /// <returns>A float tweened between min and max</returns>
        /// <param name="speed">How fast is the rotation</param>
        /// </summary>
        public static float Pulsation(GameTime gameTime, float speed, float min, float max)
        {
            double time = gameTime.TotalGameTime.TotalSeconds * speed;

            return min + ((float)Math.Sin(time) + 1) / 2 * (max - min);
        }


        /// <summary>
        /// <returns>A Vector2 rotated as a function of time</returns>
        /// <param name="speed">How fast is the rotation</param>
        /// </summary>
        public static Vector2 Rotation(GameTime gameTime, float speed)
        {
            double time = gameTime.TotalGameTime.TotalSeconds * speed;

            float x = (float)Math.Cos(time);
            float y = (float)Math.Sin(time);

            return new Vector2(x, y);
        }

        /// <summary>
        /// Flips the Vector2 along the y axis (y scale is inverted)
        /// </summary>
        /// <param name="vec2">The vector to be flipped</param>
        public static Vector2 FlipV(Vector2 vec2)
        {
            return Vector2.Transform(vec2, Matrix.CreateScale(1, -1, 1));
        }

        /// <summary>
        /// Flips the Vector2 along the x axis (x scale is inverted)
        /// </summary>
        /// <param name="vec2">The vector to be flipped</param>
        public static Vector2 FlipH(Vector2 vec2)
        {
            return Vector2.Transform(vec2, Matrix.CreateScale(-1, 1, 1));
        }
    }
}
