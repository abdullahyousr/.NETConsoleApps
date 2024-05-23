namespace MathGame.Models;

public class Game
{
    public DateOnly date {get; set;} = DateOnly.FromDateTime(DateTime.Now);
    public GameType gameType {get; set;}
    public int score {get; set;}
    public GameDifficulty gameDifficulty {get; set;}
    public enum GameType
    {
        Addition,
        Subtraction,
        Multiplication,
        Division
    }
    public enum GameDifficulty
    {
        Easy,
        Medium,
        Hard
    }
}