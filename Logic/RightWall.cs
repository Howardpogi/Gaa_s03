using Godot;

public class RightWall : Area2D
{
    public int leftPlayerScore = 0;
    private Label leftScoreLabel;
    private Label winnerLabel;
    public bool wins;
    // public int targetScore = 4;
    private LeftWall leftWall;
    public override void _Ready()
    {
        leftWall = GetNode<LeftWall>("../LeftWall");
        leftScoreLabel = GetNode<Label>("leftLabel");
        winnerLabel = GetNode<Label>("../LeftWall/rightWinner");
        UpdateScoreLabel();
    }

    public void OnWallAreaEntered(Area2D area)
    {
        if (area is Ball ball)
        {
            leftPlayerScore++;
            ball.direction = Vector2.Left;
            // GD.Print("Duece: ", ball.Duece);

            GD.Print("LP Current Score: " + leftPlayerScore);
            ball.isDuece = false;

            if (leftPlayerScore == ball.Duece)
            {
                GD.Print("Left Player Warning!");
            }
            if (leftPlayerScore == ball.TargetScore)
            {
                wins = true;
                winnerLabel.Text = "Left Player Wins!";
                ball.Visible = !ball.Visible;
            }

            ball.direction = Vector2.Left;

            ball.Reset();
            UpdateScoreLabel();
        }
    }

    public void UpdateScoreLabel()
    {
        leftScoreLabel.Text = "Left Player: " + leftPlayerScore.ToString();
    }
}
