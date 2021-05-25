using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoTest
{
    class Player
    {
        Vector2 playerPos = Vector2.Zero;
        Texture2D playerSprite;

        public void LoadPlayer(Texture2D playerSprite)
        {
            this.playerSprite = playerSprite;
        }

        public void MovePlayerX(float value)
        {            
            playerPos.X += value;
        }
        public void MovePlayerY(float value)
        {
            playerPos.Y += value;
        }
        public void DrawPlayer(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(playerSprite, playerPos, Color.White);
        }
    }
}