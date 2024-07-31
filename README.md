# LiquidShaderWobble

Wobble script for [RSkoi/LiquidShader](https://github.com/RSkoi/LiquidShader) for KK/KKS studio. Requires [Component Util](https://github.com/RSkoi/ComponentUtil).

## How-To-Use

0. Add an object / item to the studio workspace.
1. Change the object's shader to RSkoi/LiquidShader with MaterialEditor.
2. Add the `LiquidShaderWobbleEffect` with the ComponentAdder window to the selected `GameObject`, it has to be next to a `Component` suffixed by `Renderer` (e.g. `MeshRenderer`).
3. Adjust properties of `LiquidShaderWobbleEffect` to your liking. Relevant ones are `MaxWobble`, `WobbleSpeed` and `Recovery`.
