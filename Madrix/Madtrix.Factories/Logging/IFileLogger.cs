using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madtrix.Factories.Logging
{
    /// <summary>
    /// This is the IFileLogger interface
    /// </summary>
    public interface IFileLogger
    {
        /// <summary>
        /// Logs to file.
        /// </summary>
        /// <param name="value">The value.</param>
        void LogToFile(string value);

        /// <summary>
        /// Closes the file.
        /// </summary>
        void CloseFile();
    }
}
