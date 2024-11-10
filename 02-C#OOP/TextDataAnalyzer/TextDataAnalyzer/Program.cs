using TextDataAnalyzer.Extensions;
using TextDataAnalyzer.Models;

Console.WriteLine("Please insert folder path");

string inputPath = Console.ReadLine()!;

DirectoryInfo directoryInfo = new DirectoryInfo(inputPath);

if(!directoryInfo.Exists)
{
    Console.WriteLine("Filder path does not exist.");
    return;
}

var fileNames = directoryInfo.GetFiles();
IFileAnalyzer fileAnalyzer = null;
foreach(var file in fileNames)
{
    if (file.IsTextFile())
    {
        fileAnalyzer = new TextFileAnalyzer();

        fileAnalyzer.AnalyzeFile(file);

        var results = ((FileAnalyzer)fileAnalyzer).GetAnalysisResults();

        Console.WriteLine($"{file.Name}");
        Console.WriteLine($"{results.WordCount}");
        Console.WriteLine($"{results.LineCount}");
        Console.WriteLine($"{results.CharacterCount}");
    }else if(file.IsCSVFile())
    {
        fileAnalyzer = new CSVFileAnalyzer();

        fileAnalyzer.AnalyzeFile(file);

        var results = ((FileAnalyzer)fileAnalyzer).GetAnalysisResults();

        Console.WriteLine($"{file.Name}");
        Console.WriteLine($"{results.FieldCount}");
    }
}
