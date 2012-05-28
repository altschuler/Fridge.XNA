using System.Diagnostics;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Fridge.XNA.Display
{
    public enum DisplayObjectOrigin
    {
        TL,
        TC,
        TR,
        CL,
        CC,
        CR,
        BL,
        BC,
        BR
    }

    public class DisplayObject : IDisplayObject
    {
        public Vector2 Origin { get; set; }
        public float Rotation { get; set; }
        public float Scale { get; set; }
        public Color Color { get; set; }

        public DisplayObjectContainer Parent { get; set; }

        protected Vector2 PositionDelta { get; private set; }

        private Vector2 _Position;
        private bool _IsVisible;
        private Texture2D _Texture;

        public DisplayObject()
        {
            this.Position = Vector2.Zero;
            this.Origin = Vector2.Zero;
            this.Scale = 1f;
            this.Color = Color.White;
            this.IsVisible = true;
        }

        public Texture2D Texture 
        { 
            get { return this._Texture; }
            set 
            { 
                this._Texture = value;
                this.SetOrigin();
            } 
        }

        public Vector2 Position
        {
            get { return this._Position; }
            set
            {
                this.PositionDelta = value - this._Position;
                this._Position = value;
            }
        }

        public virtual void Update(GameTime gameTime)
        {
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            this.Draw(spriteBatch, null);
        }

        public virtual void Draw(SpriteBatch spriteBatch, Rectangle? sourceRect)
        {
            if (!this.IsVisible)
                return;

            var finalPosition = this.Position;
            var finalScale = this.Scale;
            var finalRotation = this.Rotation;

            var p = this.Parent;
            while (p != null)
            {
                finalPosition *= p.Scale;
                finalPosition = Vector2.Transform(finalPosition, Matrix.CreateRotationZ(p.Rotation));
                finalPosition += p.Position;
                finalScale *= p.Scale;
                finalRotation += p.Rotation;

                p = p.Parent;
            }

            spriteBatch.Draw(this.Texture, finalPosition, sourceRect, this.Color, finalRotation, this.Origin, finalScale,
                             SpriteEffects.None, 0f);
        }

        public void SetOrigin()
        {
            SetOrigin(DisplayObjectOrigin.CC);
        }

        public Stage Stage
        {
            get
            {
                var parent = this.Parent;

                while (!(parent is Stage) && parent != null)
                {
                    parent = parent.Parent;
                }

                return parent as Stage;
            }
        }

        public void SetOrigin(DisplayObjectOrigin origin)
        {
            switch (origin)
            {
                case DisplayObjectOrigin.TL:
                    this.Origin = new Vector2(0, 0);
                    break;

                case DisplayObjectOrigin.CC:
                    this.Origin = new Vector2(this.Width / 2f, this.Height/2f);
                    break;

                case DisplayObjectOrigin.BC:
                    this.Origin = new Vector2(this.Width / 2f, this.Height);
                    break;
            }
        }

        /// <summary>
        /// Remove the DisplayObject from its Parent DisplayObjectContainer
        /// </summary>
        public void Remove()
        {
            Debug.Assert(this.Parent != null, "Child has no Parent, cannot remove");

            this.Parent.RemoveChild(this);
        }

        public bool IsVisible
        {
            get { return this.Texture != null && this._IsVisible; }
            set { this._IsVisible = value; }
        }

        public virtual float Width
        {
            get { return this.Texture.Width; }
            set { throw new System.NotImplementedException(); }
        }

        public virtual float Height
        {
            get { return this.Texture.Height; }
            set { throw new System.NotImplementedException(); }
        }
    }
}