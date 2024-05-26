using MathGame.Models;

namespace MathGame;
internal class GameHistory
{
    internal static List<Game> gameHistory = new();
    internal void SaveGameHistory(Game game)
    {
        gameHistory.Add(game);
    }   
    internal void ViewGameHistory()
    {
        Console.Clear();
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine("Game History");
        foreach(var game in gameHistory)
        {
            Console.WriteLine(game.date.ToString("d") + " - " + game.gameType + " - " + game.gameDifficulty + " - " + game.score);
        }
        Console.WriteLine("--------------------------------------------");
        Console.ReadLine();
    }
}