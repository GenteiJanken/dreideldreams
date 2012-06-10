using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using EngineMVC.Model;

namespace EngineMVC.View
{
  public class BallView : View
  {
    public BallView(BallModel ball, Texture2D sprite) 
    {
      this.ball = ball;
      this.sprite = sprite;
    }

    public override void Draw(SpriteBatch spriteBatch) {
      spriteBatch.Draw(sprite, new Rectangle((int)ball.Position.X, (int)ball.Position.Y, ball.width, ball.height), Color.Purple);
    }

    Texture2D sprite;
    BallModel ball;
  }
}
