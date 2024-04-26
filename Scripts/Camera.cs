using Godot;
using System;

public partial class Camera : Camera3D
{
	[Export] Node3D _Player = null;
	[Export] private float smoothCamera = 2f;

	float elapsed = 0.0f;

	// private Transform3D _cameraTransform = Transform3D.Identity;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Transform3D transform = Transform;
		// Vector3 _targetPosition = new(_Player.Position.X, _Player.Position.Y, GlobalPosition.Z);
		// Vector3 newPosition = GlobalTransform.Origin.Lerp(_targetPosition, (float)delta * smoothCamera);
		// GlobalTransform = new Transform3D(GlobalTransform.Basis, newPosition);


		// transform.Basis = new Basis(new Vector3(0, 1f, 0), 1f) * transform.Basis;
		// transform.Basis = transform.Basis.Rotated(Vector3.Up, 0.1f);
		float _rotationY = Mathf.LerpAngle(Mathf.DegToRad(0f), Mathf.DegToRad(45f), elapsed);

		transform.Basis = new Basis();

		// Transform = transform;
		Rotation = new Vector3(Rotation.X, _rotationY, Rotation.Z);

		// RotateObjectLocal(new Vector3(0, 1f, 0), 0.1f);
		elapsed += (float)delta;
	}

	public void RotateCamera()
	{


	}
}
