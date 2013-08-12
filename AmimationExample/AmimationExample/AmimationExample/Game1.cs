using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AmimationExample
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private Texture2D voltSprite, vxSprite;

        private Animation volt;
        private VXAnimation actor;

        public Game1()
        {
            this.graphics = new GraphicsDeviceManager(this);
            this.Content.RootDirectory = "Content";
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            this.spriteBatch = new SpriteBatch(GraphicsDevice);

            // Load textures
            this.voltSprite = this.Content.Load<Texture2D>("volt-horizontal");
            this.vxSprite = this.Content.Load<Texture2D>("actor");

            // Load animations
            this.volt = new Animation(voltSprite, 10);
            this.actor = new VXAnimation(vxSprite);
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            KeyboardState kbState = Keyboard.GetState();

            // Allows the game to exit
            if (kbState.IsKeyDown(Keys.Escape))
                this.Exit();

            // Change direction of the actor sprite
            if (kbState.IsKeyDown(Keys.Up))
                this.actor.SetDirection(VXAnimation.Direction.UP);
            if (kbState.IsKeyDown(Keys.Down))
                this.actor.SetDirection(VXAnimation.Direction.DOWN);
            if (kbState.IsKeyDown(Keys.Left))
                this.actor.SetDirection(VXAnimation.Direction.LEFT);
            if (kbState.IsKeyDown(Keys.Right))
                this.actor.SetDirection(VXAnimation.Direction.RIGHT);

            this.volt.Update(gameTime);
            this.actor.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            this.GraphicsDevice.Clear(Color.Black);

            this.spriteBatch.Begin();

            this.volt.Draw(this.spriteBatch, Vector2.Zero);
            this.actor.Draw(this.spriteBatch, new Vector2(480, 200));

            this.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
