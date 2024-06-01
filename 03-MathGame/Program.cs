using MathGame;
using MathGame.Services;


var appStart = new AppStart();
appStart.SavingUserName();
appStart.AppWelcome();

bool GameOn = true;
var mathOperations = new MathOperations();
var mathDifficulty = new MathDifficulty();
var gameHistory = new GameHistory();
var gameTimer = new GameTimer();

while(GameOn)
{
  gameTimer.StartTimer();
  mathOperations.DisplayOperationMenu();
  var userMathOption = Convert.ToChar(Console.ReadLine().Trim().ToUpper());
  if(userMathOption == 'V')
    gameHistory.ViewGameHistory();
  else if(userMathOption == 'Q')
  {
    GameOn = false;
  }
  else 
  {
    mathOperations.SetUserOperationOption(userMathOption);

    mathDifficulty.DisplayDifficultyMenu();
    var userDifficultyOption = Convert.ToChar(Console.ReadLine().Trim().ToUpper());
    if(userDifficultyOption == 'Q')
      {
        GameOn = false;
      }
    else
    {
      mathDifficulty.SetUserDifficultyOption(userDifficultyOption);

      mathDifficulty.SetDifficultyLevel();

      Console.Write("Insert number of Questions to be asked: ");
      var count = Convert.ToInt32(Console.ReadLine());
      
      mathOperations.SetNOfQuestions(count);
      for(int i=0; i<count; i++)
      {
        var randoms = mathDifficulty.ChooseDifficulty(userMathOption);
        mathOperations.DoingMathOperation(randoms);
      }

      mathOperations.DisplayScore();
      gameTimer.EndTimer();
      gameHistory.SaveGameHistory(mathOperations.score, DateTime.Now, mathOperations.GetGameType(), mathDifficulty.GetDifficultyLevel(), gameTimer.GetTimeSpan());
    }
  }
}





