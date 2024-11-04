// Welcome user
// 1. Add Task
// 2. View all Tasks
// 3. Mark Task Complete
// 4. Remove Task
// 5. Exit

string[] tasks = new string[100];
int taskIndex = 0;

Console.WriteLine("Welcome to the task tracker");
Console.WriteLine("1. Add");
Console.WriteLine("2. View");
Console.WriteLine("3. Complete");
Console.WriteLine("4. Remove");
Console.WriteLine("5. Exit");

while (true)
{
    Console.WriteLine("Enter a number from 1 to 5");

    string userChoise = Console.ReadLine()!;

    switch(userChoise)
    {
        case "1": AddTask();
            break;
        case "2": ViewTasks();
            break;
        case "3": MarkTaskComplete();
            break;
        case "4": RemoveTask();
            break;
        case "5": Exit();
            break;
        default: Console.WriteLine("Enter a number from 1 to 5 ONLY");
            break;
    }
}

void Exit()
{
    Environment.Exit(0);
}

void RemoveTask()
{
    Console.Write("Enter task number: ");
    int taskId = Convert.ToInt32(Console.ReadLine());
    tasks[taskId] = string.Empty;
}

void MarkTaskComplete()
{
    Console.Write("Enter task number: ");
    int taskId = Convert.ToInt32(Console.ReadLine());
    tasks[taskId] += "--COMPLETED";
}

void ViewTasks()
{
    Console.WriteLine("Task List: ");
    for(int i = 0; i<taskIndex; i++)
    {
        Console.WriteLine($"{i + 1}. task title: {tasks[i]}");
    }
}

void AddTask()
{
    Console.Write("Enter A task: ");
    tasks[taskIndex] = Console.ReadLine()!;
    Console.WriteLine("Task Added");
    taskIndex++;
}