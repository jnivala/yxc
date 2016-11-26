using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Rssdp;
using Yxc.Entities.v1;

namespace Yxc.Console
{
    class Program
    {
        private static bool IsRunning = true;
        private static SsdpDeviceLocator _DeviceLocator;

        static void Main(string[] args)
        {
            //SearchForDevices().Wait();

            string myBaseAddress = "http://192.168.0.3/YamahaExtendedControl/v1";

            //Thread myThread = new Thread(ReceiveUdpEvent) { IsBackground = true };
            //myThread.Start();

            _DeviceLocator = new SsdpDeviceLocator();

            // (Optional) Set the filter so we only see notifications for devices we care about 
            // (can be any search target value i.e device type, uuid value etc - any value that appears in the 
            // DiscoverdSsdpDevice.NotificationType property or that is used with the searchTarget parameter of the Search method).
            _DeviceLocator.NotificationFilter = "upnp:rootdevice";

            // Connect our event handler so we process devices as they are found
            _DeviceLocator.DeviceAvailable += deviceLocator_DeviceAvailable;
            _DeviceLocator.DeviceUnavailable += _DeviceLocator_DeviceUnavailable;

            // Enable listening for notifications (optional)
            _DeviceLocator.StartListeningForNotifications();

            // Perform a search so we don't have to wait for devices to broadcast notifications 
            // again to get any results right away (notifications are broadcast periodically).
            DiscoveredSsdpDevice[] ret = _DeviceLocator.SearchAsync().Result.ToArray();

            System.Console.WriteLine($"SSDP found {ret.Length} device(s).");

            ExecuteGet(myBaseAddress);

            System.Console.WriteLine("Press any key to quit");
            System.Console.ReadKey();
            IsRunning = false;
        }

        private static void _DeviceLocator_DeviceUnavailable(object sender, DeviceUnavailableEventArgs e)
        {
            
        }

        private async static void deviceLocator_DeviceAvailable(object sender, DeviceAvailableEventArgs e)
        {
            //Device data returned only contains basic device details and location of full device description.
            System.Console.WriteLine("Found " + e.DiscoveredDevice.Usn + " at " + e.DiscoveredDevice.DescriptionLocation.ToString());

            //Can retrieve the full device description easily though.
            var fullDevice = await e.DiscoveredDevice.GetDeviceInfo();
            System.Console.WriteLine(fullDevice.FriendlyName);
            System.Console.WriteLine();
        }

        //public static async Task SearchForDevices()
        //{
        //    // This code goes in a method somewhere.
        //    using (var deviceLocator = new SsdpDeviceLocator())
        //    {
        //        var foundDevices = await deviceLocator.SearchAsync(); // Can pass search arguments here (device type, uuid). No arguments means all devices.

        //        var x = foundDevices.ToArray();

        //        foreach (var foundDevice in x)
        //        {
        //            // Device data returned only contains basic device details and location ]
        //            // of full device description.
        //            System.Console.WriteLine("Found " + foundDevice.Usn + " at " + foundDevice.DescriptionLocation.ToString());

        //            // Can retrieve the full device description easily though.
        //            var fullDevice = await foundDevice.GetDeviceInfo();
        //            System.Console.WriteLine(fullDevice.FriendlyName);
        //            System.Console.WriteLine();
        //        }
        //    }
        //}

