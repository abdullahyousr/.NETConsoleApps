
using MathGame;
using MathGame.Services;

var appStart = new AppStart();
appStart.SavingUserName();
appStart.AppWelcome();

bool GameOn = true;
var mathOperations = new MathOperations();
var mathDifficulty = new MathDifficulty();
var gameHistory = new GameHistory();

while(GameOn)
{
  mathOperations.DisplayOperationMenu();
  var userMathOption = Convert.ToChar(Console.ReadLine().Trim().ToUpper());
  if(userMathOption == 'V')
    gameHistory.ViewGameHistory();
  else if(userMathOption == 'Q')
  {
    GameOn = false;
    return;
  }
  else 
  {
    mathOperations.SetUserOperationOption(userMathOption);

    mathDifficulty.DisplayDifficultyMenu();
    var userDifficultyOption = Convert.ToChar(Console.ReadLine().Trim().ToUpper());
    if(userDifficultyOption == 'Q')
      {
        GameOn = false;
        return;
      }
    else
    {
      mathDifficulty.SetUserDifficultyOption(userDifficultyOption);

      mathDifficulty.SetDifficultyLevel();

      for(int i=0; i<5; i++)
      {
        var randoms = mathDifficulty.ChooseDifficulty(userMathOption);
        mathOperations.DoingMathOperation(randoms);
      }

      mathOperations.DisplayScore();
      gameHistory.SaveGameHistory(mathOperations.score, DateTime.Now, mathOperations.GetGameType(), mathDifficulty.GetDifficultyLevel());
    }
  }
}
//var menu = new appmenu();
//playgame();


//void playgame()
//{
//    menu.difficultyapp();
//    if (!menu.isgameon())
//    {
//        return;
//    }
//    menu.operationapp();
//}





