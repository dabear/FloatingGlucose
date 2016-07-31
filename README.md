# FloatingGlucose
FloatingGlucose is a windows program aiming to display your current bloogsugars live on your desktop.

A transparent popup window will be displayed in the bottom right corner of your desktop, with your current blood glucose values fetched from your nightscout installation.

## Screenshot
![Image of Floating glucose in action](https://s32.postimg.org/madq0uj2d/floating_glucose.png)

## Installation
Download The Setup.exe of the latest release, [which you can find here](https://github.com/dabear/FloatingGlucose/releases/) and run it. You should normally just install it to the default directory which is C:\Program Files (x86)\FloatingGlucose. 


After installation, please edit the file FloatingGlucose.exe.config, locate the section FloatingGlucose.Properties.Settings and set the url to your nightscout installation.

![Example of changing your nightscout installation URL](https://s32.postimg.org/gmo1sg29h/glucose_settings.png)

## Running the program
After configuring the nightscout installation URL, double click on FloatingGlucose.exe to open the program.

## Hidden / Nice to Know features
* You can drag the window around and place it where you want to.
* You can toggle the visibility of the "exit" button eiter by clicking the "BS:" text five times or by setting the enable_startup_hide_exit_button value to True in the configuration.

## Debugging
Having troubles with crashes or with the widget not updating? Please make sure you have enabled exception logging to stderr (in the configfile) then run the program from command line:

```bash
cd c:\glucose
glucose.exe 2> glucose_log.txt
```

Then open glucose_log.txt
