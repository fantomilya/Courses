using Microsoft.Win32;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Dz
{
    public class PlayerEventArgs : EventArgs
    {
        public double PercentProgress { get; private set; }
        public TimeSpan Duration { get; private set; }
        public TimeSpan PlayedTime { get; private set; }

        public PlayerEventArgs(double percentProgress, TimeSpan duration, TimeSpan playedTime)
        {
            PercentProgress = percentProgress;
            Duration = duration;
            PlayedTime = playedTime;
        }
    }
    public class Player : MediaElement, IPlayable
    {
        DispatcherTimer _timer = new DispatcherTimer();
        double PercentProgress => (Position.TotalSeconds * 100 / Duration.TotalSeconds);
        public TimeSpan Duration => NaturalDuration.HasTimeSpan ? NaturalDuration.TimeSpan : new TimeSpan();

        public event EventHandler<PlayerEventArgs> OnTick;

        public Player()
        {
            _timer.Tick += (o, e) => OnTick?.Invoke(this, new PlayerEventArgs(PercentProgress, Duration, Position));
            LoadedBehavior = MediaState.Manual;
            UnloadedBehavior = MediaState.Manual;
        }


        void IPlayable.Play()
        {
            if (Source == null)
            {
                OpenFileDialog fd = new OpenFileDialog();
                if (fd.ShowDialog() == true)
                    Source = new Uri(fd.FileName);
                else
                    return;
            }
            Play();
            _timer.Start();
        }
        void IPlayable.Pause()
        {
            Pause();
            _timer.Stop();
        }
        void IPlayable.Stop()
        {
            _timer.Stop();
            Stop();
            Source = null;
            OnTick?.Invoke(this, new PlayerEventArgs(PercentProgress, Duration, Position));
        }
        void IPlayable.Rewind(double percent) => Position = new TimeSpan((long)(Duration.Ticks * percent / 100));
    }
    public class Recorder : IRecordable
    {
        DispatcherTimer recordTimer;
        WaveInEvent recorder;
        TimeSpan recordTime;
        List<byte> recordedData;

        public event EventHandler<TimeSpan> OnTick;

        public Recorder()
        {
            recorder = new WaveInEvent();
            recordedData = new List<byte>();
            recordTimer = new DispatcherTimer() { Interval = new TimeSpan(0, 0, 0, 0, 500) };
            recordTimer.Tick += (o, e) =>
            {
                OnTick?.Invoke(this, recordTime);
                recordTime += recordTimer.Interval;
            };
            recorder.DataAvailable += (o, e) => recordedData.AddRange(e.Buffer);
        }

        public void Record()
        {
            recordTimer.Start();
            recorder.StartRecording();
        }
        void IRecordable.Pause()
        {
            recordTimer.Stop();
            recorder.StopRecording();
        }
        void IRecordable.Stop()
        {
            recorder.StopRecording();

            if (recordedData.Any())
            {
                string path = System.IO.Path.GetTempFileName().Replace(".tmp", ".mp3");
                using (var writer = new WaveFileWriter(path, recorder.WaveFormat))
                {
                    writer.Write(recordedData.ToArray(), 0, recordedData.Count);
                    writer.Flush();
                }

                MessageBox.Show($"Файл сохранен по пути {path}");
                recordedData.Clear();
                recordTimer.Stop();
                recordTime = new TimeSpan();
                OnTick?.Invoke(this, recordTime);
            }
        }
    }
    public partial class PlayerRecorderWindow : Window
    {
        IPlayable _player;
        IRecordable _recorder;
        bool isDragging = false;

        public PlayerRecorderWindow() : this(new Player(), new Recorder()) { }
        public PlayerRecorderWindow(IPlayable player, IRecordable recorder)
        {
            _recorder = recorder;
            _recorder.OnTick += (o, e) => lbRecord.Content = $"{e.ToString(@"mm\:ss")}";

            _player = player;
            _player.OnTick += (o, e) =>
            {
                if (!isDragging)
                    pb.Value = (int)(e.PercentProgress * 100);

                lbPlay.Content = $"{e.PlayedTime.Minutes:00}:{e.PlayedTime.Seconds:00}/{e.Duration.Minutes:00}:{e.Duration.Seconds:00}";
            };

            InitializeComponent();
        }

        private void btRecord_Click(object sender, EventArgs e) => _recorder.Record();
        private void btRecordPause_Click(object sender, EventArgs e) => _recorder.Pause();
        private void btRecordStop_Click(object sender, EventArgs e) => _recorder.Stop();

        private void btPlay_Click(object sender, EventArgs e) => _player.Play();
        private void btPlayPause_Click(object sender, EventArgs e) => _player.Pause();
        private void btPlayStop_Click(object sender, EventArgs e) => _player.Stop();

        private void pb_DragStarted(object sender, System.Windows.Controls.Primitives.DragStartedEventArgs e) => isDragging = true;
        private void pb_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            isDragging = false;
            _player.Rewind(pb.Value / 100);
        }

    }
}
