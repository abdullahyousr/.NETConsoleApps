using MathGame.Models;
namespace MathGame.Services;

internal class MathOperations
{
  private int _userResult {get; set;}
  private int appResult {get; set;}
  internal int score {get; set;}
  private int operand_1 { get; set; }
  private int operand_2 { get; set; }
  private char _OperationOption;
  private char _OperationChar;
  private int NOfQuestions;
  internal void SetNOfQuestions(int count)
  {
      NOfQuestions = count;
  }
  internal int GetNOfQuestions()
  {
      return NOfQuestions;
  }
  private GameType _GameType {get; set;}
    internal GameType GetGameType()
    {
      return _GameType;
    }
    internal void SetGameType()
    {
        switch(_OperationOption)
        {
            case 'A':
                    _GameType = GameType.Addition;
                    break;
            case 'S':
                    _GameType = GameType.Subtraction;                    
                    break;
            case 'D':
                    _GameType = GameType.Division;                    
                    break;
            case 'M':
                    _GameType = GameType.Multiplication;
                    break;
        }
    }
  internal char GetUserOperationOption()
  {
    return _OperationOption;
  }
  internal void SetUserOperationOption(char operationOption)
  {
    _OperationOption = operationOption;
  }
  internal void DisplayOperationMenu()
  {
      //Console.Clear();
      Console.WriteLine("--------------------------------------------");
      Console.WriteLine(@"Choose from the options below:
                          V - View Math Operation History
                          A - Addition
                          S - Subtraction
                          M - Multiplication
                          D - Division
                          Q - Exit
      ");
  }
  private void RandomizeOperands(char operation, int minValue, int maxValue)
  {
        var random = new Random();
        if(operation == 'D')
        {
            operand_1 = random.Next(minValue, maxValue);
            operand_2 = random.Next(minValue, maxValue);
            while(operand_1 % operand_2 != 0)
            {
              operand_1 = random.Next(minValue, maxValue);
              operand_2 = random.Next(minValue, maxValue);
            }
        }
        else
        {
          operand_1 = random.Next(minValue, maxValue);
          operand_2 = random.Next(minValue, maxValue);
        }
  }
  
  private void CalculateAppResult()
  =>  appResult = _OperationOption switch
      {
          'A' => operand_1 + operand_2,
          'S' => operand_1 - operand_2,
          'M' => operand_1 * operand_2,
          'D' => operand_1 / operand_2,
      };
    private char ConvertOperationOptionToChar()
  =>  _OperationChar = _OperationOption switch
      {
          'A' => '+',
          'S' => '-',
          'M' => '*',
          'D' => '/',
      };
  private void ReadUserAnswer()
  {
        Console.Write($"Enter the Result of {operand_1} {ConvertOperationOptionToChar()} {operand_2}: ");
        var userResult = Console.ReadLine().Trim();
        int cleanResult = 0;
        while (!int.TryParse(userResult, out cleanResult))
        {
            Console.Write("This is not valid input. Please enter a numeric value: ");
            userResult = Console.ReadLine().Trim();
        }
        _userResult = cleanResult;
  }

  private bool CompareUserAnswerWithAppResult()
  {
      if(Convert.ToInt32(_userResult) == appResult)
      {
        return true;
      }
      else
      {
        return false;
      }
  }
  private void IncrementScore()
  {
    score++;
  }
  private void DisplaySuccessMessage()
  {
      Console.WriteLine("Congratulations! You got the correct answer");
      Console.ReadLine();
  }
  private void DisplayFailedMessage()
  {
      Console.WriteLine($"Sorry! The correct answer is {appResult}");
      Console.ReadLine();
  }
  internal void DoingMathOperation((int minValue, int maxValue) randomNums)
  {
    SetGameType();
    RandomizeOperands(_OperationOption, randomNums.minValue, randomNums.maxValue);
    CalculateAppResult();
    ReadUserAnswer();
    if(CompareUserAnswerWithAppResult())
    {
        DisplaySuccessMessage();
        IncrementScore();
    }
    else
    {
        DisplayFailedMessage();
    }
  }
  internal void DisplayScore()
  {
    //Console.Clear();
    Console.WriteLine("--------------------------------------------");
    Console.WriteLine($"Game Over! your score is {score} / {NOfQuestions}");
    Console.ReadLine();
    score = 0;
  }
  
  internal string validateUserInput(string userResult)
  {
        while(string.IsNullOrEmpty(userResult) || !int.TryParse(userResult, out _))
        {
          Console.WriteLine("Please enter a valid number");
          userResult = Console.ReadLine();
        }
        return userResult;
  }
}