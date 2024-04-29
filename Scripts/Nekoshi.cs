using Godot;
using System;

public partial class Nekoshi : CharacterBody3D
{
	[Signal]
	public delegate void LanePositionEventHandler(Vector2I lanePos);

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
	private Vector2I _LanePos = new Vector2I(0, 0); // -1: left/down -- 0: middle -- 1: right/up
	// private int _lanePosition = 0; // -1: left -- 0: middle -- 1: right
	private const float _laneDistance = 0.65f;
	private Vector3 _targetVelocity;

	Vector2I screenSize;

	public override void _Ready()
	{

	}

	public override void _PhysicsProcess(double delta)
	{
		Vector3 _targetPosition = new(_LanePos.X * _laneDistance, _LanePos.Y * _laneDistance, GlobalPosition.Z);

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
				EmitSignal(SignalName.LanePosition, _LanePos);
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
		else if (Mathf.Abs(swipe.Y) > length)
		{
			if (swipe.Y < 0) MoveUp();
			else MoveDown();
		}
	}

	private void MoveUp()
	{
		_LanePos.Y++;
		if (_LanePos.Y == 2) _LanePos.Y = 1;
	}
	private void MoveDown()
	{
		_LanePos.Y--;
		if (_LanePos.Y == -2) _LanePos.Y = -1;
	}

	private void MoveLeft()
	{
		_LanePos.X--;
		if (_LanePos.X == -2) _LanePos.X = -1;
	}

	private void MoveRight()
	{
		_LanePos.X++;
		if (_LanePos.X == 2) _LanePos.X = 1;
	}
}
