using App_AglCA.Services;
using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace App_AglCA.Views
{
    public partial class SettingsPage : ContentPage
    {
        string activeSwitch = String.Empty;

        #region Constructor
        public SettingsPage()
        {
            InitializeComponent();

            //Logo: Image
            AGL_Logo.Source = ImageSource.FromResource("App_AglCA.Resources.agl_logo.png");

            //Event: OnEntryChange
            Entry_Toque1.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(onEntryChanged);
            Entry_Toque2.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(onEntryChanged);
            Entry_Toque3.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(onEntryChanged);
            Entry_Toque4.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(onEntryChanged);
            Entry_Toque5.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(onEntryChanged);

            btnToque1.Icon = ImageSource.FromResource("App_AglCA.Resources.play_savedtones.png");
            btnToque2.Icon = ImageSource.FromResource("App_AglCA.Resources.play_savedtones.png");
            btnToque3.Icon = ImageSource.FromResource("App_AglCA.Resources.play_savedtones.png");
            btnToque4.Icon = ImageSource.FromResource("App_AglCA.Resources.play_savedtones.png");
            btnToque5.Icon = ImageSource.FromResource("App_AglCA.Resources.play_savedtones.png");

            /*Entry_Toque1.TextColor = Color.WhiteSmoke;
            Entry_Toque2.TextColor = Color.WhiteSmoke;
            Entry_Toque3.TextColor = Color.WhiteSmoke;
            Entry_Toque4.TextColor = Color.WhiteSmoke;
            Entry_Toque5.TextColor = Color.WhiteSmoke;*/

            if (Application.Current.Properties.ContainsKey("Toque1"))
            {
                var toque1 = Application.Current.Properties["Toque1"].ToString();
                if(toque1 != null && toque1 != "")
                {
                    Entry_Toque1.Text = toque1.ToString();
                }
            }

            if (Application.Current.Properties.ContainsKey("Toque2"))
            {
                var toque2 = Application.Current.Properties["Toque2"].ToString();
                if (toque2 != null && toque2 != "")
                {
                    Entry_Toque2.Text = toque2.ToString();
                }
            }

            if (Application.Current.Properties.ContainsKey("Toque3"))
            {
                var toque3 = Application.Current.Properties["Toque3"].ToString();
                if (toque3 != null && toque3 != "")
                {
                    Entry_Toque3.Text = toque3.ToString();
                }
            }

            if (Application.Current.Properties.ContainsKey("Toque4"))
            {
                var toque4 = Application.Current.Properties["Toque4"].ToString();
                if (toque4 != null && toque4 != "")
                {
                    Entry_Toque4.Text = toque4.ToString();
                }
            }

            if (Application.Current.Properties.ContainsKey("Toque5"))
            {
                var toque5 = Application.Current.Properties["Toque5"].ToString();
                if (toque5 != null && toque5 != "")
                {
                    Entry_Toque5.Text = toque5.ToString();
                }
            }
        }
        #endregion

        #region Events

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //Load saved data
            LoadFastReproductionSettings();
        }

        //ON ENTRY CHANGED
        private void onEntryChanged(object sender, PropertyChangedEventArgs e)
        {
            var component = (Entry)sender;

            if(component.Text != null && component.Text !="" && component.Text.Length == 8)
            {
                Application.Current.Properties["Toque" + component.Placeholder] = "";
                Application.Current.SavePropertiesAsync();
                Application.Current.Properties["Toque" + component.Placeholder] = component.Text;
                Application.Current.SavePropertiesAsync();
            }

            if(component.Text != null && component.Text.Length > 8)
            {
                component.Text = component.Text.Remove(8);
            }

            /*if (component.Text == "" || component.Text == null)
            {
                switch(component.Placeholder.ToString())
                {
                    case "1":
                        Switch_Toque1.IsToggled = false;
                        WriteFastReproductionTone("1", false);
                        break;
                    case "2":
                        Switch_Toque2.IsToggled = false;
                        WriteFastReproductionTone("2", false);
                        break;
                    case "3":
                        Switch_Toque3.IsToggled = false;
                        WriteFastReproductionTone("3", false);
                        break;
                    case "4":
                        Switch_Toque4.IsToggled = false;
                        WriteFastReproductionTone("4", false);
                        break;
                    case "5":
                        Switch_Toque5.IsToggled = false;
                        WriteFastReproductionTone("5", false);
                        break;
                    default:
                        break;
                }
            }*/
        }

        //VIEW CELL EVENTS
        private void ViewCell1_Tapped(object sender, EventArgs e)
        {
            if (Entry_Toque1.Text == null)
                return;
            var dialtone = Entry_Toque1.Text;
            foreach (char c in dialtone)
            {
                DependencyService.Get<IAudio>().DTMFPlayTone(c.ToString(), (5 * 100));
            }
        }

        private void ViewCell2_Tapped(object sender, EventArgs e)
        {
            if (Entry_Toque2.Text == null)
                return;
            var dialtone = Entry_Toque2.Text;
            foreach (char c in dialtone)
            {
                DependencyService.Get<IAudio>().DTMFPlayTone(c.ToString(), (5 * 100));
            }
        }

        private void ViewCell3_Tapped(object sender, EventArgs e)
        {
            if (Entry_Toque3.Text == null)
                return;
            var dialtone = Entry_Toque3.Text;
            foreach (char c in dialtone)
            {
                DependencyService.Get<IAudio>().DTMFPlayTone(c.ToString(), (5 * 100));
            }
        }

        private void ViewCell4_Tapped(object sender, EventArgs e)
        {
            if (Entry_Toque4.Text == null)
                return;
            var dialtone = Entry_Toque4.Text;
            foreach (char c in dialtone)
            {
                DependencyService.Get<IAudio>().DTMFPlayTone(c.ToString(), (5 * 100));
            }
        }

        private void ViewCell5_Tapped(object sender, EventArgs e)
        {
            if (Entry_Toque5.Text == null)
                return;
            var dialtone = Entry_Toque5.Text;
            foreach (char c in dialtone)
            {
                DependencyService.Get<IAudio>().DTMFPlayTone(c.ToString(), (5 * 100));
            }
        }

        //SWITCH EVENTS
        private void Switch_Toque1_Toggled(object sender, ToggledEventArgs e)
        {
            var component = (Switch)sender;

            if(Entry_Toque1.Text != "" && Entry_Toque1.Text != null)
            {
                WriteFastReproductionTone("1", component.IsToggled);

                if (Switch_Toque1.IsToggled)
                {
                    activeSwitch = "1";
                    DependencyService.Get<IToast>().Show("Reprodução Rápida: Toque 1");
                    GroupSwitch();
                }
            }
            else
            {
                component.IsToggled = false;
                //DependencyService.Get<IToast>().Show("Para selecionar o toque de Reprodução Rápida informe uma sequência numérica.");
            }
        }

        private void Switch_Toque2_Toggled(object sender, ToggledEventArgs e)
        {
            var component = (Switch)sender;

            if (Entry_Toque2.Text != "" && Entry_Toque2.Text != null)
            {
                WriteFastReproductionTone("2", component.IsToggled);

                if (Switch_Toque2.IsToggled)
                {
                    activeSwitch = "2";
                    DependencyService.Get<IToast>().Show("Reprodução Rápida: Toque 2");
                    GroupSwitch();
                }
            }
            else
            {
                component.IsToggled = false;
                //DependencyService.Get<IToast>().Show("Para selecionar o toque de Reprodução Rápida informe uma sequência numérica.");
            }
        }

        private void Switch_Toque3_Toggled(object sender, ToggledEventArgs e)
        {
            var component = (Switch)sender;

            if (Entry_Toque2.Text != "" && Entry_Toque2.Text != null)
            {
                WriteFastReproductionTone("3", component.IsToggled);

                if (Switch_Toque3.IsToggled)
                {
                    activeSwitch = "3";
                    DependencyService.Get<IToast>().Show("Reprodução Rápida: Toque 3");
                    GroupSwitch();
                }
            }
            else
            {
                component.IsToggled = false;
                //DependencyService.Get<IToast>().Show("Para selecionar o toque de Reprodução Rápida informe uma sequência numérica.");
            }
        }

        private void Switch_Toque4_Toggled(object sender, ToggledEventArgs e)
        {
            var component = (Switch)sender;

            if (Entry_Toque2.Text != "" && Entry_Toque2.Text != null)
            {
                WriteFastReproductionTone("4", component.IsToggled);

                if (Switch_Toque4.IsToggled)
                {
                    activeSwitch = "4";
                    DependencyService.Get<IToast>().Show("Reprodução Rápida: Toque 4");
                    GroupSwitch();
                }
            }
            else
            {
                component.IsToggled = false;
                //DependencyService.Get<IToast>().Show("Para selecionar o toque de Reprodução Rápida informe uma sequência numérica.");
            }
        }

        private void Switch_Toque5_Toggled(object sender, ToggledEventArgs e)
        {
            var component = (Switch)sender;

            if (Entry_Toque2.Text != "" && Entry_Toque2.Text != null)
            {
                WriteFastReproductionTone("5", component.IsToggled);

                if (Switch_Toque5.IsToggled)
                {
                    activeSwitch = "5";
                    DependencyService.Get<IToast>().Show("Reprodução Rápida: Toque 5");
                    GroupSwitch();
                }
            }
            else
            {
                component.IsToggled = false;
                //DependencyService.Get<IToast>().Show("Para selecionar o toque de Reprodução Rápida informe uma sequência numérica.");
            }
        }

        #endregion

        #region Fast Reproduction Methods

        public void WriteFastReproductionTone (string toneId, bool value)
        {
            Application.Current.Properties["ToqueRapido" + toneId] = "";
            Application.Current.SavePropertiesAsync();
            Application.Current.Properties["ToqueRapido" + toneId] = value;
            Application.Current.SavePropertiesAsync();
        }

        public void LoadFastReproductionSettings()
        {
            var configToggle = String.Empty;
            for(int i = 1; i < 6; i++)
            {
                if (Application.Current.Properties.ContainsKey("ToqueRapido" + i.ToString()))
                {
                    switch(i.ToString())
                    {
                        case "1":
                            configToggle = Application.Current.Properties["ToqueRapido" + i.ToString()].ToString();
                            if (configToggle != null)
                            {
                                if (configToggle == "True")
                                {
                                    Switch_Toque1.IsToggled = true;
                                    activeSwitch = "1";
                                }
                                else
                                {
                                    Switch_Toque1.IsToggled = false;
                                }
                            }
                            break;
                        case "2":
                            configToggle = Application.Current.Properties["ToqueRapido" + i.ToString()].ToString();
                            if (configToggle != null)
                            {
                                if (configToggle == "True")
                                {
                                    Switch_Toque2.IsToggled = true;
                                    activeSwitch = "2";
                                }
                                else
                                {
                                    Switch_Toque2.IsToggled = false;
                                }
                            }
                            break;
                        case "3":
                            configToggle = Application.Current.Properties["ToqueRapido" + i.ToString()].ToString();
                            if (configToggle != null)
                            {
                                if (configToggle == "True")
                                {
                                    Switch_Toque3.IsToggled = true;
                                    activeSwitch = "3";
                                }
                                else
                                {
                                    Switch_Toque3.IsToggled = false;
                                }
                            }
                            break;
                        case "4":
                            configToggle = Application.Current.Properties["ToqueRapido" + i.ToString()].ToString();
                            if (configToggle != null)
                            {
                                if (configToggle == "True")
                                {
                                    Switch_Toque4.IsToggled = true;
                                    activeSwitch = "4";
                                }
                                else
                                {
                                    Switch_Toque4.IsToggled = false;
                                }
                            }
                            break;
                        case "5":
                            configToggle = Application.Current.Properties["ToqueRapido" + i.ToString()].ToString();
                            if (configToggle != null)
                            {
                                if (configToggle == "True")
                                {
                                    Switch_Toque5.IsToggled = true;
                                    activeSwitch = "5";
                                }
                                else
                                {
                                    Switch_Toque5.IsToggled = false;
                                }
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            
        }

        #endregion

        public void GroupSwitch()
        {
            if (activeSwitch != "1")
            {
                Switch_Toque1.IsToggled = false;
            }

            if (activeSwitch != "2")
            {
                Switch_Toque2.IsToggled = false;
            }

            if (activeSwitch != "3")
            {
                Switch_Toque3.IsToggled = false;
            }

            if (activeSwitch != "4")
            {
                Switch_Toque4.IsToggled = false;
            }

            if (activeSwitch != "5")
            {
                Switch_Toque5.IsToggled = false;
            }
        }
    }
}
