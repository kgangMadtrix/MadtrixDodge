using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Madtrix.Factories.Logging;

namespace Madtrix.Factories
{
    /// <summary>
    /// This is the IFileLoggerFactory interface.
    /// </summary>
    public interface IFileLoggerFactory
    {
        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>IFileLogger</returns>
        IFileLogger Create();
    }
}
