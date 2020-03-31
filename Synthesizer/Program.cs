using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.IO;
using System.Threading;
using System.Windows.Input;
using System.Windows.Threading;

namespace Synthesizer
{
    public class AudioPlaybackEngine : IDisposable
    {
        private readonly IWavePlayer outputDevice;
        private readonly MixingSampleProvider mixer;

        public AudioPlaybackEngine(int sampleRate = 44100, int channelCount = 2)
        {
            outputDevice = new WaveOutEvent();
            mixer = new MixingSampleProvider(WaveFormat.CreateIeeeFloatWaveFormat(sampleRate, channelCount));
            mixer.ReadFully = true;
            outputDevice.Init(mixer);
            outputDevice.Play();
        }

        public void PlaySound(ISampleProvider note)
        {
            mixer.AddMixerInput(note);
        }

        public void Dispose()
        {
            outputDevice.Dispose();
        }
        public static readonly AudioPlaybackEngine Instance = new AudioPlaybackEngine(44100, 2);
    }

    public class KeyboardListener
    {
        public string lastKey;

        private void OnKeyDownHandler(object sender, KeyboardEventHandler e)
        {
            //if(e.)
        }
    }

    public class Synth
    {
        private int msDuration = 10;
        private double gain = 0.1;
        private ISampleProvider waveForm;

        public double Frequency { get; set; } = 440;
        public double Duration { get; set; } = 0.5;

        public Synth()
        {
            this.waveForm = new SignalGenerator()
            {
                Gain = this.gain,
                Frequency = this.Frequency,
                Type = SignalGeneratorType.Sin
            }.Take(TimeSpan.FromSeconds(this.Duration));

        }

        public void PlayTone()
        {
            AudioPlaybackEngine.Instance.PlaySound(this.waveForm);
        }

        public void GenerateWaveform()
        {
            var sineWave = new SignalGenerator()
            {
                Gain = this.gain,
                Frequency = this.Frequency,
                Type = SignalGeneratorType.Sin
            }.Take(TimeSpan.FromSeconds(this.Duration));
            this.waveForm = sineWave;
        }
    }
    class Program
    {
        [STAThread]
        static void Main()
        {
            var synth = new Synth();
            bool playKey = false;
            if (File.Exists("key_config.json"))
            {
                var configFileContent = File.ReadAllLines("key_config.json");
                //var jsonConfig = JsonParser.FromJson(configFileContent); // need to debug this
            }
            
            while (!Keyboard.IsKeyDown(Key.Escape))
            {
                // TODO: Read keyboard inputs in non-blocking manner
               if (Keyboard.IsKeyDown(Key.A))
                {
                    // play note or set flag to play note
                    Console.WriteLine("Key pressed: A");
                    synth.Frequency = 261.63;
                    playKey = true;
                }
                if (Keyboard.IsKeyDown(Key.S))
                {
                    // play note or set flag to play note
                    Console.WriteLine("Key pressed: S");
                    synth.Frequency = 293.66;
                    playKey = true;
                }
                if (Keyboard.IsKeyDown(Key.D))
                {
                    // play note or set flag to play note
                    Console.WriteLine("Key pressed: D");
                    synth.Frequency = 329.63;
                    playKey = true;
                }
                if (Keyboard.IsKeyDown(Key.F))
                {
                    // play note or set flag to play note
                    Console.WriteLine("Key pressed: F");
                    synth.Frequency = 349.23;
                    playKey = true;
                }
                if (Keyboard.IsKeyDown(Key.Y))
                {
                    // play note or set flag to play note
                    Console.WriteLine("Key pressed: Y");
                    synth.Frequency = 392.00;
                    playKey = true;
                }
                if (Keyboard.IsKeyDown(Key.X))
                {
                    // play note or set flag to play note
                    Console.WriteLine("Key pressed: X");
                    synth.Frequency = 440.00;
                    playKey = true;
                }
                if (Keyboard.IsKeyDown(Key.C))
                {
                    // play note or set flag to play note
                    Console.WriteLine("Key pressed: C");
                    synth.Frequency = 493.88;
                    playKey = true;
                }
                if (playKey)
                {
                    //ISampleProvider sineWave = GenerateWaveform(frequency, duration);
                    //PlayTone(sineWave, msDuration);
                    playKey = false;
                    synth.GenerateWaveform();
                    synth.PlayTone();
                }
            }            
        }
    }
}
