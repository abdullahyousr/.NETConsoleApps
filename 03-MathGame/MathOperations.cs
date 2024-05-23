using MathGame.Models;
using static MathGame.Models.Game;
namespace MathGame;

internal class MathOperations
{
  internal GameHistory gameHistory = new GameHistory();
  MathDifficulty mathDifficulty = new();
  internal void DoMathOperation(GameType gameType, GameDifficulty gameDifficulty, char operation)
  {
      Console.WriteLine($"You have chosen {gameType}");
      Console.ReadLine();
      var random = new Random();
      int score = 0;
      for(int i = 0; i < 5; i++)
      {
        Console.Clear();
        Console.WriteLine("--------------------------------------------");
        int operand_1;
        int operand_2;
        if(gameDifficulty.Equals(GameDifficulty.Easy))
          mathDifficulty.MakeEasy(out operand_1, out operand_2, operation);
        else if(gameDifficulty.Equals(GameDifficulty.Medium))
          mathDifficulty.MakeMedium(out operand_1, out operand_2, operation);
        else{mathDifficulty.MakeHard(out operand_1, out operand_2, operation);}
        // if(operation == '/')
        // {
        //     operand_1 = random.Next(1, 99);
        //     operand_2 = random.Next(1, 99);
        //     while(operand_1 % operand_2 != 0)
        //     {
        //       operand_1 = random.Next(1, 99);
        //       operand_2 = random.Next(1, 99);
        //     }
        // }
        // else
        // {
        //   operand_1 = random.Next(1, 9);
        //   operand_2 = random.Next(1, 9);
        // }
        Console.Write($"Enter the Result of {operand_1} {operation} {operand_2}: ");
        var userResult = Console.ReadLine();
        
        userResult = validateUserInput(userResult);

        int result = SelectMathOperation(operand_1, operand_2, operation);
        if(Convert.ToInt32(userResult) == result)
        {
          Console.WriteLine("Congratulations! You got the correct answer");
          score++;
          Console.ReadLine();
        }
        else
        {
          Console.WriteLine($"Sorry! The correct answer is {result}");
          Console.ReadLine();
        }
      }
      Console.Clear();
      Console.WriteLine("--------------------------------------------");
      Console.WriteLine($"Game Over! your score is {score} / 5");
      Console.ReadLine();
      Game game = new() {gameType = gameType, score = score };
      gameHistory.AddToGameHistory(game);
  }
  internal int SelectMathOperation(int num1, int num2, char operation)
      => operation switch
      {
          '+' => num1 + num2,
          '-' => num1 - num2,
          '*' => num1 * num2,
          '/' => num1 / num2,
      };
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