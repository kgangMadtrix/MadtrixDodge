using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madtrix.Factories.Logging
{
    public class FileLoggerSingleton : BaseFileLogger
    {
        private FileLoggerSingleton()
        { 
        
        }

        public static FileLoggerSingleton Instance
        {
            get 
            {
                return Nested.instance;
            }
        }

        private class Nested
        {
            // tell c# not to mark as beforefiledinit
            static Nested()
            { 
            
            }

            internal static readonly FileLoggerSingleton instance = new FileLoggerSingleton();
        }
    }
}
