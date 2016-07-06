// **************************************************************************** 
// <author>Niko Kokkinos</author> 
// <email>nik.kokkinos@outlook.com</email> 
// <date>02.07.2016</date> 
// <project>nikokokkinos.BeaconLightApp</project> 
// <web>http://nikolaoskokkinos.wordpress.com/</web> 
// ****************************************************************************

using System;
using System.Linq;

namespace nikokokkinos.BeaconLightApp
{
    public static class Utils
    {
        public static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

    }
}
