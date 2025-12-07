using Game.Component;
using Godot;

namespace Game.Controller;

public partial class BoardController : Node
{
	[Export]
	public BoardComponent board;

	public override void _Ready()
	{
	}

	public override void _Input(InputEvent evt)
	{
		if (evt.IsActionPressed("move_up"))
			HandleMove(Vector2I.Up);

		if (evt.IsActionPressed("move_down"))
			HandleMove(Vector2I.Down);

		if (evt.IsActionPressed("move_left"))
			HandleMove(Vector2I.Left);

		if (evt.IsActionPressed("move_right"))
			HandleMove(Vector2I.Right);
	}

	private void HandleMove(Vector2I direction)
	{
		GD.Print(direction);
	}
}
