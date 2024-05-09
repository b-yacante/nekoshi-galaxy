using Godot;
using System;

public partial class Camera : Camera3D
{
	[Export] Node3D _Player = null;
	[Export] private float smoothCamera = 2f;
	[Export] private float DegreeRotation = 5f;
	[Export] private float MovePosition = 0.2f;

	float elapsed = 6.0f;
	Vector2 degRot = Vector2.Zero;
	Vector2 pos = Vector2.Zero;
	public override void _Ready()
	{
		var _player = GetNode<Nekoshi>("Nekoshi");
		_player.LanePosition += OnLanePosition;
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector3 newRotation = Rotation.Lerp(new Vector3(Mathf.DegToRad(degRot.X), Mathf.DegToRad(degRot.Y), 0), (float)delta * elapsed);
		Rotation = newRotation;
	}
	public void OnLanePosition(Vector2I lanePos)
	{

		// posicion y rotacion en Y
		if (lanePos.Y < 0)
		{
			degRot.X = DegreeRotation + 10;
			// degRot.Y = 0f;
		}
		else if (lanePos.Y > 0)
		{
			degRot.X = (DegreeRotation + 10) * -1;
			// degRot.Y = 0f;
		}
		else
		{
			degRot.X = 0f;
		}
		// si la posicion en Y es 0

		if (lanePos.X > 0)
		{
			degRot.Y = DegreeRotation;
			// degRot.X = 0f;
		}
		else if (lanePos.X < 0)
		{

			degRot.Y = DegreeRotation * -1;
			// pos.Y = 0f;
			// degRot.X = 0f;
		}
		else
		{
			degRot.Y = 0f;
		}

	}

	public void RotateCamera()
	{


	}
}

