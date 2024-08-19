# ClevoFanControl

基于[djsubtronic/ClevoFanControl](https://github.com/djsubtronic/ClevoFanControl)的项目修改，下载地址: [蓝奏云](https://a01.lanzout.com/i2Qd127wjbah)

![img0](https://fastly.jsdelivr.net/gh/lalakii/ClevoFanControl@master/pic.jpg)

A custom fan control control app for Clevo laptops. The fan icon is borrowed from the Obsidian Fan Control app.

Currently the app is very basic. It has 10 preset temperature units. Under 40 C, the fans will automatically be set to 0. Anything 40 through to 85 can be configured at 5 C intervals. It only uses two fans (1 for CPU and 2 for GPU) but I'm sure this can be easily modified.

**Disclaimer**

- Please remember that this is very much a work in progress which I just quickly put together in one day for my own use and sharing here so other developers can work with it or users can play around with it. Be careful when using it as a permament fan control solution, I am not responsible for any damage caused by any malfunctioning of the app.

**Important Notes**

- 2 fans supported at the moment
- Uses ClevoEcInfo.dll for fan control which relies on NTPort 2.8 library (included in release download - the installer might give an error but it should still work. Thanks @philstopford.)
- Uses OpenHardwareMonitor library for GPU temperature
- Uses WMI for CPU temperature
- No average temperatures, the fan speed is simply set immediately depending on CPU or GPU temperature and the configured temperature for that range
- No ramping speeds, the fan speed changes instantly
- The "Clevo Default" profile is just a profile I have created within the code that mimics Clevo's default fan curve for my model (exception being that <40 C will still turn the fans off). It is NOT handing control back to the EC, and the fans are still always controlled by the application until you exit.
- I'm not sure the code to hand over fan control back to the EC upon exit, so as a safety precaution if you exit the app it will automatically set the fans to 100%. You can use Fn+1 to go back to EC controlled fan after the app has closed.
- If GPU exceed 80 C, both CPU and GPU fans will automatically be set to 100%
- Needs to be run as Admin for CPU temperature detection to work
- NTPort library might give you an error message during the installation, but this can be ignored as the driver will still be installed

**Download Precompiled Releases**

All releases can be found on the project release page: https://github.com/djsubtronic/ClevoFanControl/releases

**Installation**

1. Download and install the NTPort driver from here: https://github.com/djsubtronic/ClevoFanControl/blob/master/ClevoFanControl/NTPortDrvSetup.exe
2. Download the latest release from the project release page, extract to a folder of your choice. The app will start minimised in the notification area.
