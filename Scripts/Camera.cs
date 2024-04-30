using Godot;
using System;

public partial class Camera : Camera3D
{
	[Export] Node3D _Player = null;
	[Export] private float smoothCamera = 2f;
	[Export] private float DegreeRotation = 5f;
	[Export] private float MovePosition = 0.2f;

	float elapsed = 3.0f;
	Vector2 degRot = Vector2.Zero;
	Vector2 pos = Vector2.Zero;

	public override void _Ready()
	{
		var _player = GetNode<Nekoshi>("Nekoshi");
		_player.LanePosition += OnLanePosition;
	}

	public override void _Process(double delta)
	{
		Vector3 newPosition = GlobalTransform.Origin.Lerp(new Vector3(pos.X, pos.Y, GlobalPosition.Z), (float)delta * smoothCamera);
		GlobalTransform = new Transform3D(GlobalTransform.Basis, newPosition);

		Vector3 newRotation = Rotation.Lerp(new Vector3(Mathf.DegToRad(degRot.X), Mathf.DegToRad(degRot.Y), 0), (float)delta * elapsed);
		Rotation = newRotation;

	}
	public void OnLanePosition(Vector2I lanePos)
	{

		// posicion y rotacion en Y
		if (lanePos.Y < 0)
		{
			degRot.X = DegreeRotation;
			pos.Y = MovePosition;
			pos.X = 0f;
			degRot.Y = 0f;
		}
		else if (lanePos.Y > 0)
		{
			pos.Y = MovePosition * -1;
			degRot.X = DegreeRotation * -1;
			pos.X = 0f;
			degRot.Y = 0f;
		}
		// si la posicion en Y es 0
		else
		{
			pos.Y = 0f;
			degRot.Y = 0f;
			// movemos la camara en X
			if (lanePos.X > 0)
			{
				pos.X = MovePosition;
				degRot.Y = DegreeRotation;
				pos.Y = 0f;
				degRot.X = 0f;
			}
			else if (lanePos.X < 0)
			{
				pos.X = MovePosition * -1;
				degRot.Y = DegreeRotation * -1;
				pos.Y = 0f;
				degRot.X = 0f;
			}
			else
			{
				pos.X = 0f;
				degRot.X = 0f;
			}
		}
	}

	public void RotateCamera()
	{


	}
}

