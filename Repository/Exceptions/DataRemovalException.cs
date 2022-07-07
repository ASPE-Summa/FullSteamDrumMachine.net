using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullSteamDrumMachine.net.Repository.Exceptions
{
    internal class DataRemovalException : Exception
    {
        public DataRemovalException() { }

        public DataRemovalException(string message) : base(message) { }
    }
}
