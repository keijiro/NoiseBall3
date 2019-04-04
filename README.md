NoiseBall3
----------

![gif](https://i.imgur.com/3DAVMN8.gif)

This is an updated version of [NoiseBall2] that shows how to use
`Graphics.DrawProcedural` to draw procedurally modelled objects without giving
any mesh to the render pipeline.

[NoiseBall2]: https://github.com/keijiro/NoiseBall2

Note that the `DrawProcedural` method was refurbished in Unity 2019.1 -- it's
replaced with a new implementation, and the previous implementation was moved
to a new method `DrawProceduralNow`.

- `DrawProceduralNow` - Immediately executed without help of the render
  pipeline (i.e. no lighting/shadowing).
- `DrawProcedural` - Executed via an intermediate renderer. Lighting/shadowing
  are available.

Now `DrawProcedural` is the handiest way to draw procedural objects with
the standard lighting model.
