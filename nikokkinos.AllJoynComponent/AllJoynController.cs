// ****************************************************************************
// <author>Niko Kokkinos</author> 
// <email>nik.kokkinos@outlook.com</email> 
// <date>02.07.2016</date> 
// <project>nikokokkinos.AllJoynComponent</project> 
// <web>http://nikolaoskokkinos.wordpress.com/</web> 
// ****************************************************************************

namespace nikokkinos.AllJoynComponent
{
    using Windows.UI;

    public class AllJoynController
    {
        private AllJoynDiscoveryService allJoynDiscoveryService;

        public AllJoynController()
        {
            allJoynDiscoveryService = new AllJoynDiscoveryService();
        }

        public void StartDiscovery()
        {
            allJoynDiscoveryService.Start();
        }

        public async void SetLampColor(Color color)
        {
            if (allJoynDiscoveryService.IsLifxLampPresent)
            {
                bool onOffState = await allJoynDiscoveryService.LifxLamp.LightClient.GetOnOffAsync();

                if (!onOffState)
                {
                    await allJoynDiscoveryService.LifxLamp.LightClient.SetOnOffAsync(true);
                }
                await allJoynDiscoveryService.LifxLamp.LightClient.SetColorAsync(color);
            }
        }

        public async void SetLampOnOff(bool value)
        {
            if (allJoynDiscoveryService.IsLifxLampPresent)
            {
                await allJoynDiscoveryService.LifxLamp.LightClient.SetOnOffAsync(value);
            }
            
        }
    }
}
