using System;
using Godot;

namespace Game.Component;

public partial class Trampoline : Node2D
{
	public enum DiagonalType
	{
		TopLeftToBottomRight, // "\"
		TopRightToBottomLeft  // "/"
	}

	[Signal]
	public delegate void OnPlayerEnterEventHandler(Vector2 newVelocity);

	[Export]
	public DiagonalType diagonal;
	[Export]
	public Sprite2D sprite;
	[Export]
	public Area2D topArea;
	[Export]
	public Area2D rightArea;
	[Export]
	public Area2D bottomArea;
	[Export]
	public Area2D leftArea;

	private int areasWherePlayerIsAbove = 0;

	public override void _Ready()
	{
		if (diagonal == DiagonalType.TopLeftToBottomRight)
		{
			sprite.Rotate((float)(Math.PI / 2));
		}

		topArea.BodyEntered += OnBodyEntered;
		rightArea.BodyEntered += OnBodyEntered;
		bottomArea.BodyEntered += OnBodyEntered;
		leftArea.BodyEntered += OnBodyEntered;

		topArea.BodyExited += OnBodyExited;
		rightArea.BodyExited += OnBodyExited;
		bottomArea.BodyExited += OnBodyExited;
		leftArea.BodyExited += OnBodyExited;
	}

	private Vector2 ReflectA(Vector2 v) => new Vector2(v.Y, v.X);

	private Vector2 ReflectB(Vector2 v) => new Vector2(-v.Y, -v.X);

	private void OnBodyEntered(Node body)
	{
		if (body is not Player player) return;

		areasWherePlayerIsAbove += 1;

		if (areasWherePlayerIsAbove < 4) return;

		var newVelocity = diagonal switch
		{
			DiagonalType.TopLeftToBottomRight => ReflectA(player.Velocity),
			DiagonalType.TopRightToBottomLeft => ReflectB(player.Velocity),
			_ => player.Velocity
		};

		player.ForceRedirect(newVelocity);
	}

	private void OnBodyExited(Node body)
	{
		if (body is not Player || areasWherePlayerIsAbove == 0) return;

		areasWherePlayerIsAbove -= 1;
	}
}
