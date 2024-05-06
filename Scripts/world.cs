using Godot;
using System;

public partial class world : Node
{
	[Signal] public delegate void WorldVelocityEventHandler(float vel);

	private float initVel = 1;
	[Export] private float acceleration = 0.2f;
	[Export] private float progressTime = 5f;
	private float gameTime;


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		gameTime += (float)delta;
	}

	private void VelocityTimer()
	{

	}
}
