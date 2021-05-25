using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace MonoTest
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private List<Enemy> EnemyList;
        int enemyColumns = 5;
        int enemyRows = 5;
        //private Texture2D shipTexture;
        //private Vector2 shipPosition = Vector2.Zero;


        Player playerShip;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            playerShip = new Player();
            EnemyList = new List<Enemy>();
            base.Initialize();

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            //shipTexture = Content.Load<Texture2D>("Ship");
            playerShip.LoadPlayer(Content.Load<Texture2D>("Ship"));
            var tempTexture = Content.Load<Texture2D>("alien");
            for(int i = 0; i < enemyRows; i++)
            {
                for(int n = 0; n < enemyColumns; n++)
                {
                    var tempEnemy = new Enemy();
                    Color tempColor = Color.White;
                    if(i == 0)
                        tempColor = Color.Yellow;
                    else if(i == 1)
                        tempColor = Color.Green;
                    else if(i == 2)
                        tempColor = Color.Red;
                    else if(i == 3)
                        tempColor = Color.Blue;
                    else if(i == 4)
                        tempColor = Color.HotPink;

                    tempEnemy.LoadEnemy(tempTexture, new Vector2(n * 40, (i * 40) ), tempColor);
                    EnemyList.Add(tempEnemy);
                }
            }

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                //shipPosition.X -= 100.0f * (float) gameTime.ElapsedGameTime.TotalSeconds;
                playerShip.MovePlayerX(-100.0f * (float) gameTime.ElapsedGameTime.TotalSeconds);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                playerShip.MovePlayerX(100.0f * (float) gameTime.ElapsedGameTime.TotalSeconds);
                //shipPosition.X += 100.0f * (float) gameTime.ElapsedGameTime.TotalSeconds;;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                //shipPosition.Y += 100.0f * (float) gameTime.ElapsedGameTime.TotalSeconds;;
                playerShip.MovePlayerY(100.0f * (float) gameTime.ElapsedGameTime.TotalSeconds);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                //shipPosition.Y -= 100.0f * (float) gameTime.ElapsedGameTime.TotalSeconds;;
                playerShip.MovePlayerY(-100.0f * (float) gameTime.ElapsedGameTime.TotalSeconds);
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkGray);

            _spriteBatch.Begin();
            //_spriteBatch.Draw(shipTexture, shipPosition, Color.White);
            playerShip.DrawPlayer(_spriteBatch);
            foreach(var e in EnemyList)
            {
                e.Draw(_spriteBatch);
            }
            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
