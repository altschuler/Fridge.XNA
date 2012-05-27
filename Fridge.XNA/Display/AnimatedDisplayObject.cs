using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Fridge.XNA.Display
{
    public class AnimatedDisplayObject : DisplayObjectContainer
    {
        private int CurrentFrame;
        private int TotalFrames;
        private int FrameTime;
        private Vector2 FrameSize;
        private float ElapsedTimeSinceFrameChange;
        private List<Rectangle> SourceRects;

        public AnimatedDisplayObject(int totalFrames, int frameTime, Vector2 frameSize)
        {
            this.TotalFrames = totalFrames;
            this.FrameTime = frameTime;
            this.FrameSize = frameSize;
            this.CurrentFrame = 0;
            this.ElapsedTimeSinceFrameChange = 0;
            this.SourceRects = new List<Rectangle>(this.TotalFrames);

            for (int i = 0; i < this.TotalFrames; i++)
            {
                this.SourceRects.Add(new Rectangle(i * (int)this.FrameSize.X, 0, (int)this.FrameSize.X, (int)this.FrameSize.Y));
            }
        }

        public override void Update(GameTime gameTime)
        {
            this.ElapsedTimeSinceFrameChange += gameTime.ElapsedGameTime.Milliseconds;

            if (this.ElapsedTimeSinceFrameChange > this.FrameTime)
            {
                if (++this.CurrentFrame > this.TotalFrames - 1)
                    this.CurrentFrame = 0;

                this.ElapsedTimeSinceFrameChange -= this.FrameTime;
            }

            base.Update(gameTime);;
        }

        public override float Width
        {
            get
            {
                return this.FrameSize.X;
            }
            set
            {
                base.Width = value;
            }
        }


        public override float Height
        {
            get
            {
                return this.FrameSize.Y;
            }
            set
            {
                base.Height = value;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch, this.SourceRects[this.CurrentFrame]);
        }
    }
}
