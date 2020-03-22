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
            while (!Keyboard.IsKeyDown(Key.Escape))
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
                    frequency = 261.63;
                    play_key = true;
                }
                if (Keyboard.IsKeyDown(Key.S))
                {
                    // play note or set flag to play note
                    Console.WriteLine($"Key pressed: S");
                    frequency = 293.66;
                    play_key = true;
                }
                if (Keyboard.IsKeyDown(Key.D))
                {
                    // play note or set flag to play note
                    Console.WriteLine($"Key pressed: D");
                    frequency = 329.63;
                    play_key = true;
                }
                if (Keyboard.IsKeyDown(Key.F))
                {
                    // play note or set flag to play note
                    Console.WriteLine($"Key pressed: F");
                    frequency = 349.23;
                    play_key = true;
                }
                if (Keyboard.IsKeyDown(Key.Y))
                {
                    // play note or set flag to play note
                    Console.WriteLine($"Key pressed: Y");
                    frequency = 392.00;
                    play_key = true;
                }
                if (Keyboard.IsKeyDown(Key.X))
                {
                    // play note or set flag to play note
                    Console.WriteLine($"Key pressed: X");
                    frequency = 440.00;
                    play_key = true;
                }
                if (Keyboard.IsKeyDown(Key.C))
                {
                    // play note or set flag to play note
                    Console.WriteLine($"Key pressed: C");
                    frequency = 493.88;
                    play_key = true;
                }
                if (play_key)
                {
                    ISampleProvider sineWave = generateWaveform(frequency, duration);
                    playTone(sineWave, ms_duration);
                    play_key = false;
                }
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
