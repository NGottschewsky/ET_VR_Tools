# Intention recognition during tool use with eye tracking in VR

A virtual reality experiment to investigate the influence of tool knowledge on anticipatory eye fixations, using eye tracking with HTC VIVE Pro Eye VR headset with Tobii eye tracking.

# Prerequisites

SteamVR, [ViveSR plugin from the Vive Eye Tracking SDK (SRanipal)](https://developer.vive.com/resources/vive-sense/sdk/vive-eye-tracking-sdk-sranipal/)

# Calibration

Before the experiment, the virtual table needs to be calibrated based on the height, width and depth of the real table with the help of the HTC VIVE controllers.
Eye tracking calibration is performed automatically with the ViveSR calibration procedure with 5 point calibration, validation is performed with a custom method also using five-point calibration and calculating a validation error for the x, y and z axis respectively. In case of a validation error greater than one for one or more of the three axes, another calibration and validation sequence are started. 

# Vive Eye Tracking SDK notice

Distribution of the plugins in object code form is permitted via the SDK license agreement. Running the code as provided here will collect facial feature data of the user for the purpose of eye tracking and the eye tracking data will be stored on the user's local machine.

# API Licenses

The SteamVR Unity plugin is licensed under the BSD 3-Clause "New" or "Revised" License.
