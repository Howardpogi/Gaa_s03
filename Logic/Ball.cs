using System;
using Godot;

public class Ball : Area2D
{
	private const int DefaultSpeed = 100;

	public Vector2 direction = Vector2.Right;

	private Vector2 _initialPos;
	private float _speed = DefaultSpeed;

	private LeftWall leftWall;
	private RightWall rightWall;

	public int warningRight;
	public int warningLeft;
	public int Duece = 3;
	public bool isDuece;
	public int TargetScore = 4;
	private Label dueceLabel;
	private Label targetScoreLabel;

	public override void _Ready()
	{
		_initialPos = Position;
		leftWall = GetNode<LeftWall>("../LeftWall");
		rightWall = GetNode<RightWall>("../RightWall");
		dueceLabel = GetNode<Label>("../LeftWall/Deuce");
		targetScoreLabel = GetNode<Label>("../LeftWall/TargetScore");

	}

	public override void _Process(float delta)
	{
		_speed += delta * 2;
		Position += _speed * delta * direction;
		targetScoreLabel.Text = "Target Score: " + TargetScore;

		if (leftWall.rightPlayerScore == TargetScore || rightWall.leftPlayerScore == TargetScore)
		{
			_speed = 0;
		}
		if (Duece == leftWall.rightPlayerScore && Duece == rightWall.leftPlayerScore)
		{
			Duece++;
			TargetScore++;
			isDuece = true;

			GD.Print("Duece! ");

			GD.Print("target score: ", TargetScore);
			dueceLabel.Text = "Duece!";
			targetScoreLabel.Text = "Target Score: " + TargetScore + 1;
		}

		if (leftWall.rightPlayerScore != rightWall.leftPlayerScore)
		{
			isDuece = false;
			dueceLabel.Text = "";
		}
	}

	public void Reset()
	{
		Position = _initialPos;
		_speed = DefaultSpeed;
	}
}
