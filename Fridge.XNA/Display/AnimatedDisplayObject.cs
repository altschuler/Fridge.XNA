using System;
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

        private bool IsPlaying;
        private bool Oneshot;
        private bool OneshotTriggered;

        public AnimatedDisplayObject(int totalFrames, int frameTime, Vector2 frameSize)
        {
            this.TotalFrames = totalFrames;
            this.FrameTime = frameTime;
            this.FrameSize = frameSize;
            this.CurrentFrame = 0;
            this.ElapsedTimeSinceFrameChange = 0;
            this.SourceRects = new List<Rectangle>(this.TotalFrames);
            this.OneshotTriggered = false;

            this.IsPlaying = true;

            for (int i = 0; i < this.TotalFrames; i++)
            {
                this.SourceRects.Add(new Rectangle(i * (int)this.FrameSize.X, 0, (int)this.FrameSize.X, (int)this.FrameSize.Y));
            }
        }

        
        public AnimatedDisplayObject(int totalFrames, int frameTime, Vector2 frameSize, bool oneshot) : this(totalFrames, frameTime, frameSize)
        {
            this.Oneshot = true;
        }

        public void GoToFrame(int frame)
        {
            this.CurrentFrame = (int)MathHelper.Max(frame, this.TotalFrames);
        }

        public void GoToAndPlay(int frame)
        {
            this.CurrentFrame = (int)MathHelper.Max(frame, this.TotalFrames);
        }

        public override void Update(GameTime gameTime)
        {
            if (this.OneshotTriggered)
            {
                this.Remove();
                this.Dispose();
            }

            if (this.IsPlaying)
            {
                this.ElapsedTimeSinceFrameChange += gameTime.ElapsedGameTime.Milliseconds;

                if (this.ElapsedTimeSinceFrameChange > this.FrameTime)
                {
                    var framesElapsed = (int)Math.Floor(this.ElapsedTimeSinceFrameChange/this.FrameTime);
                    this.CurrentFrame += framesElapsed;
                    if (this.CurrentFrame > this.TotalFrames - 1)
                    {
                        if (this.Oneshot)
                            this.OneshotTriggered = true;

                        this.CurrentFrame = this.CurrentFrame - this.TotalFrames;
                    }

                    this.ElapsedTimeSinceFrameChange -= this.FrameTime;
                }
            }
            base.Update(gameTime);
        }

        private void Dispose()
        {
            //TODO implement
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
