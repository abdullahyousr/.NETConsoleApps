using MathGame.Models;

namespace MathGame;

internal class AppMenu
{
    internal MathOperations mathOperations = new MathOperations();
    internal Game.GameDifficulty gameDifficulty = new();
    internal static bool IsGameOn = true;

    internal void GameMenu()
    {
        Console.Clear();
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine(@"Choose from the options below:
                            V - View Math Operation History
                            A - Addition
                            S - Subtraction
                            M - Multiplication
                            D - Division
                            Q - Exit
        ");

        string option = Console.ReadLine().Trim().ToUpper();
        SelectOption(option);
    }
    internal void SelectOption(string option)
    {
        DifficultyMenu();

        Console.Clear();
        Console.WriteLine("--------------------------------------------");
        
        switch(option)
        {
            case "V": mathOperations.gameHistory.ViewGameHistory();
            break;
            case "A":
            mathOperations.DoMathOperation(Game.GameType.Addition, gameDifficulty, '+');
            break;
            case "S":
            mathOperations.DoMathOperation(Game.GameType.Subtraction, gameDifficulty, '-');
            break;
            case "M":
            mathOperations.DoMathOperation(Game.GameType.Multiplication, gameDifficulty, '*');
            break;
            case "D":
            mathOperations.DoMathOperation(Game.GameType.Division, gameDifficulty, '/');
            break;
            case "Q":
            Console.WriteLine("You have chosen to exit the application");
            Console.WriteLine("Good Bye!");
            Console.ReadLine();
            IsGameOn = false;
            break;
            default:
            Console.WriteLine("Invalid option selected");
            Console.ReadLine();
            break;
        }
    }
    internal void DifficultyMenu()
    {
        Console.Clear();
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine(@"Choose from the options below:
                            E - Easy
                            M - Medium
                            H - Hard                     
                            Q - Exit
        ");

        string option = Console.ReadLine().Trim().ToUpper();
        SelectDifficultyOption(option);
    }
    internal void SelectDifficultyOption(string option)
    {
        Console.Clear();
        Console.WriteLine("--------------------------------------------");
        switch(option)
        {
            case "E":
                    gameDifficulty = Game.GameDifficulty.Easy;
                    break;
            case "M":
                    gameDifficulty = Game.GameDifficulty.Medium;                    
                    break;

            case "H":
                    gameDifficulty = Game.GameDifficulty.Hard;                    
                    break;
            case "Q":
            Console.WriteLine("You have chosen to exit the application");
            Console.WriteLine("Good Bye!");
            Console.ReadLine();
            IsGameOn = false;
            break;
            default:
            Console.WriteLine("Invalid option selected");
            Console.ReadLine();
            break;
        }
    }
}