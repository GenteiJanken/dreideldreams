using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using DreidelDreams.Model;

namespace DreidelDreams.View
{
  public class PlayerView : View
  {
    public PlayerView(PlayerModel player, Texture2D sprite) 
    {
      this.player = player;
      this.sprite = sprite;
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
      Rectangle DestRect = new Rectangle((int)player.Position.X, (int)player.Position.Y, player.width, player.height);

      if (player.collision)
        spriteBatch.Draw(sprite, DestRect, Color.Red);
      else
        spriteBatch.Draw(sprite, DestRect, Color.Green);
    }

    private PlayerModel player;
    private Texture2D sprite;
  }
}
