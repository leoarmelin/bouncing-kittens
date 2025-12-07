using Godot;

public partial class Player : CharacterBody2D
{
  [Signal]
  public delegate void OnStopEventHandler();

  private AnimatedSprite2D sprite;

  private bool isInMovement = false;

  private static readonly Vector2 GRID = new Vector2(32, 32);

  public override void _Ready()
  {
    sprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
    sprite.Play("default");
  }

  public override void _PhysicsProcess(double delta)
  {
    MoveAndSlide();

    if (Velocity == Vector2.Zero)
    {
      if (isInMovement)
      {
        GD.Print(Position);
        Position = Position.Snapped(GRID);
        GD.Print(Position);

        EmitSignalOnStop();
        isInMovement = false;
      }
    }
  }

  public void TryToMove(Vector2I direction)
  {
    if (isInMovement) return;
    isInMovement = true;
    Velocity = direction * 150;
  }
}
