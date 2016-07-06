// **************************************************************************** 
// <author>Niko Kokkinos</author> 
// <email>nik.kokkinos@outlook.com</email> 
// <date>02.07.2016</date> 
// <project>nikokokkinos.AllJoynLightApp</project> 
// <web>http://nikolaoskokkinos.wordpress.com/</web> 
// ****************************************************************************

using nikokkinos.AllJoynComponent;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace nikokokkinos.AllJoynLightApp
{


    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private nikokkinos.AllJoynComponent.AllJoynController controller;

        private Windows.UI.Color WHITE = Windows.UI.Colors.White;
        private Windows.UI.Color RED = Windows.UI.Colors.Red;
        private Windows.UI.Color BLUE = Windows.UI.Colors.Blue;
        private Windows.UI.Color GREEN = Windows.UI.Colors.Green;
        private Windows.UI.Color YELLOW = Windows.UI.Colors.Yellow;

        public MainPage()
        {
            this.InitializeComponent();
            this.Loaded += OnPageLoaded;
        }

        private void OnPageLoaded(object sender, RoutedEventArgs e)
        {
            controller = new AllJoynController();
            controller.StartDiscovery();
        }

        private void SetLampColorToWhite()
        {
            controller.SetLampColor(WHITE);
        }

        private void SetLampColorToYellow()
        {
            controller.SetLampColor(YELLOW);
        }

        private void SetLampColorToBlue()
        {
            controller.SetLampColor(BLUE);
        }

        private void SetLampColorToGreen()
        {
            controller.SetLampColor(GREEN);
        }

        private void SetLampColorToRed()
        {
            controller.SetLampColor(RED);
        }

        private void FlipView_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Windows.UI.Xaml.Shapes.Path path = e.OriginalSource as Windows.UI.Xaml.Shapes.Path;

            if (path != null)
            {
                if (path.Name == "whiteBulb")
                {
                    this.SetLampColorToWhite();
                }
                else if (path.Name == "blueBulb")
                {
                    this.SetLampColorToBlue();
                }
                else if (path.Name == "greenBulb")
                {
                    this.SetLampColorToGreen();
                }
                else if (path.Name == "redBulb")
                {
                    this.SetLampColorToRed();
                }
                else if (path.Name == "yellowBulb")
                {
                    this.SetLampColorToYellow();
                }
                else if (path.Name == "offBulb")
                {
                    this.SetLampOff();
                }
                else
                {
                    //
                }
            }
        }

        private void SetLampOff()
        {
            this.controller.SetLampOnOff(false);
        }
    }
}
