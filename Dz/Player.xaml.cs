using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Threading;
using Microsoft.Win32;
using NAudio.Wave;

namespace Dz
{
    /*  Задание 2    
        Создайте 2 интерфейса IPlayable и IRecodable. В каждом из интерфейсов создайте по 3 метода void
        Play() / void Pause() / void Stop() и void Record() / void Pause() / void Stop() соответственно.
        Создайте производный класс Player от базовых интерфейсов IPlayable и IRecodable.
        Написать программу, которая выполняет проигрывание и запись 
    */
    public interface IPlayable
    {
        void Play();
        void Pause();
        void Stop();
        void Rewind(double percent);
        event EventHandler<PlayerEventArgs> OnTick;
    }

    public interface IRecordable
    {
        void Record();
        void Pause();
        void Stop();
        event EventHandler<TimeSpan> OnTick;
    }

    public class PlayerEventArgs : EventArgs
    {
        public double PercentProgress { get;}
        public TimeSpan Duration { get;}
        public TimeSpan PlayedTime { get;}

        public PlayerEventArgs(double percentProgress, TimeSpan duration, TimeSpan playedTime)
        {
            PercentProgress = percentProgress;
            Duration = duration;
            PlayedTime = playedTime;
        }
    }

    public class Player : MediaElement, IPlayable
    {
        private readonly DispatcherTimer _timer = new DispatcherTimer();
        private double PercentProgress => Position.TotalSeconds * 100 / Duration.TotalSeconds;
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
        private readonly DispatcherTimer _recordTimer;
        private readonly WaveInEvent _recorder;
        private TimeSpan _recordTime;
        private readonly List<byte> _recordedData;

        public event EventHandler<TimeSpan> OnTick;

        public Recorder()
        {
            _recorder = new WaveInEvent{DeviceNumber = 0};

            //for (int i = 0; i < WaveIn.DeviceCount; i++)
            //{
            //    WaveInCapabilities deviceInfo = WaveInEvent.GetCapabilities(i);
            //    Console.WriteLine($"Device {i}: {deviceInfo.ProductName}, {deviceInfo.Channels} channels");
            //}
            _recordedData = new List<byte>();
            _recordTimer = new DispatcherTimer{ Interval = new TimeSpan(0, 0, 0, 0, 500) };
            _recordTimer.Tick += (o, e) =>
            {
                OnTick?.Invoke(this, _recordTime);
                _recordTime += _recordTimer.Interval;
            };
            _recorder.DataAvailable += (o, e) => _recordedData.AddRange(e.Buffer);
        }

        void IRecordable.Record()
        {
            _recordTimer.Start();
            _recorder.StartRecording();
        }
        void IRecordable.Pause()
        {
            _recordTimer.Stop();
            _recorder.StopRecording();
        }
        void IRecordable.Stop()
        {
            _recorder.StopRecording();

            if (_recordedData.Any())
            {
                string path = Path.GetTempFileName().Replace(".tmp", ".mp3");
                using (WaveFileWriter writer = new WaveFileWriter(path, _recorder.WaveFormat))
                {
                    writer.Write(_recordedData.ToArray(), 0, _recordedData.Count);
                    writer.Flush();
                }

                _recordedData.Clear();
                _recordTimer.Stop();
                _recordTime = new TimeSpan();
                OnTick?.Invoke(this, _recordTime);
                MessageBox.Show($"Файл сохранен по пути {path}");
            }
        }
    }

    public partial class PlayerRecorderWindow
    {
        private readonly IPlayable _player;
        private readonly IRecordable _recorder;
        private bool _isDragging;

        public PlayerRecorderWindow() : this(new Player(), new Recorder()) { }
        public PlayerRecorderWindow(IPlayable player, IRecordable recorder)
        {
            _recorder = recorder;
            _recorder.OnTick += (o, e) => LbRecord.Text = $"{e:mm\\:ss}";

            _player = player;
            _player.OnTick += (o, e) =>
            {
                if (!_isDragging)
                    Pb.Value = (int)(e.PercentProgress * 100);

                LbPlay.Text = $"{e.PlayedTime.Minutes:00}:{e.PlayedTime.Seconds:00}/{e.Duration.Minutes:00}:{e.Duration.Seconds:00}";
            };

            InitializeComponent();
        }

        private void btRecord_Click(object sender, EventArgs e) => _recorder.Record();
        private void btRecordPause_Click(object sender, EventArgs e) => _recorder.Pause();
        private void btRecordStop_Click(object sender, EventArgs e) => _recorder.Stop();

        private void btPlay_Click(object sender, EventArgs e) => _player.Play();
        private void btPlayPause_Click(object sender, EventArgs e) => _player.Pause();
        private void btPlayStop_Click(object sender, EventArgs e) => _player.Stop();

        private void pb_DragStarted(object sender, DragStartedEventArgs e) => _isDragging = true;
        private void pb_DragCompleted(object sender, DragCompletedEventArgs e)
        {
            _isDragging = false;
            _player.Rewind(Pb.Value / 100);
        }
    }
}