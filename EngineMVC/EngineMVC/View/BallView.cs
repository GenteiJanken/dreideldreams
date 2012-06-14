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

      ballTrails = new List<Vector2>();
      maxTrails = 10;
      lastTrailTime = TimeSpan.Zero;
      trailRecordRate = TimeSpan.FromMilliseconds(200f);
    }

    public override void Draw(SpriteBatch spriteBatch) {
      if (World.GameTime - lastTrailTime > trailRecordRate) 
      {
        lastTrailTime = World.GameTime;
        ballTrails.Add(ball.Position);

        if (ballTrails.Count > maxTrails)
          ballTrails.RemoveAt(0);
      }

      for (int i = 0; i < ballTrails.Count; i++)
      {
        Color c = new Color(1f, 0, 0);
        spriteBatch.Draw(sprite, new Rectangle((int)ballTrails[i].X, (int)ballTrails[i].Y, ball.width, ball.height), c);
      }

      spriteBatch.Draw(sprite, new Rectangle((int)ball.Position.X, (int)ball.Position.Y, ball.width, ball.height), Color.Purple);
    }

    private Texture2D sprite;
    private BallModel ball;
    private List<Vector2> ballTrails;
    private int maxTrails;
    private TimeSpan lastTrailTime;
    private TimeSpan trailRecordRate;
  }
}
