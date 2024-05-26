
using MathGame;

string name = GetName();
var menu = new AppMenu();

AppStart(name);
PlayGame();

string GetName()
{
  Console.Write("Insert your name: ");
  string name = Console.ReadLine();
  Console.Clear();
  return name;
}
void AppStart(string name)
{
  Console.WriteLine("--------------------------------------------");
  Console.WriteLine($"Hello {name}! It's {DateTime.Now}");
  Console.WriteLine($"Welcome to the Math Game Application");
  Console.ReadLine();
}
void PlayGame()
{
    menu.DifficultyApp();
     if(!menu.IsGameOn())
      {
          return;
      }
    menu.OperationApp();
}





