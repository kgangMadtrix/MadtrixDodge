using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Madtrix.Factories.Logging;

namespace Madtrix.Factories
{
    public interface IFileLoggerFactory
    {
        public IFileLogger Create();
    }
}
