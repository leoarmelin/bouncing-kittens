using Godot;

namespace Game.Component;

public partial class BoardComponent : Node2D
{
	[Export]
	PackedScene playerScene;

	public override void _Ready()
	{
		var player = playerScene.Instantiate();
		AddChild(player);
	}
}
