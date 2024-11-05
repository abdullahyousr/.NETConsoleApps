using MathGame.Models;
namespace MathGame.Services;

internal class RandomMathOperations
{
  private int userResult {get; set;}
  private int appResult {get; set;}
  internal int score {get; set;}
  private int operand_1 { get; set; }
  private int operand_2 { get; set; }
  private int _RandomOperationOption;
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
  internal List<GameType> _GameType {get; set;}
    internal List<GameType> GetGameType()
    {
      return _GameType;
    }
    internal void SetRandomGameType()
    {
      GameType gameType = _RandomOperationOption switch
      {
          1 => GameType.Addition,
          2 => GameType.Subtraction,
          3 => GameType.Multiplication,
          4 => GameType.Division,
      };
      _GameType.Add(gameType);
    }
  internal int GetRandomOperationOption()
  {
    return _RandomOperationOption;
  }
  internal void SetRandomOperationOption()
  {
      var random = new Random();
      _RandomOperationOption = random.Next(1,4);
  }
  internal void DisplayOperationMenu()
  {
      //Console.Clear();
      Console.WriteLine("--------------------------------------------");
      Console.WriteLine(@"Choose from the options below:
                          V - View Math Operation History
                          A - MathOperation
                          Q - Exit
      ");
  }

  private void RandomizeOperands(int operation, int minValue, int maxValue)
  {
        var random = new Random();
        if(operation == 4)
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
  =>  appResult = _RandomOperationOption switch
      {
          1 => operand_1 + operand_2,
          2 => operand_1 - operand_2,
          3 => operand_1 * operand_2,
          4 => operand_1 / operand_2,
      };
    private char ConvertOperationOptionToChar()
  =>  _OperationChar = _RandomOperationOption switch
      {
          1 => '+',
          2 => '-',
          3 => '*',
          4 => '/',
      };
  private void ReadUserAnswer()
  {
        Console.Write($"Enter the Result of {operand_1} {ConvertOperationOptionToChar()} {operand_2}: ");
        userResult = Convert.ToInt32(Console.ReadLine().Trim());
  }

  private bool CompareUserAnswerWithAppResult()
  {
      if(Convert.ToInt32(userResult) == appResult)
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
    RandomizeOperands(_RandomOperationOption, randomNums.minValue, randomNums.maxValue);
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