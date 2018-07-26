using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace Mr_Footstep
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private Player player;

        private Room room1;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            graphics.PreferredBackBufferWidth = 600;
            graphics.PreferredBackBufferHeight = 800;
            graphics.ApplyChanges ();

            Window.Title = "Mr. Footstep";
        }

        protected override void Initialize()
        {
            base.Initialize();

            room1 = new Room (Content);
            player = new Player ();
            player.ShoesSprite = Content.Load<Texture2D> ("Sprites/Shoes/Shoes1");
            player.TopSprite = Content.Load<Texture2D> ("Sprites/Player/Player");

            player.Position = room1.GetTileWorldPosition (0, 0) + (new Vector2 (player.TopSprite.Width / 2, player.TopSprite.Height / 2) * new Vector2 (0.75f));
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            float deltaTime = (float) gameTime.ElapsedGameTime.TotalSeconds;

            player.Update (deltaTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            spriteBatch.Begin (samplerState: SamplerState.PointClamp);

            room1.Draw (spriteBatch);
            player.Draw (spriteBatch);

            spriteBatch.End ();

            base.Draw(gameTime);
        }
    }
}
