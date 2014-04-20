using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madtrix.Factories
{
    class SingletonFileLoggerFactory : IFileLoggerFactory
    {
        public Logging.IFileLogger Create()
        {
            throw new NotImplementedException();
        }
    }
}
