using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExampleLink.ViewModels
{
    public class ViewModelBase : BindableBase, IInitialize, INavigationAware, IDestructible
    {
        protected INavigationService NavigationService { get; private set; }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        public async virtual void Initialize(INavigationParameters parameters)
        {
            await Task.Run(() => { });
        }

        public async virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
            await Task.Run(() => { });
        }

        public async virtual void OnNavigatedTo(INavigationParameters parameters)
        {
            await Task.Run(() => { });

        }

        public async virtual void Destroy()
        {
            await Task.Run(() => { });
        }
    }
}
