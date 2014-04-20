using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madtrix.Factories.Logging
{
    /// <summary>
    /// This is the FileLoggerSingleton class.
    /// </summary>
    public class FileLoggerSingleton : BaseFileLogger
    {
        /// <summary>
        /// Prevents a default instance of the <see cref="FileLoggerSingleton"/> class from being created.
        /// </summary>
        private FileLoggerSingleton()
        {         
        }

        public static FileLoggerSingleton Instance
        {
            get 
            {
                return Nested.Instance;
            }
        }

        /// <summary>
        /// This is the singleton Nested class.
        /// </summary>
        private class Nested
        {
            /// <summary>
            /// Initializes the <see cref="Nested"/> class.
            /// </summary>
            static Nested()
            {
                // tell c# not to mark as beforefiledinit  
            }

            /// <summary>
            /// The instance
            /// </summary>
            internal static readonly FileLoggerSingleton Instance = new FileLoggerSingleton();
        }
    }
}
