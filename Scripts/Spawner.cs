using Godot;
using System;
using System.Collections.Generic;

public partial class Spawner : Node3D
{
	[Export] private string[] obs1Path;

	[Export] private float obstacleSpeed = 2;
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
		Vector2I[] auxArr = new Vector2I[amount];
		List<Vector2I> arr = new List<Vector2I>();

		for (int i = 0; i < amount; i++)
		{
			// intanciamos la escena
			var sceneToInstance = GD.Load<PackedScene>(obs1Path[0]).Instantiate();
			// comprobamos si la escena trae algo
			if (sceneToInstance != null)
			{
				// agregamos a la escena como hijo del spawner
				AddChild(sceneToInstance);
				// obtenemos el nodo principal de la escena
				Node3D nodeInstance = sceneToInstance.GetNode<Node3D>(".");

				if (nodeInstance != null)
				{
					var randomNumber = new RandomNumberGenerator();
					int randomLaneX = 0;
					int randomLaneY = 0;

					while (true)
					{
						randomLaneX = randomNumber.RandiRange(-1, 1);
						randomLaneY = randomNumber.RandiRange(-1, 1);

						Vector2I randomVal = new Vector2I(randomLaneX, randomLaneY);

						if (!arr.Exists((el) => el == randomVal))
						{
							arr.Add(randomVal);
							break;
						}
					}

					Vector3 randomPosition = new(randomLaneX * _laneDistance, randomLaneY * _laneDistance, nodeInstance.GlobalPosition.Z);
					nodeInstance.GlobalPosition = randomPosition;
					// obtenemos el rigidbody del nodo
					RigidBody3D rb3d = nodeInstance.GetNode<RigidBody3D>(".");
					// aplicamos una fuerza al rigidbody
					rb3d.ApplyCentralImpulse(new Vector3(0, 0, obstacleSpeed));
				}
			}
		}

	}
	private void OnWorldVelocity(double vel)
	{
		float multiplicator = (float)(vel / 10) + 1;
		obstacleSpeed = obstacleSpeed * multiplicator;
	}

	private void OnTimerTimeout()
	{
		var randomNumber = new RandomNumberGenerator();
		int amount = randomNumber.RandiRange(1, 2);
		IntantiateObstacles(amount);
	}
}


