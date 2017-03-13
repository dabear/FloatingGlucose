using System.Linq;
using System.Text;
using NAudio.Wave;
using System;
using System.Diagnostics;
using System.IO;
using static FloatingGlucose.Properties.Settings;

namespace FloatingGlucose.Classes
{
    public class SoundAlarm : IDisposable
    {
        private static readonly SoundAlarm instance = new SoundAlarm();

        private bool disposed;
        private IWavePlayer device = new WaveOut();

        private readonly Mp3FileReader glucoseAlarm = new Mp3FileReader(new MemoryStream(Properties.Resources.alarm));
        private readonly Mp3FileReader staleAlarm = new Mp3FileReader(new MemoryStream(Properties.Resources.alarm2));

        private bool isCurrentlyPlaying = false;

        private DateTime? postponed;

        public DateTime? GetPostponedUntil() => this.postponed;

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static SoundAlarm()
        {
        }

        private SoundAlarm()
        {
        }

        public static SoundAlarm Instance
        {
            get
            {
                return instance;
            }
        }

        public void RemovePostpone()
        {
            this.postponed = null;
        }

        public void PostponeAlarm(int minutes)
        {
            var now = DateTime.Now;
            var postponeUntil = now.AddMinutes(minutes);

            this.postponed = postponeUntil;
            Debug.WriteLine($"Postponed any audible alarms until {postponeUntil.ToLocalTime()}");
            if (this.isCurrentlyPlaying)
            {
                this.StopAlarm();
            }
        }

        public bool IsPostponed()
        {
            if (this.postponed == null)
            {
                return false;
            }

            var now = DateTime.Now;
            return this.postponed > now;
        }

        public void PlayAlarm(Mp3FileReader fileReader)
        {
            if (this.isCurrentlyPlaying || !Default.EnableAlarms || !Default.EnableSoundAlarms)
            {
                // We don't want to play if there is already other players active
                // even if the other players are playing other alarms..
                return;
            }
            //alarms should not be sound if actively snoozed or workstation is locked
            if (this.IsPostponed() || (AppShared.IsWorkStationLocked && Default.DisableSoundAlarmsOnWorkstationLock))
            {
                return;
            }

            var loop = new LoopStream(fileReader);
            device.Init(loop);
            device.Play();
            this.isCurrentlyPlaying = true;
        }

        public void PlayStaleAlarm()
        {
            this.PlayAlarm(staleAlarm);
        }

        public void StopAlarmIfPostponed()
        {
            if (this.IsPostponed())
            {
                this.StopAlarm();
            }
        }

        public void StopAlarm()
        {
            this.device.Stop();
            this.isCurrentlyPlaying = false;
            staleAlarm.CurrentTime =
            glucoseAlarm.CurrentTime = new TimeSpan(0);
        }

        public void PlayGlucoseAlarm()
        {
            this.PlayAlarm(glucoseAlarm);
        }

        /// <summary>
        /// The dispose method that implements IDisposable.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// The virtual dispose method that allows
        /// classes inherited from this one to dispose their resources.
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Dispose managed resources here.
                }

                this.device.Dispose();
                this.device = null;
            }

            disposed = true;
        }

        ~SoundAlarm()
        {
            this.Dispose(false);
        }
    }
}