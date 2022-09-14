##Eyetracker API Changelog

(1.0.73)
- Added simple session logging to Unity SDK. Logmode and profile name can be specified in the EyeTrackerAPI object.

(1.0.72)
- Updated Unity SDK to support new changes to adhawk backend including new stream toggling protocols
- Added support for backend events, mainly blink events

(1.0.45)
- Updated package manifest

(1.0.44)
- Added MRTK device prefab for hololens support
- Retargetted evk3 device serial to MRTK as assumed device

(1.0.43)
- Updated for our 4.0/5.0+ eyetracking api
- Lots of fixes and improvements
- Added DeviceManager/Player for optional multi-device compatability at runtime
- Added Documentation

(1.0.0)
- Major clean-up

(0.10.01)
- fixed bug where frontend couldn't be started before backend
- fixation detection is now optional and defaults to off
- blink detection algorithm reverted. New scanners are A+ great at never losing tracking, so
  we've gone back to simply detecting when we've lost tracking for the blink threshold.
- Fixed some other bugs mostly relevant to developers in UDPBehaviour and UDPCommHandler

(0.9.47)
- Fixation detection calibration added to the default built-in calibration

(0.9.46)
- Fixation detection more accurate
- New blink detection algorithm added which is much more stable and accurate

(0.9.45)
- Added EyeTrackerAPI.Instance.StopCancelCalibration()

(0.9.44)
- Added FixationDuration as a publically accessable API member (float)
- Added the latest GlintPositions[12] as a publically accessable API member (Vector2[12])
- glint positions x and y are set to 0 if no recent glints have been added.

(0.9.43)
- Fixation detection improved
- Fixed a type bug that caused problems with toggling stream controls

(0.9.42)
- Added Fixation detection when glint stream is enabled
- use EyeTrackerAPI.Instance.StartUncalibratedGlintStream() and EyeTrackerAPI.Instance.StopUncalibratedClintStream()
  and EyeTrackerAPI.Instance.GlintMoveDeltasAverage, which is provided as a raw number that represents the average change in 
  x and y of the glint positions. Anything over 1.0 is probably movement, and anything below that is probably fixated state.
  This is not mandated because these values might change from person to person, but is a good average starting point and will
  probably work.


(0.9.37)
- Glint stream included

(0.9.35)
- better error message returns, now properly handles timeout error message.
- minor bugfixes and a couple string changes

(0.9.31)
- fixed autotune request to actually wait for acknowledgement
- adjusted autotune wait timeout to 6 seconds
- fixed an uneccesary delay while running autotune.

(0.9.28)
- added log to register error handler for calibration points

(0.9.27)
- Register error handler now works

(0.9.26)
- Added stub method for detecting uncalibrated tracking state

(0.9.25)
- Stream control will now send an explicitly 32-bit long byte array, streamControlMap is now copied into it
- Some updates to udpInfo

(0.9.24)
- Autotune request waits until tracker-ready to finish yeild and return finished.

(0.9.23)
- fixed some prefab filenames to not hold a random rogue character that was crashing unity.

(0.9.22)
- config.ini no longer mandatory, but recommended.

(0.9.21)
- Removed some old debugging code
- Added the ability to change built-in calibration vertical offset

(0.9.20)
- Screenspace tracking somewhat working and in development.
    - requires config.ini to exist.

(0.9.16)
- testing screenspace-compatible eyetracking

(0.9.15)
- Can now set angle spread and blink threshold in EyeTrackerAPI inspector as serialized variables.

(0.9.13)
- When using simulatedWithMouse, left click will simulate tracking lost (i.e. for blinks.)

(0.9.12)
- Simulating eyetracking with mouse now appropriately removes camera rotation from the gaze vector.

(0.9.11)
- Fixed OnBlink to invoke on UI elements as well when using GazeEventSystem
- Fixed GazeEventSystem blink event tracking to to work properly and added editor debug support.
- Calibration target indicates error with calibration point.
- Fixed a bug with animation causing calibration target to not position properly.

