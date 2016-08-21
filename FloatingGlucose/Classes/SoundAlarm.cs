using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio;
using NAudio.Wave;
using System.IO;

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
    class SoundAlarm : IDisposable
    {
        private bool disposed;
        private IWavePlayer device = new WaveOut();

        private Mp3FileReader glucoseAlarm = new Mp3FileReader(new MemoryStream(Properties.Resources.alarm));
        private Mp3FileReader staleAlarm = new Mp3FileReader(new MemoryStream(Properties.Resources.alarm2));

        private bool isCurrentlyPlaying = false;
        public void PlayStaleAlarm()
        {
            if (this.isCurrentlyPlaying) {
                // We don't want to play if there is already other players active
                // even if the other players are playing other alarms..
                return;
            }

            LoopStream loop = new LoopStream(staleAlarm);
            device.Init(loop);
            device.Play();
            this.isCurrentlyPlaying = true;
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
            if (this.isCurrentlyPlaying)
            {
                // We don't want to play if there is already other players active
                // even if the other players are playing other alarms..
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
