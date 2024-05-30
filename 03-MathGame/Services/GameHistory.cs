using MathGame.Models;

namespace MathGame.Services;
internal class GameHistory
{
    internal static List<Game> gameHistory = new();
    internal void SaveGameHistory(int scor, DateTime dateTime, GameType gameTyp, GameDifficulty gameDifficult)
    {
        var game = new Game()
        {
            gameDifficulty = gameDifficult,
            gameType = gameTyp,
            date = dateTime,
            score = scor
        };
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