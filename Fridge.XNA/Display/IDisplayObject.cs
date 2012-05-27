using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Fridge.XNA.Display
{
    public interface IDisplayObject 
    {
        Vector2 Position { get; set; }
        Vector2 Origin { get; set; }
        float Rotation { get; set; }
        float Scale { get; set; }
        Texture2D Texture { get; set; }
        DisplayObjectContainer Parent { get; set; }
        bool IsVisible { get; set; }
        float Width { get; set; }
        float Height { get; set; }
        DisplayStage Stage { get; }

        void SetOrigin(DisplayObjectOrigin origin);
        void SetOrigin();
        void Remove();
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
    }
}