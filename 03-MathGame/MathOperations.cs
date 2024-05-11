namespace MathGame;

public class MathOperations
{
  public int Operand_1 {get;set;}
  public int Operand_2 {get;set;}
  public char Operation {get;set;}
  public int result {get;set;}

  public bool AcceptDivisionRules()
  {
    if(Operand_1 % Operand_2 != 0)
      return false;
    else if (result > 100 || result < 0)
      return false;
    return true;
  }
}