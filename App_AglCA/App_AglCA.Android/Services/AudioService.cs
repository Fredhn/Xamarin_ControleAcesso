using Xamarin.Forms;
using Android.Media;
using System.Threading;
using App_AglCA.Services;
using App_AglCA.Droid;

[assembly: Dependency(typeof(AudioService))]

namespace App_AglCA.Droid
{
    public class AudioService : IAudio
    {
        ToneGenerator _toneGenerator;
        //Timer timer;
        bool isPlaying = false;

        public AudioService() { }

        #region IAudio

        public void DTMFPlayTone(string t, float reproduceSpeed)
        {
            if (!isPlaying)
            {
                _toneGenerator = new ToneGenerator(Android.Media.Stream.Dtmf, 100);

                isPlaying = true;

                switch (t)
                {
                    case "0":
                        _toneGenerator.StartTone(Tone.Dtmf0);
                        Thread.Sleep(int.Parse(reproduceSpeed.ToString()));
                        this.StopAudio();
                        break;
                    case "1":
                        _toneGenerator.StartTone(Tone.Dtmf1);
                        Thread.Sleep(int.Parse(reproduceSpeed.ToString()));
                        this.StopAudio();
                        break;
                    case "2":
                        _toneGenerator.StartTone(Tone.Dtmf2);
                        Thread.Sleep(int.Parse(reproduceSpeed.ToString()));
                        this.StopAudio();
                        break;
                    case "3":
                        _toneGenerator.StartTone(Tone.Dtmf3);
                        Thread.Sleep(int.Parse(reproduceSpeed.ToString()));
                        this.StopAudio();
                        break;
                    case "4":
                        _toneGenerator.StartTone(Tone.Dtmf4);
                        Thread.Sleep(int.Parse(reproduceSpeed.ToString()));
                        this.StopAudio();
                        break;
                    case "5":
                        _toneGenerator.StartTone(Tone.Dtmf5);
                        Thread.Sleep(int.Parse(reproduceSpeed.ToString()));
                        this.StopAudio();
                        break;
                    case "6":
                        _toneGenerator.StartTone(Tone.Dtmf6);
                        Thread.Sleep(int.Parse(reproduceSpeed.ToString()));
                        this.StopAudio();
                        break;
                    case "7":
                        _toneGenerator.StartTone(Tone.Dtmf7);
                        Thread.Sleep(int.Parse(reproduceSpeed.ToString()));
                        this.StopAudio();
                        break;
                    case "8":
                        _toneGenerator.StartTone(Tone.Dtmf8);
                        Thread.Sleep(int.Parse(reproduceSpeed.ToString()));
                        this.StopAudio();
                        break;
                    case "9":
                        _toneGenerator.StartTone(Tone.Dtmf9);
                        Thread.Sleep(int.Parse(reproduceSpeed.ToString()));
                        this.StopAudio();
                        break;
                    case "#":
                        _toneGenerator.StartTone(Tone.DtmfP);
                        Thread.Sleep(int.Parse(reproduceSpeed.ToString()));
                        this.StopAudio();
                        break;
                    case "*":
                        _toneGenerator.StartTone(Tone.DtmfS);
                        Thread.Sleep(int.Parse(reproduceSpeed.ToString()));
                        this.StopAudio();
                        break;
                    default:
                        if (isPlaying)
                        {
                            this.StopAudio();
                        }
                        break;
                }
            }
        }

        #endregion

        void StopAudio()
        {
            isPlaying = false;
            _toneGenerator.StopTone();
            _toneGenerator.Release();
        }
    }
}