using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using System.Threading;
using System.Media;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace Synthesizer
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            // TODO: Read keyboard inputs in non-blocking manner
            SoundPlayer player = new SoundPlayer();
            double frequency = 440;
            double duration = 0.5;
            int ms_duration = Convert.ToInt32(duration * 1000);
            bool play_key = false;
            if (Keyboard.IsKeyDown(Key.A))
            {
                // play note or set flag to play note
                Console.WriteLine($"Key pressed: A");
                play_key = true;
            }
            if (play_key)
            {
                ISampleProvider sineWave = generateWaveform(frequency, duration);
                playTone(sineWave, ms_duration);
                play_key = false;
            }
            if (Keyboard.IsKeyDown(Key.Escape))
            {
                return;
            }
            
        }

        private static ISampleProvider generateWaveform(double frequency, double duration)
        {
            ISampleProvider sineWave = new SignalGenerator()
            {
                Gain = 0.1,
                Frequency = frequency,
                Type = SignalGeneratorType.Sin
            }.Take(TimeSpan.FromSeconds(duration));
            return sineWave;
        }

        private static void playTone(ISampleProvider sineWave, int duration)
        {
            using (var waveOut = new WaveOutEvent())
            {
                waveOut.Init(sineWave);
                waveOut.Play();
                while (waveOut.PlaybackState == PlaybackState.Playing)
                {
                    Thread.Sleep(duration);
                }
            }
        }
    }
}
