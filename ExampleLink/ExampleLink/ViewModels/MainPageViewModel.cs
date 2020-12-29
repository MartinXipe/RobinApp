using Android.App;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Auth;

namespace ExampleLink.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private IPageDialogService _dialogService;

        public DelegateCommand LoginCoomand { get; set; }
        public MainPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
            : base(navigationService)
        {
            Title = "Login";
            _dialogService = dialogService;
            LoginCoomand = new DelegateCommand(Login);
        }


        public async void Login()
        {

            await NavigationService.NavigateAsync("/LoginPage");

        }



      
    }
}
