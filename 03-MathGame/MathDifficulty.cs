namespace MathGame;

internal class MathDifficulty
{
    Random random = new Random();

    internal void MakeEasy(out int operand_1, out int operand_2, char operation)
    {
        if(operation == '/')
        {
            operand_1 = random.Next(1, 99);
            operand_2 = random.Next(1, 99);
            while(operand_1 % operand_2 != 0)
            {
              operand_1 = random.Next(1, 99);
              operand_2 = random.Next(1, 99);
            }
        }
        else
        {
          operand_1 = random.Next(1, 9);
          operand_2 = random.Next(1, 9);
        }
    }

    internal void MakeMedium(out int operand_1, out int operand_2, char operation)
    {
        if(operation == '/')
        {
            operand_1 = random.Next(100, 999);
            operand_2 = random.Next(100, 999);
            while(operand_1 % operand_2 != 0)
            {
              operand_1 = random.Next(100, 999);
              operand_2 = random.Next(100, 999);
            }
        }
        else
        {
          operand_1 = random.Next(10, 99);
          operand_2 = random.Next(10, 99);
        }
    }
    
    internal void MakeHard(out int operand_1, out int operand_2, char operation)
    {
        if(operation == '/')
        {
            operand_1 = random.Next(1000, 9999);
            operand_2 = random.Next(1000, 9999);
            while(operand_1 % operand_2 != 0)
            {
              operand_1 = random.Next(1000, 9999);
              operand_2 = random.Next(1000, 9999);
            }
        }
        else
        {
          operand_1 = random.Next(100, 999);
          operand_2 = random.Next(100, 999);
        }
    }
}