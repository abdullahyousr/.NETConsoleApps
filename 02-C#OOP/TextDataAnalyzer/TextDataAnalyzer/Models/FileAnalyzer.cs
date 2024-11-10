using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextDataAnalyzer.Models
{
    public class FileAnalyzer
    {
        private AnalysisResults _results;

        public AnalysisResults GetAnalysisResults() 
        { 
            return _results; 
        }
        public void SetAnalysisResults(AnalysisResults results)
        {
            _results = results;
        }
    }
}
