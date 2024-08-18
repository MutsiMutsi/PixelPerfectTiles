using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PixelPerfectTiles
{
	public class Camera2D
	{
		public Vector2 Location { get; set; }
		public float Rotation { get; set; }

		private Rectangle Bounds { get; set; }

		public Matrix TransformMatrix => Matrix.CreateTranslation(new Vector3(-Location.X, -Location.Y, 0)) *
					Matrix.CreateRotationZ(Rotation) *
					Matrix.CreateTranslation(new Vector3(Bounds.Width * 0.5f, Bounds.Height * 0.5f, 0));

		public Camera2D(Viewport viewport)
		{
			Bounds = viewport.Bounds;
		}
	}
}