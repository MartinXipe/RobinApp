using ExampleLink.Model;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace ExampleLink.ViewModels
{
    public class ProfileViewModel : ViewModelBase
    {
        LinkModel _LinkUser = new LinkModel();
        public LinkModel LinkUser { get => _LinkUser; set => SetProperty(ref _LinkUser, value); }
        public ProfileViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            if (Application.Current.Properties.ContainsKey("Login"))
            {
                LinkUser = (LinkModel)Application.Current.Properties["Login"];

            }
        }

     
    }
}
