namespace MathGame.Services;

using MathGame.Models;
internal class MathDifficulty
{
    private int minValue { get; set; }
    private int maxValue { get; set;}
    private char _DifficultyOption; 
    private GameDifficulty _DifficultyLevel;
    internal void SetUserDifficultyOption(char difficultyOption)
    {
        _DifficultyOption = difficultyOption;
    }
    internal char GetUserODifficultyOption()
    {
      return _DifficultyOption;
    }
    internal GameDifficulty GetDifficultyLevel()
    {
      return _DifficultyLevel;
    }
    internal void SetDifficultyLevel()
    {
        switch(_DifficultyOption)
        {
            case 'E':
                    _DifficultyLevel = GameDifficulty.Easy;
                    break;
            case 'M':
                    _DifficultyLevel = GameDifficulty.Medium;                    
                    break;
            case 'H':
                    _DifficultyLevel = GameDifficulty.Hard;                    
                    break;
        }
    }
    internal void DisplayDifficultyMenu()
    {
        //Console.Clear();
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine(@"Choose from the options below:
                            E - Easy
                            M - Medium
                            H - Hard                     
                            Q - Exit
        ");
    }
    internal (int,int) ChooseDifficulty(char operation)
    {
        if(_DifficultyLevel.Equals(GameDifficulty.Easy))
          MakeEasy(operation);
        else if(_DifficultyLevel.Equals(GameDifficulty.Medium))
          MakeMedium(operation);
        else{MakeHard(operation);}
        return (minValue, maxValue);
    }
    internal void MakeEasy(char operation)
    {
        if(operation == 'D')
        {
            minValue = 1;
            maxValue = 99;
        }
        else
        {
          minValue = 1;
          maxValue = 9;
        }
    }
    internal void MakeMedium(char operation)
    {
        if(operation == 'D')
        {
            minValue = 100;
            maxValue = 999;
        }
        else
        {
          minValue = 10;
          maxValue = 99;
        }
    }
    internal void MakeHard(char operation)
    {
        if(operation == 'D')
        {
            minValue = 1000;
            maxValue = 9999;
        }
        else
        {
          minValue = 100;
          maxValue = 999;
        }
    }
}