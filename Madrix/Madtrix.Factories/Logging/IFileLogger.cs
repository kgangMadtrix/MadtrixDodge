using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madtrix.Factories.Logging
{
    public interface IFileLogger
    {
        

        void LogToFile(string value);

        void CloseFile();
    }
}
