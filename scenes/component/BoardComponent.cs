using Godot;

namespace Game.Component;

public partial class BoardComponent : Node2D
{
	public void AddPlayer(Player player)
	{
		player.GlobalPosition += new Vector2(16, 16);
		AddChild(player);
	}
}
