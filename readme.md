# AllJoyn-Lamp-Component
This project contains:
- an AllJoyn Component that discovers a Lifx Lamp via AllJoyn (implemnts LSF Framework by AllJoyn),
- an Beacon Light App which uses the AllJoyn Component above , which controls the Lifx Lamp automatically (on/off) via Bluetooth LE proximity depending on a user's device relative to bluetooth LE beacon. 
- an AllJoyn Light App as an example of how to use the AllJoyn Component ( control manually (on/off, color) via a flipview control a single Lifx Lamp.)

The AllJoynComponent Project has a relationship with the [dotMorten.AllJoyn.AllJoynClientLib] (https://github.com/dotMorten/AllJoynClientLib) Project.

The Beacon App uses the AllJoyn Componnet and the [Bluetooth Advertisement Apis of Windows 10 - we can start with the samples here or read the code of my app.](http://go.microsoft.com/fwlink/p/?LinkId=619990) .

You have to provide the DeviceID of your lamp in order to discover the lamp that you want to control
Add the string in line 36 of file [AllJoynDiscoveryService:] (https://github.com/niko-kokkinos/AllJoynComponent/blob/master/nikokkinos.AllJoynComponent/AllJoynDiscoveryService.cs) 

The AllJoyn Light App Project uses a Flipview control , with pre-defined colored lamps
- red
- green
- blue
- yellow
- white
- no color (transparent)

![A Figure of the App is shown here:] (https://github.com/niko-kokkinos/AllJoynComponent/blob/master/nikokokkinos.AllJoynLightApp/AppImages/all.png)

By selecting the desired colored Lamp , the user can tap on it and the color
of the Lamp will change in the room.

# HACKATHON BONN - RFID Lamp
A Version of the Light App Example and the AllJoyn Component in this Project are used by the RFID Lamp Project at the [Bonn Hackathon Event] (http://hackathon.codeforbonn.de/) .  

For more information about the RFID chips , Raspeberry Pi and the App for reading RFID chip data and control of the lifx lamp via AllJoyn  can be foud on [Wido Wirsam Github site](https://github.com/intui/RFID_Lamp_Demo) 

#### A Video Demonstration during the Event can be [found here](https://twitter.com/wido_w/status/749220061647429632)


# HACKATHON BONN - Bluetooth LE - iBeacon and Lifx Lamp
A Version of the Beacon App in this Project are developed with Students at the [Bonn Hackathon Event] (http://hackathon.codeforbonn.de/) .  
Since in was the first Contact with [BLE Windows Advertisement Api](https://msdn.microsoft.com/en-us/library/windows/apps/xaml/windows.devices.bluetooth.advertisement.aspx) 
we experimented with the functionality. On Github today you can find a full functional prototyp and working demo.  

In order to reproduce the functionality of Beacons with [AllJoyn](https://allseenalliance.org/framework) capable [Lamp](http://www.lifx.com/products/color-1000) , 
like [Lifx](http://www.lifx.com/products/color-1000), we used the followimng components:

- iPhone with the App installed [Estimote Beacons](http://developer.estimote.com/) . The iPhone with the Beacon App installed has the Role of the Beacon, the Transmitter of Advertisement Packets in  the room. 
You get the [app for free here](https://itunes.apple.com/WebObjects/MZStore.woa/wa/viewSoftware?id=686915066&mt=8)
A video of how to use the app can be [watched here](https://community.estimote.com/hc/en-us/articles/200908836-How-to-turn-my-iPhone-into-a-Virtual-Beacon-) 

- Windows Surface Pro. This Device has the Role of the Receiver of advertisement packets from Beacon (iPhone Device with Estimote App) and the Role of the [Consumer in Context of AllJoyn](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/AllJoyn/ConsumerExperiences).

- A [Lifx Lamp Color 1000](http://www.lifx.com/products/color-1000). It has the Role of the [AllJoyn Producer](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/AllJoyn/ProducerExperiences). 
Implements the [LSF Framework](https://allseenalliance.org/announcement/allseen-alliance-launches-initiative-advance-smart-lighting) from [Allseen Alliance](https://allseenalliance.org/framework).  

####As an inspiration on how to use the App you can watch an example  video with almost the same functionality [here](https://www.youtube.com/watch?v=d6K9zkH9hw0)

If you want to use the Hue Lights , Microsoft already provided a sample app . Technologies used : Bluetooth LE , Hue Phillips, iBeacon. Sample can be found [here](https://github.com/Microsoft/Windows-appsample-huelightcontroller)
