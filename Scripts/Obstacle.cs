using Godot;
using System;

public partial class Obstacle : RigidBody3D
{

	private void OnAreaEntered(Area3D area)
	{
		if (area.Name == "CameraWall")
		{
			QueueFree();
		}
	}

}






