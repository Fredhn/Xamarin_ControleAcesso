﻿using Prism.Common;
using Prism.Navigation;
using Xamarin.Forms;

namespace App_AglCA.Views
{
    public partial class MainTabbedPage : TabbedPage, INavigatingAware
    {
        public MainTabbedPage()
        {
            InitializeComponent();
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            foreach (var child in Children)
            {
                PageUtilities.OnNavigatingTo(child, parameters);
            }

            //CurrentPage = Children[0];
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            CurrentPage = Children[1];
        }
    }
}
