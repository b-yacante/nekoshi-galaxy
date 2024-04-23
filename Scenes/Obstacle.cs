using Godot;
using System;

public partial class Obstacle : RigidBody3D
{
	[Export] private float obstacleSpeed = 5f;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		
	}
}
