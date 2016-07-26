# FloatingGlucose
FloatingGlucose is a windows program aiming to display your current bloogsugars live on your desktop.

A transparent popup window will be displayed in the bottom right corner of your desktop, with your current blood glucose values fetched from your nightscout installation.

## Screenshot
![Image of Floating glucose in action](https://s32.postimg.org/madq0uj2d/floating_glucose.png)

## Installation
Download The .zip-file of the latest release, [which you can find here TODO](https://example.com/TODO) and extract it to some location under your root drive. I suggest extracting it to c:\glucose or similar.

(You can place it anywhere really.)


You should now have the following files extracted under c:\glucose:

```
 
 Length Name
------ ----
31232   FloatingGlucose.exe
2007    FloatingGlucose.exe.config
34304   FloatingGlucose.pdb
22696   FloatingGlucose.vshost.exe
1979    FloatingGlucose.vshost.exe.config
526336  Newtonsoft.Json.dll
523221  Newtonsoft.Json.xml
```

Now, please edit the file FloatingGlucose.exe.config and update the section FloatingGlucose.Properties.Settings and set the url to your nightscout installation.

![Example of changing your nightscout installation URL](https://s31.postimg.org/3vr2bvad7/glucose_settings.png)

## Running the program
After configuring the nightscout installation URL, double click on FloatingGlucose.exe to open the program.

## Hidden / Nice to Know features
* You can drag the window around and place it where you want to.
* To Exit the program, click the "BS:" text five times. A button marked "(Exit)" will show. Click this to close the program.

## Debugging
Having troubles with crashes or with the widget not updating? Please make sure you have enabled exception logging to stderr (in the configfile) then run the program from command line:

```bash
cd c:\glucose
glucose.exe 2> glucose_log.txt
```

Then open glucose_log.txt
