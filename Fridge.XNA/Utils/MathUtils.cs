using System;
using Microsoft.Xna.Framework;

namespace Fridge.XNA.Utils
{
    public class MathUtils
    {
        /// <summary>
        /// <returns>A float tweened between min and max</returns>
        /// <param name="speed">How fast is the rotation</param>
        /// </summary>
        static float Pulsation(GameTime gameTime, float speed, float min, float max)
        {
            double time = gameTime.TotalGameTime.TotalSeconds * speed;

            return min + ((float)Math.Sin(time) + 1) / 2 * (max - min);
        }


        /// <summary>
        /// <returns>A Vector2 rotated as a function of time</returns>
        /// <param name="speed">How fast is the rotation</param>
        /// </summary>
        static Vector2 Rotation(GameTime gameTime, float speed)
        {
            double time = gameTime.TotalGameTime.TotalSeconds * speed;

            float x = (float)Math.Cos(time);
            float y = (float)Math.Sin(time);

            return new Vector2(x, y);
        }
    }
}
