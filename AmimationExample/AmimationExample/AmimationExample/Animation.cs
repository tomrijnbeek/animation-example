using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AmimationExample
{
    class Animation
    {
        protected Texture2D texture;
        protected int stepCount;

        protected Vector2 size;

        // Keep track of the current step.
        protected int xOffset = 0;
        protected int yOffset = 0;

        // A counter to slow down the animation.
        protected int counter;
        private int fpstep;

        public Animation(Texture2D texture, int stepCount, int framesPerStep = 3)
        {
            this.texture = texture;
            this.stepCount = stepCount;
            this.size = new Vector2(texture.Width / stepCount, texture.Height);
            this.fpstep = framesPerStep;
        }

        public virtual void Update(GameTime gameTime)
        {
            // Update counter.
            this.counter = (this.counter + 1) % fpstep;

            // Only update step once every "fpstep" frames.
            if (this.counter == 0)
                this.xOffset = (this.xOffset + 1) % this.stepCount;
        }

        public virtual void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            spriteBatch.Draw(this.texture, position, new Rectangle(this.xOffset * (int)this.size.X, this.yOffset * (int)this.size.Y, (int)this.size.X, (int)this.size.Y), Color.White);
        }
    }
}
