using MathGame.Models;

namespace MathGame;

internal class AppMenu
{

    //OperationOption

    //If OperationOption == E Exit App

    //DifficultyOption

    //If DifficultyOption == E Exit App

    //ValidateOptions

    //

    internal MathOperations mathOperations = new MathOperations();
    internal Game.GameDifficulty gameDifficulty = new();
    internal string OperationOption {get; set;}
    internal string DifficultyOption {get; set;}
    internal bool GameOn = true;


    internal void OperationApp()
    {
         do{
            OperationMenu();
            if(!IsGameOn())
            {
                ExitApp();
                break;
            }
            }while(IsGameOn());
    }

    internal void DifficultyApp()
    {
         do{
            DifficultyMenu();
            if(!IsGameOn())
            {
                break;
            }
            }while(IsGameOn());
    }

    internal void OperationMenu()
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

        OperationOption = Console.ReadLine().Trim().ToUpper();
        SelectOperationOption(OperationOption);
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

        DifficultyOption = Console.ReadLine().Trim().ToUpper();
        SelectDifficultyOption(DifficultyOption);
    }

    internal void ValidateOptions()
    {

    }

    internal bool IsGameOn ()
    {
        if(OperationOption == "Q" || DifficultyOption == "Q")
            GameOn = false;
        else GameOn = true;
        return GameOn;
    }

    internal void ExitApp()
    {
        Console.WriteLine("You have chosen to exit the application");
        Console.WriteLine("Good Bye!");
        Console.ReadLine();
    }

    internal void SelectOperationOption(string option)
    {
        Console.Clear();
        Console.WriteLine("--------------------------------------------");
        
        switch(option)
        {
            case "V": 
                    mathOperations.gameHistory.ViewGameHistory();
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
                    ExitApp();                    
                    break;
            default:
                    Console.WriteLine("Invalid option selected");
                    Console.ReadLine();
                    break;
        }
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
                    ExitApp();                    
                    break;
            default:
                    Console.WriteLine("Invalid option selected");
                    Console.ReadLine();
                    break;
        }
    }
}