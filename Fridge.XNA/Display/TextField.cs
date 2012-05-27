using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Fridge.XNA.Display
{
    public class TextField : DisplayObject
    {
        public string Text { get; set; }
        public SpriteFont Font { get; set; }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Debug.Assert(this.Font != null, "A font has not been set on the TextField");

            if (this.Font == null)
                return;
            
            spriteBatch.DrawString(this.Font, this.Text, this.Position, Color.White, this.Rotation, this.Origin, this.Scale, SpriteEffects.None, 0f);    
        }
    }
}
