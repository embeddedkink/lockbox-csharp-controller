using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zeroconf;

namespace lockbox_csharp_controller
{
    internal class DeviceBrowser
    {
        public async Task<List<Device>> GetDevices()
        {
            IReadOnlyList<IZeroconfHost> results = await
                ZeroconfResolver.ResolveAsync("_ekilb._tcp.local.");
            List<Device> devices = new List<Device>();
            foreach (IZeroconfHost host in results)
            {
                devices.Add(new Device(host.DisplayName, host.IPAddresses[0], host.Services.ToArray()[0].Value.Port));
            }
            return devices;
        }
    }
}
