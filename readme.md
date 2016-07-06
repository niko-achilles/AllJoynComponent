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
