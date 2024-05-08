using Godot;
using System;

public partial class World : Node
{
	[Signal] public delegate void WorldVelocityEventHandler(int vel);

	private float initVel = 1;
	[Export] private float acceleration = 0.2f;
	[Export] private float progressTime = 5f;
	private float gameTime;
	private int multVel = 1;


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var timeElapse = Time.GetTicksMsec();
		gameTime = timeElapse / 1000f;

		if (gameTime >= progressTime)
		{
			multVel++;
			AddVelocity();
			progressTime += progressTime;
			GD.Print(gameTime);
		}
	}

	private void AddVelocity()
	{
		EmitSignal(SignalName.WorldVelocity, multVel);
	}
}
