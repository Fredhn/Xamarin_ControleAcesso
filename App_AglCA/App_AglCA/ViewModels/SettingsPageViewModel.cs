using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace App_AglCA.ViewModels
{
	public class SettingsPageViewModel : ViewModelBase
	{
        INavigationService _navigationService;

        public SettingsPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Opções";

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
    }
}
