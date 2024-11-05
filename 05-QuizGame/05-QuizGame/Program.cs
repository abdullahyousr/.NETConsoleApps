using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;

string[] questions = new string[3]
{
    "What is the capital of Italy?",
    "What is the red planet ?",
    "Waht is the largest animal"
};

string[] answers = new string[3]
{
    "Rome",
    "Mars",
    "Whale"
};
int correctAnswers = 0;

Console.WriteLine("Welcome to the game");
Console.WriteLine("----------------------");
Console.WriteLine("Please Answer the following questions");

for(int i = 0; i < questions.Length; i++)
{
    Console.WriteLine(questions[i]);

    string userAnswer = Console.ReadLine()!;
    try
    {
        bool asnwer = IsTheAnswerCorrect(userAnswer, answers[i]);

        if(asnwer)
        {
            Console.WriteLine("Correct Answer !");
            correctAnswers++;
        }
        else
        {
            Console.WriteLine($"Sorry, Incorrect Answer, The correct answer is {answers[i]}");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

Console.WriteLine($"Your Score is {correctAnswers} of {answers.Length}");
Console.WriteLine("Quiz Completed. ");

static bool IsTheAnswerCorrect(string userInput, string correctAnswer)
{
    if(string.IsNullOrEmpty(userInput))
    {
        throw new Exception("Answer can't be Empty");
    }

    if(userInput == correctAnswer)
    {
        return true;
    }
    else
    {
        return false;
    }
}