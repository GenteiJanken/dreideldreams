using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using EngineMVC.Model;

namespace EngineMVC.View
{
  public class PlayerViewText : View
  {
    public PlayerViewText(PlayerModel player, SpriteFont font)
    {
      this.player = player;
      this.font = font;
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
      string output = "w: " + player.width + ", h: " + player.height;
      output += "\n" + "x: " + player.Position.X + ", y: " + player.Position.Y;
      output += "\n" + "vx: " + player.velocity.X + ", vy: " + player.velocity.Y;
      output += "\n" + "speed: " + player.speed + "px/s";
      spriteBatch.DrawString(font, output, new Vector2(10, 10), Color.White);
    }

    private PlayerModel player;
    private SpriteFont font;
  }
}
