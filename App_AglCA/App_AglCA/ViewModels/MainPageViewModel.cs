using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App_AglCA.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        INavigationService _navigationService;

        public MainPageViewModel(INavigationService navigationService) 
            : base (navigationService)
        {
            Title = "Controle de Acesso";

            _navigationService = navigationService;
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatingTo(parameters);
        }

        public override void OnNavigatedFrom(NavigationParameters parameters)
        {
            base.OnNavigatedFrom(parameters);
        }

        //Button Command: 0
        private DelegateCommand _dial0;
        public DelegateCommand Dial0 =>
            _dial0 ?? (_dial0 = new DelegateCommand(dialTone0));

        void dialTone0()
        {
            
        }
    }
}
