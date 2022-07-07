using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullSteamDrumMachine.net.Repository.Exceptions
{
    internal class DataRetrievalException : Exception
    {
        public DataRetrievalException()
        {
        }

        public DataRetrievalException(string message)
            : base(message)
        {
        }

        public DataRetrievalException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
