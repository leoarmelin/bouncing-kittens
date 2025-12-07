using Game.Component;
using Godot;

namespace Game.Controller;

public partial class BoardController : Node
{
	[Export]
	public BoardComponent board;

	[Export]
	public PackedScene playerScene;

	private Player selectedPlayer;

	public override void _Ready()
	{
		selectedPlayer = playerScene.Instantiate<Player>();

		board.AddPlayer(selectedPlayer);
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
		selectedPlayer.TryToMove(direction);
	}
}
