
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace widoniko.AllJoynRFIDLampApp.RFIDServices
{
    class RFIDscheduler
    {
        public DispatcherTimer RFIDtimer { get; set; }
        public TextBlock myText { get; set; }
        Mfrc522 mfrc;
        public event EventHandler<TagIdChangedEventArgs> RFID_TagChanged;

        public RFIDscheduler()
        {
            RFIDtimer = new DispatcherTimer();
            mfrc = new Mfrc522();
        }
        public async Task Start()
        {
            await Start(100);
        }

        public async Task Start(int delay)
        {
            await mfrc.InitIO();
            RFIDtimer.Interval = TimeSpan.FromMilliseconds(delay);
            RFIDtimer.Tick += RFIDtimer_Tick;
            RFIDtimer.Start();
        }
        public void Stop()
        {
            RFIDtimer.Stop();
            RFIDtimer.Tick -= RFIDtimer_Tick;
        }

        private void RFIDtimer_Tick(object sender, object e)
        {
            if (mfrc.IsTagPresent())
            {
                var uid = mfrc.ReadUid();
                // do callback to change Lamp color.
                if (!uid.ToString().Equals("00000000"))
                {
                    RFID_TagChanged(this, new TagIdChangedEventArgs(uid.ToString()));
                }
                /**
                if (myText != null && !uid.ToString().Equals("00000000"))
                {
                    myText.Text = uid.ToString();
                    switch (uid.ToString())
                    {
                        case "774bc3fe":
                            myText.Foreground = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 255, 0, 0));
                            break;
                        case "29e0b3cb":
                            myText.Foreground = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 0, 255, 0));
                            break;
                        case "774b86be":
                            myText.Foreground = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 0, 0, 255));
                            break;
                        case "6f7e6792":
                            myText.Foreground = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 0, 0, 255));
                            break;
                        case "9e06d26e":
                            myText.Foreground = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 188, 188, 0));
                            break;

                        default:
                            myText.Foreground = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 0, 0, 0));
                            break;
                    }
                }
                */
                mfrc.HaltTag();
            }
        }
    }

    public class TagIdChangedEventArgs
    {
        public TagIdChangedEventArgs(string tagId)
        {
            TagId = tagId;
        }
        public string TagId { private set; get; }
    }
}
