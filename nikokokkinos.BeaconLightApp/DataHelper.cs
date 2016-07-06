// **************************************************************************** 
// <author>Niko Kokkinos</author> 
// <email>nik.kokkinos@outlook.com</email> 
// <date>02.07.2016</date> 
// <project>nikokokkinos.BeaconLightApp</project> 
// <web>http://nikolaoskokkinos.wordpress.com/</web> 
// ****************************************************************************

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
