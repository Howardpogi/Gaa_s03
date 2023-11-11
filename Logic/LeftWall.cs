using Godot;

public class LeftWall : Area2D
{
    public int rightPlayerScore = 0;
    private Label rightScoreLabel;
    private Label winnerLabel;
    // private Label dueceLabel;
    // private Label targetScoreLabel;
    public bool wins;
    // public int targetScore = 4;
    private RightWall rightWall;
    public override void _Ready()
    {
        rightWall = GetNode<RightWall>("../RightWall");
        rightScoreLabel = GetNode<Label>("rightLabel");
        winnerLabel = GetNode<Label>("../RightWall/leftWinner");
        // dueceLabel = GetNode<Label>("../LeftWall/Deuce");
        // targetScoreLabel = GetNode<Label>("../LeftWall/TargetScore");
        UpdateScoreLabel();

    }

    public void OnWallAreaEntered(Area2D area)
    {
        if (area is Ball ball)
        {
            rightPlayerScore++;
            ball.direction = Vector2.Right;

            // GD.Print("Duece: ", ball.Duece);

            GD.Print("RP Current Score: " + rightPlayerScore);

            if (rightPlayerScore == ball.Duece)
            {
                ball.isDuece = false;
                GD.Print("Right Player Warning!");
            }

            if (rightPlayerScore == ball.TargetScore)
            {
                wins = true;
                winnerLabel.Text = "Right Player Wins!";
                ball.Visible = !ball.Visible;
            }

            // if (ball.Duece == rightPlayerScore && ball.Duece == rightWall.leftPlayerScore)
            // {
            //     dueceLabel.Text = "Duece!";
            //     targetScoreLabel.Text = "Target Score: " + ball.TargetScore + 1;
            // }

            ball.Reset();
            UpdateScoreLabel();
        }
    }

    public void UpdateScoreLabel()
    {
        rightScoreLabel.Text = "Right Player: " + rightPlayerScore.ToString();
    }
}
