using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoTest
{
    class Enemy
    {
        Texture2D enemySprite;
        Vector2 enemyPosition;
        Color enemyColor;

        public void LoadEnemy(Texture2D texture, Vector2 position, Color color)
        {
            enemySprite = texture;
            enemyPosition = position;
            enemyColor = color;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(enemySprite, enemyPosition, enemyColor);
        }

    }
}