using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Madtrix.Factories.Logging;

namespace Madtrix.Factories
{
    /// <summary>
    /// This is the SingletonFileLoggerFactory class.
    /// </summary>
    public class SingletonFileLoggerFactory : IFileLoggerFactory
    {
        public Logging.IFileLogger Create()
        {
            return FileLoggerSingleton.Instance;
        }
    }
}
