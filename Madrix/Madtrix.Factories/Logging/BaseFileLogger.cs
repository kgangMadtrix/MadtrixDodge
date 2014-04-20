using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madtrix.Factories.Logging
{
    public class BaseFileLogger:IFileLogger
    {
        public string FilePath { get; set; }

        public void LogToFile(string value)
        {
            throw new NotImplementedException();
        }

        public void CloseFile()
        {
            throw new NotImplementedException();
        }

        
    }
}
