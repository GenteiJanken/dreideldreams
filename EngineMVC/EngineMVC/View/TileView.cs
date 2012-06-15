using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using DreidelDreams.Model;

namespace DreidelDreams.View
{
  public class TileView : View
  {
    public TileView(List<TileModel> tiles, Texture2D sprite)
    {
      this.tiles = tiles;
      this.sprite = sprite;
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
      foreach (TileModel item in tiles)
        spriteBatch.Draw(sprite, new Rectangle((int)item.Position.X, (int)item.Position.Y, item.width, item.height), Color.Red);
    }

    private List<TileModel> tiles;
    private Texture2D sprite;
  }
}
