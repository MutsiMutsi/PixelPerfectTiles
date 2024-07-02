using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PixelPerfectTiles
{
	public class Game1 : Game
	{
		public const int RenderScaleFactor = 3;
		public const int ResolutionX = 1280;
		public const int ResolutionY = 720;
		public const int CameraFollowSpeed = 25;

		private GraphicsDeviceManager _graphics;
		private SpriteBatch _spriteBatch;
		private TileRenderer _tileRenderer;
		private Camera2D _camera;
		private RenderTarget2D _renderTarget;
		private Player _player;

		public Game1()
		{
			_graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			IsMouseVisible = true;
		}

		protected override void Initialize()
		{
			// TODO: Add your initialization logic here
			_graphics.PreferredBackBufferWidth = ResolutionX;
			_graphics.PreferredBackBufferHeight = ResolutionY;
			_graphics.ApplyChanges();

			_tileRenderer = new TileRenderer();
			_camera = new Camera2D(new Viewport(0, 0, ResolutionX / RenderScaleFactor, ResolutionY / RenderScaleFactor));
			_player = new Player();

			base.Initialize();
		}

		protected override void LoadContent()
		{
			_spriteBatch = new SpriteBatch(GraphicsDevice);

			// TODO: use this.Content to load your game content here
			_tileRenderer.LoadContent(Content);
			_renderTarget = new RenderTarget2D(GraphicsDevice, ResolutionX / RenderScaleFactor, ResolutionY / RenderScaleFactor);
			_player.LoadContent(Content);
		}

		protected override void Update(GameTime gameTime)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
			{
				Exit();
			}

			// TODO: Add your update logic here
			float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
			_player.Update(dt);

			_camera.Location = Vector2.Lerp(_camera.Location, new Vector2(_player.Position.X, _player.Position.Y), CameraFollowSpeed * dt);

			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);

			//Anything in the world is drawn onto the render target using the camera transform matrix.
			GraphicsDevice.SetRenderTarget(_renderTarget);
			_spriteBatch.Begin(samplerState: SamplerState.PointClamp, transformMatrix: _camera.TransformMatrix);
			_tileRenderer.Render(_spriteBatch);
			_player.Render(_spriteBatch);
			_spriteBatch.End();

			//Then the render target is drawn to the screen.
			GraphicsDevice.SetRenderTarget(null);
			_spriteBatch.Begin(SpriteSortMode.Immediate, null, SamplerState.PointWrap);
			_spriteBatch.Draw(_renderTarget, new Rectangle(0, 0, ResolutionX, ResolutionY), null, Color.White);
			_spriteBatch.End();

			base.Draw(gameTime);
		}
	}
}
