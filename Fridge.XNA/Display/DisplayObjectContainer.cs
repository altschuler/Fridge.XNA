using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Fridge.XNA.Display
{
    public class DisplayObjectContainer : DisplayObject
    {
        private List<IDisplayObject> Children;

        public DisplayObjectContainer()
        {
            this.Children = new List<IDisplayObject>();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            this.Draw(spriteBatch, null);
        }
        
        public override void Draw(SpriteBatch spriteBatch, Rectangle? sourceRect)
        {
            base.Draw(spriteBatch, sourceRect);

            foreach (IDisplayObject displayObject in this.Children)
                displayObject.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            foreach (IDisplayObject displayObject in this.Children.ToList())
                displayObject.Update(gameTime);

            base.Update(gameTime);
        }

        public bool Contains(IDisplayObject displayObject)
        {
            return this.Contains(displayObject, true);
        }

        public bool Contains(IDisplayObject displayObject, bool deep)
        {
            bool any = this.Children.Any(child => child is DisplayObjectContainer && (child as DisplayObjectContainer).Contains(displayObject, true));
            return deep ? any || this.Children.Contains(displayObject) : this.Children.Contains(displayObject);
        }

        public void AddChild(IDisplayObject displayObject)
        {
            displayObject.Parent = this;
            this.Children.Add(displayObject);
        }

        public void RemoveChild(IDisplayObject displayObject)
        {
            displayObject.Parent = null;
            this.Children.Remove(displayObject);
        }

        public void RemoveChildAt(int index)
        {
            this.Children[index].Parent = null;
            this.Children.RemoveAt(index);
        }

        public void AddChildAt(IDisplayObject displayObject, int index)
        {
            displayObject.Parent = this;
            this.Children.Insert(index, displayObject);
        }

        public int NumberOfChildren()
        {
            return this.Children.Count;
        }
    }
}
