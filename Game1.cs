using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;

namespace Mr_Footstep
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private Player player;

        public static Room CurrentRoom;

        private int roomIndex = 0;

        private SpriteFont font;

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

        public void NextRoom ()
        {
            List<Type> allRoomTypes = Assembly.GetEntryAssembly ().GetTypes ().Where (t => t.Name.Contains ("Room")).ToList ();
            allRoomTypes.RemoveAll (t => t.Name == "Room");

            CurrentRoom = null;
            CurrentRoom = (Room) Activator.CreateInstance (allRoomTypes [roomIndex], Content);
            roomIndex++;
            player.SetPositionToTile (CurrentRoom.GetTileAtWorldPosition (new Vector2 (0, 0)));
        }

        protected override void Initialize()
        {
            base.Initialize();

            player = new Player ();
            player.OnFinishLevel += NextRoom;
            player.ShoesSprite = Content.Load<Texture2D> ("Sprites/Shoes/Shoes1");
            player.TopSprite = Content.Load<Texture2D> ("Sprites/Player/Player");

            NextRoom ();

            font = Content.Load<SpriteFont> ("Fonts/Sunflower");
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

            CurrentRoom.Update (deltaTime);
            player.Update (deltaTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            spriteBatch.Begin (samplerState: SamplerState.PointClamp);

            CurrentRoom.Draw (spriteBatch);
            player.Draw (spriteBatch);

            spriteBatch.DrawString (font, "Shoes:", new Vector2 (10, 610), Color.Black);

            spriteBatch.End ();

            base.Draw(gameTime);
        }
    }
}
