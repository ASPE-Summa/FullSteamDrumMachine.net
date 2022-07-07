using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullSteamDrumMachine.net.Repository.Exceptions
{
    internal class DataPersistanceException : Exception
    {
        public DataPersistanceException() { }

        public DataPersistanceException(string message) : base(message) { }

        public DataPersistanceException(string message, Exception innerException) : base(message, innerException) { }
    }
}
