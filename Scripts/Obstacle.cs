using Godot;
using System;

public partial class Obstacle : RigidBody3D
{
	[Export] private Sprite3D spriteNodo;
	[Export] private Texture2D[] spriteTexture;


	public override void _Ready()
	{
		var randomNumber = new RandomNumberGenerator();
		int randomIndexTexture = randomNumber.RandiRange(0, 6);

		spriteNodo = GetNode<Sprite3D>("Sprite3D");
		spriteNodo.Texture = spriteTexture[randomIndexTexture];
	}

	private void OnAreaEntered(Area3D area)
	{
		if (area.Name == "CameraWall")
		{
			QueueFree();
		}
	}

}






