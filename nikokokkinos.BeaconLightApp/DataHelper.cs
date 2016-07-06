using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.Devices.Bluetooth.Advertisement;

namespace nikokokkinos.BeaconLightApp
{
    public class DataHelper
    {
        public BluetoothLEManufacturerData ManufactureData { get; private set; } = new BluetoothLEManufacturerData { CompanyId = 0x4C };

        public DataHelper WriteBytes(byte[] data)
        {
            using (var writer = new DataWriter())
            {
                writer.WriteBytes(data);
                this.ManufactureData.Data = writer.DetachBuffer();
            }

            return this;
        }
        
    }
}
