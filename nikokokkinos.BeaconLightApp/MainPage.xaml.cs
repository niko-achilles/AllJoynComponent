// **************************************************************************** 
// <author>Niko Kokkinos</author> 
// <email>nik.kokkinos@outlook.com</email> 
// <date>02.07.2016</date> 
// <project>nikokokkinos.BeaconLightApp</project> 
// <web>http://nikolaoskokkinos.wordpress.com/</web> 
// ****************************************************************************

using nikokkinos.AllJoynComponent;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Bluetooth.Advertisement;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Streams;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace nikokokkinos.BeaconLightApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        private BluetoothLEAdvertisementWatcher watcher;
        private nikokkinos.AllJoynComponent.AllJoynController controller;

        private Windows.UI.Color WHITE = Windows.UI.Colors.White;
        private Windows.UI.Color RED = Windows.UI.Colors.Red;
        private Windows.UI.Color BLUE = Windows.UI.Colors.Blue;
        private Windows.UI.Color GREEN = Windows.UI.Colors.Green;
        private Windows.UI.Color YELLOW = Windows.UI.Colors.Yellow;
        private Windows.UI.Color TRANSPARENT = Windows.UI.Colors.Transparent;

        private CoreDispatcher _dispatcher;

        public MainPage()
        {
            this.InitializeComponent();

            _dispatcher = CoreWindow.GetForCurrentThread().Dispatcher;

            watcher = new BluetoothLEAdvertisementWatcher();

            var dataHelper = new DataHelper()
                                .WriteBytes(Utils.
                                            StringToByteArray(
                                            "02158492E75F4FD6469DB132043FE94921D805B715BEC5"));
             
            //0x4C00 (2 Bytes) -> manu ID : Apple - Virtual estimote  //0x015D -> manu ID for real Estimote
            //02 (1 Byte)-> Data Type
            //15 (! Byte) -> Number of bytes to follow (21)

            //(21 Bytes) 8492E75F 4FD6 469D B132 043FE94921D8 05B7 15BE C5 (payload) "02 15 84 92E75F4F D6469DB1 3204 3FE9 4921 D805B715BEC5"
            //UUID fixed beacon 8492E75F 4FD6 469D B132 043FE94921D8
            //0587 -> iBeacon Major Big Endian
            //15BE -> iBeacon Minor Big Endian
            //C5 -> final byte rssi when beacon 1 meter away
             

            watcher.AdvertisementFilter.Advertisement.ManufacturerData.Add(dataHelper.ManufactureData);

            watcher.SignalStrengthFilter.InRangeThresholdInDBm = -65;
            watcher.SignalStrengthFilter.OutOfRangeThresholdInDBm = -70;

            watcher.SignalStrengthFilter.OutOfRangeTimeout = TimeSpan.FromSeconds(2);
            watcher.SignalStrengthFilter.SamplingInterval = TimeSpan.FromSeconds(1);

            watcher.Received += OnWatcherReceived;

            this.Loaded += OnPageLoaded;
            

        }

        private void OnPageLoaded(object sender, RoutedEventArgs e)
        {

            controller = new AllJoynController();
            controller.StartDiscovery();

            watcher.Start();
        }

        private async void SetFlipViewStateAsync(Windows.UI.Color color)
        {

            await _dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                this.bulb.Fill = new SolidColorBrush(color);
            });
        }
        

        private async void OnWatcherReceived(BluetoothLEAdvertisementWatcher sender, BluetoothLEAdvertisementReceivedEventArgs args)
        {

            if (args.RawSignalStrengthInDBm == -127)
            {
                controller.SetLampOnOff(false);
                this.SetFlipViewStateAsync(this.TRANSPARENT);

            }
            else
            {
                controller.SetLampOnOff(true);
                controller.SetLampColor(this.WHITE);
                this.SetFlipViewStateAsync(this.YELLOW);
            }

            #region Beacon Specific Code and Comments
            //args
            //fisrt 2 Bytes is UUID in 16bit
            //next 6 bytes is BLE Adress
            //nexz´t byte uis RSSi
            //next 2 bytes iBeacon Major
            //next 2 Bytes iBeacon minor

            //var blAd = args.BluetoothAddress; //138212835556783
            //var rssi = args.RawSignalStrengthInDBm;
            //var adType = args.AdvertisementType; //is 2?? connectable undirected is 1 (from zero counting 1)



            //string manufacturerDataString = "";
            //var manufacturerSections = args.Advertisement.ManufacturerData;
            //if (manufacturerSections.Count > 0)
            //{
            //    // Only print the first one of the list 
            //    var manufacturerDataSec = manufacturerSections[0];
            //    var manData = new byte[manufacturerDataSec.Data.Length];
            //    using (var reader = DataReader.FromBuffer(manufacturerDataSec.Data))
            //    {
            //        reader.ReadBytes(manData);
            //    }

            //    var payload = BitConverter.ToString(manData);

            //    // Print the company ID + the raw data in hex format 
            //    manufacturerDataString = string.Format("0x{0}: {1}",
            //        manufacturerDataSec.CompanyId.ToString("X"),
            //        BitConverter.ToString(manData));
            //}

            //string uuidString = "";
            //var uuids = args.Advertisement.ServiceUuids;

            //if (uuids.Count > 0)//->is 0
            //{
            //    foreach (var uuid in uuids)
            //    {
            //        uuidString = uuidString + uuid.ToString() + "+";
            //    }
            //}

            //var dataSections = args.Advertisement.DataSections;
            //if (dataSections.Count>0)
            //{
            //    var dataSec0 = args.Advertisement.DataSections[0];

            //    var data0 = new byte[dataSec0.Data.Length];
            //    using (var reader = DataReader.FromBuffer(dataSec0.Data))
            //    {
            //        reader.ReadBytes(data0);
            //    }

            //    var dataString0 = BitConverter.ToString(data0); //-> !A

            //    var dataSec1 = args.Advertisement.DataSections[1];

            //    var data1 = new byte[dataSec1.Data.Length];
            //    using (var reader = DataReader.FromBuffer(dataSec1.Data))
            //    {
            //        reader.ReadBytes(data1);
            //    }

            //    var dataString1 = BitConverter.ToString(data1);
            #endregion
        }

    }
}
