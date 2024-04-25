using Godot;
using System;

public partial class Camera : Camera3D
{
	[Export] Node3D _Player = null;
	[Export] private float smoothCamera = 0.70f;

	// private Transform3D _cameraTransform = Transform3D.Identity;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

		

		// Vector3 _targetPosition = new(_Player.Position.X, _Player.Position.Y, GlobalPosition.Z);
		// Vector3 newPosition = GlobalTransform.Origin.Lerp(_targetPosition, (float)delta * smoothCamera);
		// GlobalTransform = new Transform3D(GlobalTransform.Basis, newPosition);

	}
}
