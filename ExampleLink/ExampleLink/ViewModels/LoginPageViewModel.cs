using ExampleLink.Model;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;

namespace ExampleLink.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        private IPageDialogService _dialogService;
        LinkModel _LinkUser = new LinkModel();
        public LinkModel LinkUser { get => _LinkUser; set => SetProperty(ref _LinkUser, value); }

        public DelegateCommand Command { get; set; }
        public LoginPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
            : base(navigationService)
        {
            _dialogService = dialogService;
            Command = new DelegateCommand(ToProfile);

            
            Device.StartTimer(TimeSpan.FromSeconds(1), (Func<bool>)(() =>
            {
                if (Application.Current.Properties.ContainsKey("Login"))
                {
                    LinkUser = (LinkModel)Application.Current.Properties["Login"];

                }
                if (LinkUser.firstName != null)
                {
                    ToProfile();
                    return false;
                }
                return true;
            })
            );
        }

        public async void ToProfile()
        {
            await NavigationService.NavigateAsync("/Profile");
        }



    }
}
