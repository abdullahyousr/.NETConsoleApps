namespace MathGame;

using static MathGame.Models.Game;
internal class MathDifficulty
{
    internal int minValue { get; set; }
    internal int maxValue { get; set;}
    internal (int,int) ChooseDifficulty(GameDifficulty gameDifficulty, char operation)
    {
        if(gameDifficulty.Equals(GameDifficulty.Easy))
          MakeEasy(operation);
        else if(gameDifficulty.Equals(GameDifficulty.Medium))
          MakeMedium(operation);
        else{MakeHard(operation);}
        return (minValue, maxValue);
    }
    internal void MakeEasy(char operation)
    {
        if(operation == '/')
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
        if(operation == '/')
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
        if(operation == '/')
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