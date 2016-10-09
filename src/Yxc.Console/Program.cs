using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Newtonsoft.Json;
using Yxc.Entities.v1;

namespace Yxc.Console
{
    class Program
    {
        private static bool IsRunning = true;

        static void Main(string[] args)
        {


            string myBaseAddress = "http://192.168.0.3/YamahaExtendedControl/v1";

            Thread myThread = new Thread(ReceiveUdpEvent) {IsBackground = true};
            myThread.Start();

            using (WebClient myWebClient = new WebClient())
            {
                myWebClient.Headers.Add("X-AppName", "MusicCast/1.50(iOS)");
                myWebClient.Headers.Add("X-AppPort", "41100");
                // 4.1
                using (var myStream = myWebClient.OpenRead(myBaseAddress + "/system/getDeviceInfo"))
                {
                    if (myStream != null)
                    {
                        var myBuffer = new byte[4096];
                        int nRead = myStream.Read(myBuffer, 0, myBuffer.Length);
                        string myString = Encoding.UTF8.GetString(myBuffer, 0, nRead);
                        var x = JsonConvert.DeserializeObject<Yxc.Entities.v1.System.GetDeviceInfo>(myString);
                    }
                }
                // 4.2
                using (var myStream = myWebClient.OpenRead(myBaseAddress + "/system/getFeatures"))
                {
                    if (myStream != null)
                    {
                        var myBuffer = new byte[4096];
                        int nRead = myStream.Read(myBuffer, 0, myBuffer.Length);
                        string myString = Encoding.UTF8.GetString(myBuffer, 0, nRead);
                        var x = JsonConvert.DeserializeObject<Yxc.Entities.v1.System.GetFeatures>(myString);
                    }
                }
                // 4.3
                using (var myStream = myWebClient.OpenRead(myBaseAddress + "/system/getNetworkStatus"))
                {
                    if (myStream != null)
                    {
                        var myBuffer = new byte[4096];
                        int nRead = myStream.Read(myBuffer, 0, myBuffer.Length);
                        string myString = Encoding.UTF8.GetString(myBuffer, 0, nRead);
                        var x = JsonConvert.DeserializeObject<Yxc.Entities.v1.System.GetNetworkStatus>(myString);
                    }
                }
                // 4.4
                using (var myStream = myWebClient.OpenRead(myBaseAddress + "/system/getFuncStatus"))
                {
                    if (myStream != null)
                    {
                        var myBuffer = new byte[4096];
                        int nRead = myStream.Read(myBuffer, 0, myBuffer.Length);
                        string myString = Encoding.UTF8.GetString(myBuffer, 0, nRead);
                        var x = JsonConvert.DeserializeObject<Yxc.Entities.v1.System.GetFuncStatus>(myString);
                    }
                }
                // 4.5 setAutoPowerStandby 
                // 4.6 
                using (var myStream = myWebClient.OpenRead(myBaseAddress + "/system/getLocationInfo"))
                {
                    if (myStream != null)
                    {
                        var myBuffer = new byte[4096];
                        int nRead = myStream.Read(myBuffer, 0, myBuffer.Length);
                        string myString = Encoding.UTF8.GetString(myBuffer, 0, nRead);
                        var x = JsonConvert.DeserializeObject<Yxc.Entities.v1.System.GetLocationInfo>(myString);
                    }
                }
                // 4.6 sendIrCode
                // 5.1
                string myZone = "main";
                using (var myStream = myWebClient.OpenRead(myBaseAddress + $"/{myZone}/getStatus"))
                {
                    if (myStream != null)
                    {
                        var myBuffer = new byte[4096];
                        int nRead = myStream.Read(myBuffer, 0, myBuffer.Length);
                        string myString = Encoding.UTF8.GetString(myBuffer, 0, nRead);
                        var x = JsonConvert.DeserializeObject<Yxc.Entities.v1.Zone.GetStatus>(myString);
                    }
                }
                // 5.2
                using (var myStream = myWebClient.OpenRead(myBaseAddress + $"/{myZone}/getSoundProgramList"))
                {
                    if (myStream != null)
                    {
                        var myBuffer = new byte[4096];
                        int nRead = myStream.Read(myBuffer, 0, myBuffer.Length);
                        string myString = Encoding.UTF8.GetString(myBuffer, 0, nRead);
                        var x = JsonConvert.DeserializeObject<Yxc.Entities.v1.Zone.GetSoundProgramList>(myString);
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
                        var myBuffer = new byte[4096];
                        int nRead = myStream.Read(myBuffer, 0, myBuffer.Length);
                        string myString = Encoding.UTF8.GetString(myBuffer, 0, nRead);
                        var x = JsonConvert.DeserializeObject<Yxc.Entities.v1.Tuner.GetPresetInfo>(myString);
                    }
                }
                // 6.2
                using (var myStream = myWebClient.OpenRead(myBaseAddress + $"/tuner/getPlayInfo"))
                {
                    if (myStream != null)
                    {
                        var myBuffer = new byte[4096];
                        int nRead = myStream.Read(myBuffer, 0, myBuffer.Length);
                        string myString = Encoding.UTF8.GetString(myBuffer, 0, nRead);
                        var x = JsonConvert.DeserializeObject<Yxc.Entities.v1.Tuner.GetPlayInfo>(myString);
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
                        var myBuffer = new byte[4096];
                        int nRead = myStream.Read(myBuffer, 0, myBuffer.Length);
                        string myString = Encoding.UTF8.GetString(myBuffer, 0, nRead);
                        var x = JsonConvert.DeserializeObject<Yxc.Entities.v1.Netusb.GetPresetInfo>(myString);
                    }
                }

            }

            System.Console.WriteLine("Press any key to quit");
            System.Console.ReadKey();
            IsRunning = false;
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
