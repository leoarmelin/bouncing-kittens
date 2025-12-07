using Godot;

public partial class Player : CharacterBody2D
{
  [Signal]
  public delegate void OnStopEventHandler();

	private AnimatedSprite2D sprite;

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
      EmitSignalOnStop();
      SetPhysicsProcess(false);
      var currentPosition = GlobalPosition / 32;
      GlobalPosition = currentPosition * 32;
    }
  }
}
