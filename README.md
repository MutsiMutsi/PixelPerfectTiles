# PixelPerfectTiles
An example implementation for a pixel perfect tileset renderer with floating point camera movement for monogame.

# Why?
There seem to be a lot of devs struggling with tilemap and floating point issues that often lead to one of two issues:

- Pixels from neighbouring tiles bleeding
- Distortions
  
Often incorrect solutions and workaround are proposed such as using MathF.Floor on coordinate components, or casting cooridnates to integers on draw calls.
Also padding of the spritesheet is often suggested as a possible workaround.

However these solutions are patchwork workarounds that do not solve the underlying cause of the issues.
In this sample implementation I propose a simple implementation with accurate pixel perfect results without any workaround solutions.

# Controls
WASD For player movement + and - keys for zoom
