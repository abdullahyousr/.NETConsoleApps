
using MathGame;

Console.WriteLine("Welcome to the Math Game Application");

List<MathOperations> mathOperationsHistory = new();

while(true)
{
  Console.WriteLine("Choose an operation from the menu below: ");
  Console.WriteLine("1) Addition");
  Console.WriteLine("2) Subtraction");
  Console.WriteLine("3) Division");
  Console.WriteLine("4) Multiplication");
  Console.WriteLine("5) View Math Operations History");
  Console.Write("Enter Operation Number: ");
  try 
  {
    int OperationNumber = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine();
      
    if(OperationNumber == 5)
    { 
      foreach( var mathSingleOperation in mathOperationsHistory)
      {
        Console.WriteLine($"{mathSingleOperation.Operand_1} {mathSingleOperation.Operation} {mathSingleOperation.Operand_2} = {mathSingleOperation.result}" );
      }
    }
    else
    {
      Console.Write("Enter First Operand: ");
      int FirstOperand = Convert.ToInt32(Console.ReadLine());
      Console.WriteLine();

      Console.Write("Enter Second Operand: ");
      int SecondOperand = Convert.ToInt32(Console.ReadLine());
      Console.WriteLine();


      char Operation = OperationNumber switch  {
        1 => '+',
        2 => '-',
        3 => '/',
        4 => '*',
      };

      var mathOperation = new MathOperations();

      mathOperation.Operand_1 = FirstOperand;
      mathOperation.Operand_2 = SecondOperand;
      mathOperation.Operation = Operation;

        if(Operation.Equals('/') && !mathOperation.AcceptDivisionRules())
        {
          Console.WriteLine($"Can not divide {FirstOperand} by {SecondOperand}");
        }
        else
        {
          mathOperation.result = Operation switch  {
            '+' => FirstOperand + SecondOperand,
            '-'=> FirstOperand - SecondOperand,
            '/' => FirstOperand / SecondOperand,
            '*' => FirstOperand * SecondOperand,
          };
          mathOperationsHistory.Add(mathOperation);     
        }
    }
  }
  catch(Exception ex){
    Console.WriteLine($"{ex.Message}");
  }
}

