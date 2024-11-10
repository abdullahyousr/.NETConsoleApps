using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextDataAnalyzer.Models
{
    internal class CSVFileAnalyzer : FileAnalyzer, IFileAnalyzer
    {
        public void AnalyzeFile(FileInfo fileInfo)
        {
            string[] fileText = File.ReadAllLines(fileInfo.FullName);

            AnalysisResults results = new AnalysisResults();

            string[] fileFields = fileText[0].Split(',');

            results.FieldCount = fileFields.Length;

            SetAnalysisResults(results);
        }
    }
}
