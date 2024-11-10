using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextDataAnalyzer.Models
{
    public class TextFileAnalyzer : FileAnalyzer, IFileAnalyzer 
    {
        public void AnalyzeFile(FileInfo fileInfo)
        {
            string fileText = File.ReadAllText(fileInfo.FullName);

            AnalysisResults results = new AnalysisResults();

            string[] fileWords = fileText.Split(new char[] {' ', '\n', '\r'});
            results.WordCount = fileWords.Length;
            results.CharacterCount = fileText.Length;
            results.LineCount = fileText.Split(new char[] {'\n'}).Length;
            
            SetAnalysisResults(results);
        }
    }
}
