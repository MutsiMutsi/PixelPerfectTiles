using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace PixelPerfectTiles
{
	public class TileRenderer
	{
		private const int MAP_SIZE = 128;
		private const int TILE_SIZE = 32;

		private readonly int[,] _tiles;
		private Texture2D _tileMapTexture;

		public TileRenderer()
		{
			Random rng = new();

			//Instantiate some demo map data
			_tiles = new int[MAP_SIZE, MAP_SIZE];
			for (int y = 0; y < MAP_SIZE; y++)
			{
				for (int x = 0; x < MAP_SIZE; x++)
				{
					_tiles[x, y] = (32 * 9) + 1;

					int randomVal = rng.Next(0, 16);
					if (randomVal < 6)
					{
						_tiles[x, y] = (32 * 11) + randomVal;
					}
				}
			}
		}

		public void LoadContent(ContentManager cm)
		{
			_tileMapTexture = cm.Load<Texture2D>("terrain");
		}

		public void Render(SpriteBatch sb)
		{
			for (int y = 0; y < MAP_SIZE; y++)
			{
				for (int x = 0; x < MAP_SIZE; x++)
				{
					int tileId = _tiles[x, y];
					int tileMapX = tileId % 32;
					int tileMapY = tileId / 32;

					sb.Draw(_tileMapTexture,
						new Rectangle(x * TILE_SIZE, y * TILE_SIZE, TILE_SIZE, TILE_SIZE),
						new Rectangle(tileMapX * TILE_SIZE, tileMapY * TILE_SIZE, TILE_SIZE, TILE_SIZE),
						Color.White);
				}
			}
		}
	}
}
