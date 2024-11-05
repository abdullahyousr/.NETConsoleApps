namespace MathGame.Models;

public class Game
{
    public DateTime date {get; set;}
    public int score {get; set;}
    public TimeSpan gameTimer {get; set;}
    // public GameType gameType {get; set;}
    public List<GameType> gameType {get; set;}
    public GameDifficulty gameDifficulty {get; set;}

    public Game()
    {
        gameType = new();
    }
}