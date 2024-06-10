using MathGame.Models;

namespace MathGame.Services;
internal class GameHistory
{
    internal static List<Game> gameHistory;
    internal GameHistory()
    {
        gameHistory = new();
    }
    internal void SaveGameHistory(int scor, DateTime dateTime, List<GameType> gameTyp, GameDifficulty gameDifficult, TimeSpan gameTim)
    {
        var game = new Game()
        {
            gameDifficulty = gameDifficult,
            gameType = gameTyp,
            date = dateTime,
            score = scor,
            gameTimer = gameTim
        };
        gameHistory.Add(game);
    }   
    internal void ViewGameHistory()
    {
        Console.Clear();
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine("Game History");
        Console.WriteLine( "Date" + " - " + "Game Type" + " - " + "Game Difficulty" + " - " + "Score" + " - " + "Timer");
        foreach (var game in gameHistory)
        {
            Console.WriteLine(game.date.ToString("d") + " - " + game.gameType + " - " + game.gameDifficulty + " - " + game.score + " - " + game.gameTimer);
        }
        Console.WriteLine("--------------------------------------------");
        Console.ReadLine();
    }
    internal void ViewRandomGameHistory()
    {
        Console.Clear();
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine("Game History");
        Console.WriteLine( "Date" + " - " + " - " + "Game Difficulty" + " - " + "Score" + " - " + "Timer");
        foreach (var game in gameHistory)
        {
            Console.WriteLine(game.date.ToString("d") + " - " +game.gameDifficulty + " - " + game.score + " - " + game.gameTimer);
            Console.WriteLine( "Game Type" );
            foreach (var gameType in game.gameType)
            {
                Console.WriteLine(" --- " + gameType + " --- ");
            }
        }
        Console.WriteLine("--------------------------------------------");
        Console.ReadLine();
    }
}