using MathGame.Models;
using static MathGame.Models.Game;
namespace MathGame;

internal class MathOperations
{
  internal GameHistory gameHistory = new GameHistory();
  MathDifficulty mathDifficulty = new();
  internal int operand_1 { get; set; }
  internal int operand_2 { get; set; }
  internal void RandomizeOperands(char operation, int minValue, int maxValue)
  {
        var random = new Random();
        if(operation == '/')
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
  internal void DoMathOperation(GameType gameType, GameDifficulty Difficulty, char operation)
  {
      Console.WriteLine($"You have chosen {gameType}");
      Console.ReadLine();
      int score = 0;
      for(int i = 0; i < 5; i++)
      {
        Console.Clear();
        Console.WriteLine("--------------------------------------------");

        // Difficulty type
        (int minValue, int maxValue) difficultyRandom =  mathDifficulty.ChooseDifficulty(Difficulty, operation);
        
        // Random Numbers of Operands
        RandomizeOperands(operation, difficultyRandom.minValue, difficultyRandom.maxValue);
       
        // UserResult and RealResult
        int result = SelectMathOperation(operand_1, operand_2, operation);
        Console.Write($"Enter the Result of {operand_1} {operation} {operand_2}: ");
        var userResult = Console.ReadLine();
        
        //Validate UserInput
        userResult = validateUserInput(userResult);

      // Compare UserResult with Result
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
      // Showing Score
      Console.Clear();
      Console.WriteLine("--------------------------------------------");
      Console.WriteLine($"Game Over! your score is {score} / 5");
      Console.ReadLine();
      // saving Game
      Game game = new() {gameType = gameType, gameDifficulty = Difficulty,  score = score };
      gameHistory.SaveGameHistory(game);
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