using System.Text.RegularExpressions;
using MathGame;
using MathGame.Services;


var appStart = new AppStart();

string name;
do
{
    Console.Write("Insert your name: ");
    name = Console.ReadLine().Trim();
}
while(Regex.IsMatch(name, @"\d") || string.IsNullOrWhiteSpace(name));

appStart.SavingUserName(name);
appStart.AppWelcome();

bool GameOn = true;
// var mathOperations = new MathOperations();
var randomMathOperations = new RandomMathOperations();
var mathDifficulty = new MathDifficulty();
var gameHistory = new GameHistory();
var gameTimer = new GameTimer();

while(GameOn)
{
  gameTimer.StartTimer();
  // mathOperations.DisplayOperationMenu();
  randomMathOperations.DisplayOperationMenu();
  var userMathOption = Console.ReadLine().Trim().ToUpper();
  // Validate input is not null, and matches the pattern
  while (userMathOption == null || !Regex.IsMatch(userMathOption, "[A|S|M|D|V|Q]"))
  {
      Console.WriteLine("Error: Unrecognized input.");
      userMathOption = Console.ReadLine().Trim().ToUpper();
  }
  if(userMathOption == "V")
    gameHistory.ViewRandomGameHistory();
    // gameHistory.ViewGameHistory();
  else if(userMathOption == "Q")
  {
    GameOn = false;
  }
  else 
  {
    // mathOperations.SetUserOperationOption(userMathOption);
    mathDifficulty.DisplayDifficultyMenu();
    var userDifficultyOption = Console.ReadLine().Trim().ToUpper();
    while (userDifficultyOption == null || !Regex.IsMatch(userDifficultyOption, "[E|M|H|Q]"))
    {
        Console.WriteLine("Error: Unrecognized input.");
        userDifficultyOption = Console.ReadLine().Trim().ToUpper();
    }
    if(userDifficultyOption == "Q")
    {
        GameOn = false;
    }
    else
    {
      mathDifficulty.SetUserDifficultyOption(Convert.ToChar(userDifficultyOption));

      mathDifficulty.SetDifficultyLevel();

      Console.Write("Insert number of Questions to be asked: ");
      var count = Console.ReadLine();
      while (count == "0")
      {
          Console.WriteLine("Enter a non-zero number: ");
          count = Console.ReadLine();
      }
      int cleanCount = 0;
      while (!int.TryParse(count, out cleanCount))
      {
          Console.Write("This is not valid input. Please enter a numeric value: ");
          count = Console.ReadLine();
      }
      // mathOperations.SetNOfQuestions(cleanCount);
      randomMathOperations.SetNOfQuestions(cleanCount);
      randomMathOperations._GameType = new();
      for(int i=0; i<cleanCount; i++)
      {
        randomMathOperations.SetRandomOperationOption();
        var randoms = mathDifficulty.ChooseDifficulty(randomMathOperations.GetRandomOperationOption());
        // var randoms = mathDifficulty.ChooseDifficulty(userMathOption);
        randomMathOperations.SetRandomGameType();
        // mathOperations.DoingMathOperation(randoms);
        randomMathOperations.DoingMathOperation(randoms);
      }

      gameTimer.EndTimer();
      // gameHistory.SaveGameHistory(mathOperations.score, DateTime.Now, mathOperations.GetGameType(), mathDifficulty.GetDifficultyLevel(), gameTimer.GetTimeSpan());
      gameHistory.SaveGameHistory(randomMathOperations.score, DateTime.Now, randomMathOperations.GetGameType(), mathDifficulty.GetDifficultyLevel(), gameTimer.GetTimeSpan());
      // mathOperations.DisplayScore();
      randomMathOperations.DisplayScore();
    }
  }
}





