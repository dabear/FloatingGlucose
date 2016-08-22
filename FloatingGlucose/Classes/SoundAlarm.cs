using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio;
using NAudio.Wave;
using System.IO;
using static FloatingGlucose.Properties.Settings;

namespace FloatingGlucose.Classes
{
    /// <summary>
    /// Stream for looping playback
    /// </summary>
    public class LoopStream : WaveStream
    {
        WaveStream sourceStream;

        /// <summary>
        /// Creates a new Loop stream
        /// </summary>
        /// <param name="sourceStream">The stream to read from. Note: the Read method of this stream should return 0 when it reaches the end
        /// or else we will not loop to the start again.</param>
        public LoopStream(WaveStream sourceStream)
        {
            this.sourceStream = sourceStream;
            this.EnableLooping = true;
        }

        /// <summary>
        /// Use this to turn looping on or off
        /// </summary>
        public bool EnableLooping { get; set; }

        /// <summary>
        /// Return source stream's wave format
        /// </summary>
        public override WaveFormat WaveFormat
        {
            get { return sourceStream.WaveFormat; }
        }

        /// <summary>
        /// LoopStream simply returns
        /// </summary>
        public override long Length
        {
            get { return sourceStream.Length; }
        }

        /// <summary>
        /// LoopStream simply passes on positioning to source stream
        /// </summary>
        public override long Position
        {
            get { return sourceStream.Position; }
            set { sourceStream.Position = value; }
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            int totalBytesRead = 0;

            while (totalBytesRead < count)
            {
                int bytesRead = sourceStream.Read(buffer, offset + totalBytesRead, count - totalBytesRead);
                if (bytesRead == 0)
                {
                    if (sourceStream.Position == 0 || !EnableLooping)
                    {
                        // something wrong with the source stream
                        break;
                    }
                    // loop
                    sourceStream.Position = 0;
                }
                totalBytesRead += bytesRead;
            }
            return totalBytesRead;
        }
    }
    public  class SoundAlarm : IDisposable
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

            if (this.isCurrentlyPlaying) {
                this.StopAlarm();
                
            }

        }

        public bool isPostponed() {

            if (this.postponed == null) {
                return false;
            }

            var now = DateTime.Now;
            return this.postponed > now;
        }


        public void PlayStaleAlarm()
        {
            if (this.isCurrentlyPlaying || !Default.EnableAlarms || !Default.EnableSoundAlarms)
            {
                // We don't want to play if there is already other players active
                // even if the other players are playing other alarms..
                return;
            }
            if(this.isPostponed())
            {
                return;
            }

            var loop = new LoopStream(staleAlarm);
            device.Init(loop);
            device.Play();
            this.isCurrentlyPlaying = true;
        }

        public void StopAlarmIfPostponed() {
            if (this.isPostponed())
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
            if (this.isCurrentlyPlaying || !Default.EnableAlarms || !Default.EnableSoundAlarms)
            {
                // We don't want to play if there is already other players active
                // even if the other players are playing other alarms..
                return;
            }
            if (this.isPostponed())
            {
                return;
            }

            var loop = new LoopStream(glucoseAlarm);
            
            this.device.Init(loop);
            this.device.Play();
            this.isCurrentlyPlaying = true;
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
        /// classes inherithed from this one to dispose their resources.
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
