using App_AglCA.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App_AglCA.Views
{
	public partial class MainPage : ContentPage
	{
        private string IdToqueRapido = String.Empty;
        private bool msgErro1 = false;

		public MainPage ()
		{
			InitializeComponent ();

            //NavigationPage.SetHasNavigationBar(this, false);
            entryKeyboard.IsVisible = false;
            entryKeyboard.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(onChangeValidation);
            

            //Logo: Image
            AGL_Logo.Source = ImageSource.FromResource("App_AglCA.Resources.agl_logo.png");
            //btnImage.Source = ImageSource.FromResource("App_AglCA.Resources.playyellow128.png");
            ////btnFlex.Icon = ImageSource.FromResource("App_AglCA.Resources.play_main.png");
            btnImage.Source = ImageSource.FromResource("App_AglCA.Resources.play_main.png");
            btnImageKeyboard.Source = ImageSource.FromResource("App_AglCA.Resources.telephone-keypad.png");
            //btnKeyboard.Icon = ImageSource.FromResource("App_AglCA.Resources.telephone-keypad.png");
            //btnPlay.Image = (FileImageSource)ImageSource.FromResource("App_AglCA.Resources.playyellow.png");
        }

        private void onChangeValidation(object sender, PropertyChangedEventArgs e)
        {
            var digit = String.Empty;
            var component = (Entry)sender;

            if (!component.IsFocused)
            {
                entryKeyboard.IsVisible = false;
            }
            else if (component.IsFocused)
            {
                entryKeyboard.IsVisible = true;
            }

            if (component.Text != null)
            {
                digit = component.Text;
                
                DependencyService.Get<IAudio>().DTMFPlayTone(digit, (5 * 100));

                entryKeyboard.Text = "";
            }
        }

        public string getFastReproductionTone()
        {
            var toque = String.Empty;
            for (int i = 1; i < 6; i++)
            {
                var configToggle = String.Empty;
                if (Application.Current.Properties.ContainsKey("ToqueRapido" + i.ToString()))
                {
                    switch (i.ToString())
                    {
                        case "1":
                            configToggle = Application.Current.Properties["ToqueRapido" + i.ToString()].ToString();
                            if(configToggle == "True")
                            {
                                if (Application.Current.Properties.ContainsKey("Toque1"))
                                {
                                    toque = Application.Current.Properties["Toque" + i.ToString()].ToString();
                                    IdToqueRapido = "1";
                                }
                                else
                                {
                                    DependencyService.Get<IToast>().Show("Certifique-se que o toque selecionado possui 8 dígitos.");
                                    msgErro1 = true;
                                }
                            }
                            break;
                        case "2":
                            configToggle = Application.Current.Properties["ToqueRapido" + i.ToString()].ToString();
                            if (configToggle == "True")
                            {
                                if (Application.Current.Properties.ContainsKey("Toque2"))
                                {
                                    toque = Application.Current.Properties["Toque" + i.ToString()].ToString();
                                    IdToqueRapido = "2";
                                }
                                else
                                {
                                    DependencyService.Get<IToast>().Show("Certifique-se que o toque selecionado possui 8 dígitos.");
                                    msgErro1 = true;
                                }
                            }
                            break;
                        case "3":
                            configToggle = Application.Current.Properties["ToqueRapido" + i.ToString()].ToString();
                            if (configToggle == "True")
                            {
                                if (Application.Current.Properties.ContainsKey("Toque3"))
                                {
                                    toque = Application.Current.Properties["Toque" + i.ToString()].ToString();
                                    IdToqueRapido = "3";
                                }
                                else
                                {
                                    DependencyService.Get<IToast>().Show("Certifique-se que o toque selecionado possui 8 dígitos.");
                                    msgErro1 = true;
                                }
                            }
                            break;
                        case "4":
                            configToggle = Application.Current.Properties["ToqueRapido" + i.ToString()].ToString();
                            if (configToggle == "True")
                            {
                                if (Application.Current.Properties.ContainsKey("Toque4"))
                                {
                                    toque = Application.Current.Properties["Toque" + i.ToString()].ToString();
                                    IdToqueRapido = "4";
                                }
                                else
                                {
                                    DependencyService.Get<IToast>().Show("Certifique-se que o toque selecionado possui 8 dígitos.");
                                    msgErro1 = true;
                                }
                            }
                            break;
                        case "5":
                            configToggle = Application.Current.Properties["ToqueRapido" + i.ToString()].ToString();
                            if (configToggle == "True")
                            {
                                if (Application.Current.Properties.ContainsKey("Toque5"))
                                {
                                    toque = Application.Current.Properties["Toque" + i.ToString()].ToString();
                                    IdToqueRapido = "5";
                                }
                                else
                                {
                                    DependencyService.Get<IToast>().Show("Certifique-se que o toque selecionado possui 8 dígitos.");
                                    msgErro1 = true;
                                }
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            return toque;
        }

        private void btnFlex_Clicked(object sender, EventArgs e)
        {
            var toque = getFastReproductionTone();

            if(toque != String.Empty && IdToqueRapido != String.Empty)
            {
                foreach (char c in toque)
                {
                    DependencyService.Get<IAudio>().DTMFPlayTone(c.ToString(), (5 * 100));
                }
            }
            else
            {
                if(!msgErro1)
                {
                    DependencyService.Get<IToast>().Show("Nenhum toque selecionado. Acesse a aba Opções.");
                }
            }

            msgErro1 = false;
        }

        private void btnKeyboard_TouchedUp(object sender, EventArgs e)
        {
            entryKeyboard.IsVisible = true;
            entryKeyboard.Focus();
        }

        private void TapGestureRecognizer_PlayTapped(object sender, EventArgs e)
        {
            var toque = getFastReproductionTone();

            if (toque != String.Empty && IdToqueRapido != String.Empty)
            {
                foreach (char c in toque)
                {
                    DependencyService.Get<IAudio>().DTMFPlayTone(c.ToString(), (5 * 100));
                }
            }
            else
            {
                if (!msgErro1)
                {
                    DependencyService.Get<IToast>().Show("Nenhum toque selecionado. Acesse a aba Opções.");
                }
            }

            msgErro1 = false;
        }

        private void btnPlay_Clicked(object sender, EventArgs e)
        {

        }

        private void TapGestureRecognizer_KeyboardTapped(object sender, EventArgs e)
        {
            entryKeyboard.IsVisible = true;
            entryKeyboard.Focus();
        }
    }
}