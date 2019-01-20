using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using HandyApp.Core.Models;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Essentials.Interfaces;

namespace HandyApp.Core.ViewModels
{
    public class ViewModelBase : BindableBase, INavigationAware, IDestructible
    {
        
        protected INavigationService NavigationService { get; private set; }
        protected readonly ISecureStorage SecureStorage;

        
        private DelegateCommand<string> _navigateCommand;
        public DelegateCommand<string> NavigateCommand =>
            _navigateCommand ?? (_navigateCommand = new DelegateCommand<string>(ExecuteCommandName));

        async void ExecuteCommandName(string page)
        {
            var absoluteNav = UriKind.Relative;
            var target = page.Split('\\').Last();
            if (Constants.Apps.Any(x => x.Name.Equals(target)))
            {
                await SaveRecentApp(new App {Name = target, NavigationLink = page});
            }

            if (page.Equals("HomePage/NavigationPage/StartPage"))
            {
                await SaveToStorageAsync("FirstLoad", "False");
                absoluteNav = UriKind.Absolute;
            }
            await NavigationService.NavigateAsync(page);
        }
        public ViewModelBase(INavigationService navigationService, ISecureStorage storage)
        {
            
            NavigationService = navigationService;
            SecureStorage = storage;
        }

        protected async Task<IEnumerable<App>> GetApps()
        {
            var stringData = await SecureStorage.GetAsync("recentApps");
            if (string.IsNullOrEmpty(stringData))
            {
                return new List<App>();
            }
            return JsonConvert.DeserializeObject<IEnumerable<App>>(stringData);
        }

        protected async Task SaveToStorageAsync(string key, object sata)
        {
            var data = JsonConvert.SerializeObject(sata);
            await SecureStorage.SetAsync(key, data);
        }

        protected async Task SaveRecentApp(App app)
        {
            var stringData = await SecureStorage.GetAsync("recentApps");
            if (stringData != null)
            {
                var recentApps = JsonConvert.DeserializeObject<List<App>>(stringData);
                if (recentApps.Any(x => x.Name.Equals(app.Name)))
                {
                    var appToRemove = recentApps.FirstOrDefault(x => x.Name.Equals(app.Name));
                    recentApps.Remove(appToRemove);
                }
                recentApps.Insert(0,app);
                if (recentApps.Count > 5)
                {
                    recentApps.Remove(recentApps.FirstOrDefault());
                }
                var data = JsonConvert.SerializeObject(recentApps);
                await SecureStorage.SetAsync("recentApps", data);
            }
            else
            {
                var apps = new List<App> {app};
                var data = JsonConvert.SerializeObject(apps);
                
                await SecureStorage.SetAsync("recentApps", data);
            }
        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
            
        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatingTo(INavigationParameters parameters)
        {

        }

        public virtual void Destroy()
        {

        }
    }
}
