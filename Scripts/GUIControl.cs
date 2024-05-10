using Godot;
using System;

public partial class GUIControl : Control
{
	[Export] private float scorePerTime = 2f;
	private float score = 0;
	private Label scoreLabel;
	private Label scoreLabelDie;
	private TextureRect heart1;
	private TextureRect heart2;
	private TextureRect heart3;
	private VBoxContainer losePanel;
	private VBoxContainer scoreGameContainer;
	private bool isDead = false;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		losePanel = GetNode<VBoxContainer>("LosePanel");
		scoreGameContainer = GetNode<VBoxContainer>("VBoxContainerRight");
		scoreLabel = GetNode<Label>("VBoxContainerRight/Label");
		scoreLabelDie = GetNode<Label>("LosePanel/MenuWindow/VBoxContainer/ScoreDie");
		heart1 = GetNode<TextureRect>("HBoxContainerLeft/1");
		heart2 = GetNode<TextureRect>("HBoxContainerLeft/2");
		heart3 = GetNode<TextureRect>("HBoxContainerLeft/3");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var timeElapse = Time.GetTicksMsec() / 1000f;
		UpdateScore(timeElapse);
	}

	private void UpdateScore(float timeElapse)
	{
		if (!isDead)
		{
			scoreGameContainer.Visible = true;
			losePanel.Visible = false;
			score = timeElapse / scorePerTime;

			scoreLabel.Text = Mathf.Floor(score).ToString();
		}
		else
		{
			scoreGameContainer.Visible = false;
			scoreLabelDie.Text = Mathf.Floor(score).ToString();
			losePanel.Visible = true;
		}
	}

	private void OnReplayPressed()
	{
		score = 0;
		scoreLabel.Text = "0";
		GetTree().ReloadCurrentScene();
	}
	private void OnUpdateLife(long life)
	{
		if (life == 2)
		{
			heart3.Visible = false;
		}
		else if (life == 1)
		{
			heart2.Visible = false;
		}
		else if (life == 0)
		{
			heart1.Visible = false;
			isDead = true;
		}
	}
}

