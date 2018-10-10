using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using App_AglCA.iOS.Services;
using App_AglCA.Services;
using AudioToolbox;
using AVFoundation;
using CallKit;
using Foundation;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(AudioService))]
namespace App_AglCA.iOS.Services
{
    public class AudioService : IAudio
    {
        //private AVAudioPlayer audioPlayer;
        /*
        AVAudioPlayer backgroundMusic;
        AVAudioPlayer soundEffect;

        public bool MusicOn { get; set; } = true;
        public float MusicVolume { get; set; } = 0.5f;

        public bool EffectsOn { get; set; } = true;
        public float EffectsVolume { get; set; } = 1.0f;*/

        bool isPlaying = false;
        SystemSound systemSound;

        public AudioService() { }

        #region IAudio

        public void DTMFPlayTone(string t, float reproduceSpeed)
        {
            if (!isPlaying)
            {
                isPlaying = true;

                switch (t)
                {
                    case "0":
                        systemSound = new SystemSound(1200);
                        systemSound.PlayAlertSound();
                        StopSound(reproduceSpeed.ToString());
                        break;
                    case "1":
                        systemSound = new SystemSound(1201);
                        systemSound.PlayAlertSound();
                        StopSound(reproduceSpeed.ToString());
                        break;
                    case "2":
                        systemSound = new SystemSound(1202);
                        systemSound.PlayAlertSound();
                        StopSound(reproduceSpeed.ToString());
                        break;
                    case "3":
                        systemSound = new SystemSound(1203);
                        systemSound.PlayAlertSound();
                        StopSound(reproduceSpeed.ToString());
                        break;
                    case "4":
                        systemSound = new SystemSound(1204);
                        systemSound.PlayAlertSound();
                        StopSound(reproduceSpeed.ToString());
                        break;
                    case "5":
                        systemSound = new SystemSound(1205);
                        systemSound.PlayAlertSound();
                        StopSound(reproduceSpeed.ToString());
                        break;
                    case "6":
                        systemSound = new SystemSound(1206);
                        systemSound.PlayAlertSound();
                        StopSound(reproduceSpeed.ToString());
                        break;
                    case "7":
                        systemSound = new SystemSound(1207);
                        systemSound.PlayAlertSound();
                        StopSound(reproduceSpeed.ToString());
                        break;
                    case "8":
                        systemSound = new SystemSound(1208);
                        systemSound.PlayAlertSound();
                        StopSound(reproduceSpeed.ToString());
                        break;
                    case "9":
                        systemSound = new SystemSound(1209);
                        systemSound.PlayAlertSound();
                        StopSound(reproduceSpeed.ToString());
                        break;
                    case "#":
                        systemSound = new SystemSound(1211);
                        systemSound.PlayAlertSound();
                        StopSound(reproduceSpeed.ToString());
                        break;
                    case "*":
                        systemSound = new SystemSound(1210);
                        systemSound.PlayAlertSound();
                        StopSound(reproduceSpeed.ToString());
                        break;
                    default:
                        if (isPlaying)
                        {
                            systemSound = new SystemSound(1210);
                            systemSound.Close();
                        }
                        break;
                }

                isPlaying = false;
            }
        }

        public void StopSound(string reproduceSpeed)
        {
            Thread.Sleep(int.Parse(reproduceSpeed));
            systemSound.Close();
            isPlaying = false;
        }

        /*public void DTMFPlayTone(string t, float reproduceSpeed)
        {
            NSUrl songURL;

            // Music enabled?
            if (!EffectsOn) return;

            // Any existing sound effect?
            if (soundEffect != null)
            {
                //Stop and dispose of any sound effect
                soundEffect.Stop();
                soundEffect.Dispose();
            }

            // Initialize background music
            songURL = new NSUrl("Resources/" + t);
            NSError err;
            soundEffect = new AVAudioPlayer(songURL, "wav", out err);
            soundEffect.Volume = EffectsVolume;
            soundEffect.FinishedPlaying += delegate {
                soundEffect = null;
            };
            soundEffect.NumberOfLoops = 0;
            soundEffect.Play();
        }*/
        #endregion IAudio
    }
}