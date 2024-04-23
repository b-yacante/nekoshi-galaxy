using Godot;
using System;

public partial class Nekoshi : CharacterBody3D
{
    /*
    SWIPE 
    */
    private float length = 100;
    private Vector2 swipeStart = Vector2.Zero;
    private bool isSwiping = false;
    /*
    MOVEMENT
    */
    [Export]
    public float Speed { get; set; } = 2f;
    private int _lanePosition = 0; // -1: left -- 0: middle -- 1: right
    private float _laneDistance = 0.65f;
    private Vector3 _targetVelocity;

    Vector2I screenSize;

    public override void _Ready()
    {

        // targetPosition = GlobalTransform.Origin;
        // screenSize = DisplayServer.WindowGetSize();
        // _laneDistance = screenSize.X * 25f / 100;
    }

    public override void _PhysicsProcess(double delta)
    {
        Vector3 _targetPosition = new(_lanePosition * _laneDistance, GlobalPosition.Y, GlobalPosition.Z);

        Vector3 newPosition = GlobalTransform.Origin.Lerp(_targetPosition, (float)delta * Speed);
        GlobalTransform = new Transform3D(GlobalTransform.Basis, newPosition);

    }

    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventMouseButton eventMouseButton)
        {
            if (eventMouseButton.IsPressed())
            {
                swipeStart = eventMouseButton.Position;
            }
            else
            {
                CalculateSwipe(eventMouseButton.Position);
            }
        }

    }

    public void CalculateSwipe(Vector2 swipeEnd)
    {
        if (swipeStart == Vector2.Zero) return;
        var swipe = swipeEnd - swipeStart;
        if (Mathf.Abs(swipe.X) > length)
        {
            if (swipe.X > 0) MoveRight();
            else MoveLeft();
        }
    }

    private void MoveLeft()
    {
        _lanePosition--;
        if (_lanePosition == -2) _lanePosition = -1;
    }

    private void MoveRight()
    {
        _lanePosition++;
        if (_lanePosition == 2) _lanePosition = 1;
    }
}
