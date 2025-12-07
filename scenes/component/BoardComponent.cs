using Godot;

namespace Game.Component;

public partial class BoardComponent : Node2D
{
	[Export]
	PackedScene trampolineScene;

	private readonly record struct TrampolineCell(
		int X,
		int Y,
		Trampoline.DiagonalType DiagonalType
	);

	private TrampolineCell[] trampolines = [
		new TrampolineCell(4, 1, Trampoline.DiagonalType.TopRightToBottomLeft),
		new TrampolineCell(14, 2, Trampoline.DiagonalType.TopRightToBottomLeft),
		new TrampolineCell(9, 3, Trampoline.DiagonalType.TopRightToBottomLeft),
		new TrampolineCell(5, 7, Trampoline.DiagonalType.TopLeftToBottomRight),
		new TrampolineCell(4, 8, Trampoline.DiagonalType.TopRightToBottomLeft),
		new TrampolineCell(9, 12, Trampoline.DiagonalType.TopLeftToBottomRight),
		new TrampolineCell(1, 13, Trampoline.DiagonalType.TopLeftToBottomRight),
		new TrampolineCell(11, 14, Trampoline.DiagonalType.TopLeftToBottomRight),
	];

	public override void _Ready()
	{
		foreach (var item in trampolines)
		{
			var trampoline = trampolineScene.Instantiate<Trampoline>();
			trampoline.GlobalPosition = new Vector2(32 * item.X, 32 * item.Y);
			trampoline.diagonal = item.DiagonalType;
			AddChild(trampoline);
		}
	}

	public void AddPlayer(Player player)
	{
		AddChild(player);
	}
}
