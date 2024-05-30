namespace MathGame.Models;

public class Game
{
    public DateTime date {get; set;}
    public int score {get; set;}
    public GameType gameType {get; set;}
    public GameDifficulty gameDifficulty {get; set;}
}