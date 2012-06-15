using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using DreidelDreams.Model;

namespace DreidelDreams.View
{
  public class PlayerViewGrid : View
  {
    public PlayerViewGrid(PlayerModel player, Texture2D sprite) 
    {
      this.player = player;
      this.sprite = sprite;
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
      int tileSize = 64+1;
      Rectangle DestRect = new Rectangle(
        (int)((player.Position.X + player.width/2) / tileSize) * tileSize,
        (int)((player.Position.Y + player.height/2) / tileSize) * tileSize,
        tileSize - 1, tileSize - 1);

      spriteBatch.Draw(sprite, DestRect, Color.LawnGreen);
    }

    private PlayerModel player;
    private Texture2D sprite;
  }
}
