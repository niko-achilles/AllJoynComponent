using nikokkinos.AllJoynComponent;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using widoniko.AllJoynRFIDLampApp.RFIDServices;
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

namespace widoniko.AllJoynRFIDLampApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
        public sealed partial class MainPage : Page
        {
            RFIDscheduler RFIDreader;
            AllJoynController controller;

            bool lightingInterfaceFound = false;

            public MainPage()
            {
                this.InitializeComponent();
                this.Loaded += OnPageLoaded;
                //RFIDreader.myText = messenger;
            }

        private void OnPageLoaded(object sender, RoutedEventArgs e)
        {
            controller = new AllJoynController();

        }

        private void RFIDreader_RFID_TagChanged(object sender, TagIdChangedEventArgs e)
        {
                messenger.Text = "read:" + e.TagId;
            switch (e.TagId)
            {
                case "774bc3fe":
                    //messenger.Foreground = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 255, 0, 0));

                    controller.SetLampColor(Windows.UI.Color.FromArgb(255, 255, 0, 0));
                    break;

                case "29e0b3cb":
                    //messenger.Foreground = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 0, 255, 0));

                    controller.SetLampColor(Windows.UI.Color.FromArgb(255, 0, 255, 0));
                    break;

                case "774b86be":
                    //messenger.Foreground = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 0, 0, 255));

                    controller.SetLampColor(Windows.UI.Color.FromArgb(255, 0, 0, 255));
                    break;

                case "6f7e6792":
                    //messenger.Foreground = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 0, 0, 255));

                    controller.SetLampColor(Windows.UI.Color.FromArgb(255, 0, 0, 255));
                    break;

                case "9e06d26e":
                    //messenger.Foreground = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 188, 188, 0));

                    controller.SetLampColor(Windows.UI.Color.FromArgb(255, 188, 188, 0));
                    break;

                default:
                    messenger.Foreground = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 0, 0, 0));

                    controller.SetLampColor(Windows.UI.Color.FromArgb(255, 255, 255, 255));
                    break;
            }
        }

            protected override async void OnNavigatedTo(NavigationEventArgs e)
            {
                base.OnNavigatedTo(e);

            RFIDreader = new RFIDscheduler();
            RFIDreader.RFID_TagChanged += RFIDreader_RFID_TagChanged;
            await RFIDreader.Start();


        }
            protected override void OnNavigatedFrom(NavigationEventArgs e)
            {
                base.OnNavigatedFrom(e);
                RFIDreader.Stop();
            }

            private void blueButtonClicked(object sender, RoutedEventArgs e)
            {
                controller.SetLampColor(Windows.UI.Color.FromArgb(255, 0, 0, 255));
            }

            private void redButtonClicked(object sender, RoutedEventArgs e)
            {
                controller.SetLampColor(Windows.UI.Color.FromArgb(255, 255, 0, 0));
            }

            private void greenButtonClicked(object sender, RoutedEventArgs e)
            {
                controller.SetLampColor(Windows.UI.Color.FromArgb(255, 0, 255, 0));
            }

            private void yellowButtonClicked(object sender, RoutedEventArgs e)
            {
                controller.SetLampColor(Windows.UI.Color.FromArgb(255, 188, 188, 0));
            }

            private void whiteButtonClicked(object sender, RoutedEventArgs e)
            {
                controller.SetLampColor(Windows.UI.Color.FromArgb(255, 255, 255, 255));
            }

        }
    }
