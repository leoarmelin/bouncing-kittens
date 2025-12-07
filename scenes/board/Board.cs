using Godot;

namespace Game.Board;

public partial class Board : Node2D
{
	[Export]
	PackedScene playerScene;

	public override void _Ready()
	{
		var player = playerScene.Instantiate();
		AddChild(player);
	}
}
