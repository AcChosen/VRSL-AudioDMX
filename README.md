# VRSL-AudioDMX
 A standalone add-on for VR Stage Lighting that enables sending basic DMX data through audio signals into VRChat's Udon.

DMX via Audio refers to the new feature set released as a standalone add-on to VRSL that allows users to send DMX data through extra surround sound audio channels in a 5.1-enabled stream to control udon sharp scripts across multiple instances. The feature uses a very rudimentary version of amplitude modulation to convert DMX signals into different audio signals that can be detected as simple boolean (On/Off) states. It can either send 8 or 12 bits/booleans of DMX data.

The basic idea of this system is that DMX data is converted into simple wave forms at different frequencies that unity can detect. Those wave forms are sent down unused surround sound audio channels through a stream. The video player in VRChat then sends those signals to an audio source component where the data is processed into an udon script, where variables and functions can be appropriately called based on the changes of those wave forms.

As this addon is standalone, it does *not* need the full installation of VRSL into a unity project for it to work properly. The add-on .unitypackage file alone will suffice. It still will need, however, the VRSL Grid Node in order to generate the signals from DMX into their appropriate audio signals.

If you want to watch this tutorial in video format, you can watch it [here.](https://youtu.be/dDLCTZjOWro)

More information here:
https://github.com/AcChosen/VR-Stage-Lighting/wiki/VRSL-DMX:-DMX-via-Audio
