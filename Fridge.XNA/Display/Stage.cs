using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Fridge.XNA.Display
{
    public class Stage : DisplayObjectContainer
    {
        private int StageWidth;
        private int StageHeight;
        public GraphicsDeviceManager Graphics;
        public SpriteBatch SpriteBatch;
        
        public Stage(GraphicsDeviceManager gdm, int stageWidth, int stageHeight)
        {
            this.StageWidth = stageWidth;
            this.StageHeight = stageHeight;

            this.Graphics = gdm;

            this.Graphics.PreferredBackBufferWidth = this.StageWidth;
            this.Graphics.PreferredBackBufferHeight = this.StageHeight;
        }

        public void LoadContent() 
        {
            this.SpriteBatch = new SpriteBatch(this.Graphics.GraphicsDevice);
        }

        public void Draw()
        {
            this.Graphics.GraphicsDevice.Clear(Color.White);

            this.SpriteBatch.Begin();

            base.Draw(this.SpriteBatch);

            this.SpriteBatch.End();
        }
    }
}
