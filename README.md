NoiseBall3
----------

![gif](https://i.imgur.com/3DAVMN8.gif)

This is an updated version of [NoiseBall2] that shows how to use
`Graphics.DrawProcedural` to draw procedurally generated objects without giving
any mesh data to the render pipeline.

[NoiseBall2]: https://github.com/keijiro/NoiseBall2

Note that the `DrawProcedural` method was refurbished in Unity 2019.1 -- it's
replaced with a new implementation, and the previous implementation was moved
to a newly introduced method named `DrawProceduralNow`.

So, now the following methods are available for procedural approaches.

- `DrawProceduralNow` - Immediately executed without help of the render
  pipeline (i.e. no lighting/shadowing).
- `DrawProcedural` - Executed via an intermediate renderer that supports the
  standard lighting/shadowing features.

It can be said that `DrawProcedural` is the handiest way to draw procedural
objects with enabling the standard lighting model and the post processing
effects.
