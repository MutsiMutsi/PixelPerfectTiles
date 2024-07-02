using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PixelPerfectTiles
{
	public class Player
	{
		public Vector2 Position { get; set; }
		public Vector2 Velocity { get; set; }

		private Texture2D _texture;
		private readonly float _speed = 25f;

		public void LoadContent(ContentManager cm)
		{
			_texture = cm.Load<Texture2D>("player");
		}

		public void Update(float dt)
		{
			KeyboardState ks = Keyboard.GetState();

			Vector2 inputDir = Vector2.Zero;
			if (ks.IsKeyDown(Keys.W))
			{
				inputDir += new Vector2(0, -1);
			}
			if (ks.IsKeyDown(Keys.S))
			{
				inputDir += new Vector2(0, 1);
			}
			if (ks.IsKeyDown(Keys.A))
			{
				inputDir += new Vector2(-1, 0);

			}
			if (ks.IsKeyDown(Keys.D))
			{
				inputDir += new Vector2(1, 0);
			}

			//Apply input to velocity;
			if (inputDir != Vector2.Zero)
			{
				Vector2 impulse = Vector2.Normalize(inputDir) * _speed;
				Velocity += impulse;
			}

			Position += Velocity * dt;

			if (Velocity != Vector2.Zero)
			{
				//Add some drag to velocity
				Velocity *= .85f;
			}
		}

		public void Render(SpriteBatch sb)
		{
			sb.Draw(_texture, Position, null, Color.White, 0f, new Vector2(16, 16), 1f, SpriteEffects.None, 0f);
		}
	}
}
