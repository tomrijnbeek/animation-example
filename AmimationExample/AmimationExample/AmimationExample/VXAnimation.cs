using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AmimationExample
{
    class VXAnimation : Animation
    {
        public enum Direction
        {
            DOWN = 0,
            LEFT = 1,
            RIGHT = 2,
            UP = 3
        }

        public VXAnimation(Texture2D texture)
            : base(texture, 3, 4)
        {
            // Adjust height to account for the four directions.
            this.size.Y /= 4;
        }

        public void SetDirection(Direction d)
        {
            this.yOffset = (int)d;
        }
    }
}
