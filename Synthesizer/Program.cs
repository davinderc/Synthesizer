using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Media;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace Synthesizer
{
    class Program
    {
        static void Main(string[] args)
        {
            SoundPlayer player = new SoundPlayer();
            int frequency = 440;
            double duration = 0.5;
            var sineWave = new SignalGenerator()
            {
                Gain = 0.1,
                Frequency = frequency,
                Type = SignalGeneratorType.Sin
            }.Take(TimeSpan.FromSeconds(duration));

            using (var waveOut = new WaveOutEvent())
            {
                waveOut.Init(sineWave);
                waveOut.Play();
                while (waveOut.PlaybackState == PlaybackState.Playing)
                {
                    Thread.Sleep(1000);
                }
            }
        }

        private static void generateWaveform(float frequency)
        {
            throw new NotImplementedException();
        }

        private static void playTone(List<float> waveform)
        {
            throw new NotImplementedException();
        }
    }
}
