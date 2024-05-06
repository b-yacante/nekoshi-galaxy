using Godot;
using System;

public partial class Spawner : Node3D
{
	[Export] private string[] obs1Path;
	private const float _laneDistance = 0.65f;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void IntantiateObstacles(int amount)
	{
		for (int i = 0; i < amount; i++)
		{
			var sceneToInstance = GD.Load<PackedScene>(obs1Path[i]).Instantiate();

			if (sceneToInstance != null)
			{
				AddChild(sceneToInstance);

				Node3D nodeInstance = sceneToInstance.GetNode<Node3D>(".");

				if (nodeInstance != null)
				{
					var randomNumber = new RandomNumberGenerator();
					int randomLaneX = randomNumber.RandiRange(-1, 1);
					int randomLaneY = randomNumber.RandiRange(-1, 1);

					Vector3 randomPosition = new(randomLaneX * _laneDistance, randomLaneY * _laneDistance, nodeInstance.GlobalPosition.Z);
					nodeInstance.GlobalPosition = randomPosition;
				}
				else
				{
					GD.Print("Object null");
				}


			}
		}

	}

	private void OnTimerTimeout()
	{
		var randomNumber = new RandomNumberGenerator();
		int amount = randomNumber.RandiRange(1, 2);
		IntantiateObstacles(amount);
	}
}
