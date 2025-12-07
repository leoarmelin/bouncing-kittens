using Godot;

namespace Game.Component;

public partial class BoardComponent : Node2D
{
	public void AddPlayer(Player player)
	{
		AddChild(player);
	}
}
