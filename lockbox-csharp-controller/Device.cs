using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lockbox_csharp_controller
{
    internal class Device
    {
        public Device(string name, String ip, int port)
        {
            Name = name;
            IP = ip;
            Port = port;
        }

        public String Name { get; private set; }
        public String IP { get; private set; }
        public int Port { get; private set; }

        public override string ToString()
        {
            return Name + " (" + IP + ":" + Port.ToString() + ")";
        }
    }
}
