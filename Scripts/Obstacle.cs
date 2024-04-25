using Godot;
using System;

public partial class Obstacle : RigidBody3D
{
	private RigidBody3D _obstacle;
	[Export] private float obstacleSpeed = 1f;
	private const float _laneDistance = 0.65f;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_obstacle = GetNode<Obstacle>("Obstacle");
		var randomNumber = new RandomNumberGenerator();
		int randomLaneX = randomNumber.RandiRange(-1, 1);
		int randomLaneY = randomNumber.RandiRange(-1, 1);

		Vector3 randomPosition = new(randomLaneX * _laneDistance, randomLaneY * _laneDistance, GlobalPosition.Z);
		GlobalTransform = new Transform3D(GlobalTransform.Basis, randomPosition);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		ApplyCentralForce(new Vector3(0, 0, obstacleSpeed));
	}
}
