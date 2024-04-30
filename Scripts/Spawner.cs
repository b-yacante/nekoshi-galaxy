using Godot;
using System;

public partial class Spawner : Node3D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void IntantiateObstacles()
	{
		var _obstacle = GD.Load<PackedScene>("res://Scenes/obstacle.tscn").Instantiate();
		AddChild(_obstacle);

	}

	private void OnTimerTimeout()
	{
		IntantiateObstacles();
	}
}