        private static void ExecuteGet(string myBaseAddress)
        {
            int nBuffer = 1024*16;

            using (WebClient myWebClient = new WebClient())
            {
                myWebClient.Headers.Add("X-AppName", "MusicCast/1.50(iOS)");
                myWebClient.Headers.Add("X-AppPort", "41100");
                // 4.1
                using (var myStream = myWebClient.OpenRead(myBaseAddress + "/system/getDeviceInfo"))
                {
                    if (myStream != null)
                    {
                        var myBuffer = new byte[nBuffer];
                        int nRead = myStream.Read(myBuffer, 0, myBuffer.Length);
                        string myString = Encoding.UTF8.GetString(myBuffer, 0, nRead);
                        var x = JsonConvert.DeserializeObject<Yxc.Entities.v1.System.GetDeviceInfoResponse>(myString);
                    }
                }
                // 4.2
                using (var myStream = myWebClient.OpenRead(myBaseAddress + "/system/getFeatures"))
                {
                    if (myStream != null)
                    {
                        var myBuffer = new byte[nBuffer];
                        int nRead = myStream.Read(myBuffer, 0, myBuffer.Length);
                        string myString = Encoding.UTF8.GetString(myBuffer, 0, nRead);
                        var x = JsonConvert.DeserializeObject<Yxc.Entities.v1.System.GetFeaturesResponse>(myString);
                    }
                }
                // 4.3
                using (var myStream = myWebClient.OpenRead(myBaseAddress + "/system/getNetworkStatus"))
                {
                    if (myStream != null)
                    {
                        var myBuffer = new byte[nBuffer];
                        int nRead = myStream.Read(myBuffer, 0, myBuffer.Length);
                        string myString = Encoding.UTF8.GetString(myBuffer, 0, nRead);
                        var x = JsonConvert.DeserializeObject<Yxc.Entities.v1.System.GetNetworkStatusResponse>(myString);
                    }
                }
                // 4.4
                using (var myStream = myWebClient.OpenRead(myBaseAddress + "/system/getFuncStatus"))
                {
                    if (myStream != null)
                    {
                        var myBuffer = new byte[nBuffer];
                        int nRead = myStream.Read(myBuffer, 0, myBuffer.Length);
                        string myString = Encoding.UTF8.GetString(myBuffer, 0, nRead);
                        var x = JsonConvert.DeserializeObject<Yxc.Entities.v1.System.GetFuncStatusResponse>(myString);
                    }
                }
                // 4.5 setAutoPowerStandby 
                // 4.6 
                using (var myStream = myWebClient.OpenRead(myBaseAddress + "/system/getLocationInfo"))
                {
                    if (myStream != null)
                    {
                        var myBuffer = new byte[nBuffer];
                        int nRead = myStream.Read(myBuffer, 0, myBuffer.Length);
                        string myString = Encoding.UTF8.GetString(myBuffer, 0, nRead);
                        var x = JsonConvert.DeserializeObject<Yxc.Entities.v1.System.GetLocationInfoResponse>(myString);
                    }
                }
                // 4.6 sendIrCode
                // 5.1
                string myZone = "main";
                using (var myStream = myWebClient.OpenRead(myBaseAddress + $"/{myZone}/getStatus"))
                {
                    if (myStream != null)
                    {
                        var myBuffer = new byte[nBuffer];
                        int nRead = myStream.Read(myBuffer, 0, myBuffer.Length);
                        string myString = Encoding.UTF8.GetString(myBuffer, 0, nRead);
                        var x = JsonConvert.DeserializeObject<Yxc.Entities.v1.Zone.GetStatusResponse>(myString);
                    }
                }
                // 5.2
                using (var myStream = myWebClient.OpenRead(myBaseAddress + $"/{myZone}/getSoundProgramList"))
                {
                    if (myStream != null)
                    {
                        var myBuffer = new byte[nBuffer];
                        int nRead = myStream.Read(myBuffer, 0, myBuffer.Length);
                        string myString = Encoding.UTF8.GetString(myBuffer, 0, nRead);
                        var x = JsonConvert.DeserializeObject<Yxc.Entities.v1.Zone.GetSoundProgramListResponse>(myString);
                    }
                }
                // 5.3 setPower
                // 5.4 setSleep
                // 5.5 setVolume
                // 5.6 setMute
                // 5.7 setInput
                // 5.8 setSoundProgram
                // 5.9 prepareInputChange
                // 6.1
                string myBand = "common";
                using (var myStream = myWebClient.OpenRead(myBaseAddress + $"/tuner/getPresetInfo?band={myBand}"))
                {
                    if (myStream != null)
                    {
                        var myBuffer = new byte[nBuffer];
                        int nRead = myStream.Read(myBuffer, 0, myBuffer.Length);
                        string myString = Encoding.UTF8.GetString(myBuffer, 0, nRead);
                        var x = JsonConvert.DeserializeObject<Yxc.Entities.v1.Tuner.GetPresetInfoResponse>(myString);
                    }
                }
                // 6.2
                using (var myStream = myWebClient.OpenRead(myBaseAddress + $"/tuner/getPlayInfo"))
                {
                    if (myStream != null)
                    {
                        var myBuffer = new byte[nBuffer];
                        int nRead = myStream.Read(myBuffer, 0, myBuffer.Length);
                        string myString = Encoding.UTF8.GetString(myBuffer, 0, nRead);
                        var x = JsonConvert.DeserializeObject<Yxc.Entities.v1.Tuner.GetPlayInfoResponse>(myString);
                    }
                }
                // 6.3 setFreq
                // 6.4 recallPreset
                // 6.5 switchPreset
                // 6.6 storePreset
                // 6.7 setDabService 
                // 7.1
                using (var myStream = myWebClient.OpenRead(myBaseAddress + $"/netusb/getPresetInfo "))
                {
                    if (myStream != null)
                    {
                        var myBuffer = new byte[nBuffer];
                        int nRead = myStream.Read(myBuffer, 0, myBuffer.Length);
                        string myString = Encoding.UTF8.GetString(myBuffer, 0, nRead);
                        var x = JsonConvert.DeserializeObject<Yxc.Entities.v1.Netusb.GetPresetInfoResponse>(myString);
                    }
                }
                // 7.2
                using (var myStream = myWebClient.OpenRead(myBaseAddress + $"/netusb/getPlayInfo "))
                {
                    if (myStream != null)
                    {
                        var myBuffer = new byte[nBuffer];
                        int nRead = myStream.Read(myBuffer, 0, myBuffer.Length);
                        string myString = Encoding.UTF8.GetString(myBuffer, 0, nRead);
                        var x = JsonConvert.DeserializeObject<Yxc.Entities.v1.Netusb.GetPlayInfoResponse>(myString);
                    }
                }
                // 7.3 setPlayback 
                // 7.4 toggleRepeat 
                // 7.5 toggleShuffle 
                // 7.6 Inserted an USB stick with MP3 albums in folders.
                using (
                    var myStream = myWebClient.OpenRead(myBaseAddress + $"/netusb/getListInfo?input=usb&index=0&size=8&lang=en")
                    )
                {
                    if (myStream != null)
                    {
                        var myBuffer = new byte[nBuffer];
                        int nRead = myStream.Read(myBuffer, 0, myBuffer.Length);
                        string myString = Encoding.UTF8.GetString(myBuffer, 0, nRead);
                        var x = JsonConvert.DeserializeObject<Yxc.Entities.v1.Netusb.GetListInfoResponse>(myString);
                    }
                }
                // 7.7 setListControl 
                // 7.8 setSearchString 
                // 7.9 recallPreset 
                // 7.10 storePreset 
                // 7.11
                using (var myStream = myWebClient.OpenRead(myBaseAddress + $"/netusb/getAccountStatus"))
                {
                    if (myStream != null)
                    {
                        var myBuffer = new byte[nBuffer];
                        int nRead = myStream.Read(myBuffer, 0, myBuffer.Length);
                        string myString = Encoding.UTF8.GetString(myBuffer, 0, nRead);
                        var x = JsonConvert.DeserializeObject<Yxc.Entities.v1.Netusb.GetAccountStatusResponse>(myString);
                    }
                }
                // 7.12 switchAccount 
                // 7.13 getServiceInfo 
                // 8.1
                using (var myStream = myWebClient.OpenRead(myBaseAddress + $"/cd/getPlayInfo"))
                {
                    if (myStream != null)
                    {
                        var myBuffer = new byte[nBuffer];
                        int nRead = myStream.Read(myBuffer, 0, myBuffer.Length);
                        string myString = Encoding.UTF8.GetString(myBuffer, 0, nRead);
                        var x = JsonConvert.DeserializeObject<Yxc.Entities.v1.Cd.GetPlayInfoResponse>(myString);
                    }
                }
                // 8.2 setPlayback 
                // 8.3 toggleTray 
                // 8.4 toggleRepeat 
                // 8.5 toggleShuffle 
            }
        }

        private static void ReceiveUdpEvent()
        {
            var myClient= new UdpClient(41100);
            IPEndPoint myRemoteIpEndPoint = new IPEndPoint(IPAddress.Parse("192.168.0.3"), 0);
            while (IsRunning)
            {
                Byte[] receiveBytes = myClient.Receive(ref myRemoteIpEndPoint);
                string myString = Encoding.UTF8.GetString(receiveBytes);
                var z = JsonConvert.DeserializeObject<EventData>(myString);
                System.Console.WriteLine($"{DateTime.Now} {myString}");
            }
        }        
    }    
}