(0.9.4)
- Fixed problem with built-in calibration prefab not applying.
- Fixed blink not working (blink timer was never reset)
- Calibration dot now uses always on top shader material.

(0.9.1)
- Built-in calibration now uses a little white dot instead of a target.

(0.9.0)
- Added new calibration functions and functionality to EyeTrackerAPI.
- Renamed EyeTrackerAPI.Instance.RunCalibrationSession() to EyeTrackerAPI.Instance.RunBuiltInCalibration()
    - this is because, moving forward, calibration setup will be more exposed to the dev using EyeTrackerApi
      so that calibrations can be customised and built in-app if required.
- Revamped the interface to create and send UDPRequests (To do with UDPRequest.cs)
    - the whole thing is now based around coroutines - it waits for timeouts and/or runs a callback with the
      result and data returned if ack was recieved.
    - Greatly reduced the amount of code needed to send a UDP request.
- Fixed built-in default API calibration to be a bit more accurate and functional in VR.
    - Now uses Camera.main - assuming that if things are simple and the user just wants a quick working calibration session,
      then they wont mind being limited to using Camera.main as the default camera.

(0.8.10)
- updated script metadata

(0.8.9)
- Register Validation Point now has a callback in the function argument (can be set to null).
    - This is only called during the acknowledgement callback in the generated UDPRequest.
- RegisterCalibrationPoint now has a callback in the function argument (can be set to null).
    - This is only called during the acknowledgement callback in the generated UDPRequest.
- Changed HandleGazeData in EyeTrackerAPI to function a little better, now using a buffer for gaze data that supports both the old and new gaze data stream formats. (i.e. 12 bytes as a vector3 or 16 bytes as a timestamp and vector3)

(0.8.8)
- Register Validation point functionality added to EyeTrackerAPI.
- Added new general method to the api internally: 'Couroutine SendUDPRequest and wait for ack'
  this is simply a "fire and wait" that logs an error on failure, and finishes when an ack is recieved or timeout is hit.

(0.8.7)
- Documentation improvements in EyeTrackerAPI
- Added RegisterValidationPoint functions to EyeTrackerAPI
- Improved Vector3 byte conversions optimization in UDPRequest
- Improved Documentation in UDPRequest
- UDPRequest now actively checks to see if backend exists.

(0.8.6)
- More tweaks to calibration handler object
- calibration handler is deleted after calibration is completed.

(0.8.4)
- Moved calibration markers in for fixed-point calibration.

(0.8.3)
- Fixed calibration to send inverted-z position for target markers.

(0.8.2)
- Upgrade to Calibration service to be a little more functional and useful
    - Calibration dots now wait until around 0.5 seconds before moving after confirming the point to prevent catastrophe
    - VOR calibration is sort of implemented

(0.8.0)
- EyeTracking works with backend!

(0.7.25)
- fixed GazeOrigin in EyeTrackerAPI. Now returns Camera.main.transform.position.

(0.7.24)
- Updated Initialize stream endpoint to use the udpclient in charge of control data rather than the udp client in charge of handling streaming data.

(0.7.23)
- Updated UDPBehaviour to register endpoint properly by sending the data streaming port number rather than an empty byte array.

(0.7.22)
- Updated target obj mesh file to not conflict with current projects since it's a copy.

(0.7.21)
- Removed unused folder

(0.7.20)
- Fixed LastRegisteredCalPointSuccess not having the proper value during calibration session.
- Added meta files for documentation

(0.7.18)
- Renamed Changelog.txt to Changelog.md so that UPM can recognize it.

(0.7.17)
- Change `EyeTrackerAPI.Instance.GetGazeVectorOnScreen` from Vector2 to Vector3.

(0.7.16)
- Added `EyeTrackerAPI.Instance.GetGazeVectorOnScreen` utility function.

(0.6.4)
- Updated EyeTrackerAPI to no longer require camera. 
- New GazeInput script that should be added to cameras, and sends gaze events. (duplicated gaze events are disabled by default)
