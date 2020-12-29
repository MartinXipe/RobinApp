using Android.App;
using Android.Content;

using ExampleLink.Droid;
using ExampleLink.Model;
using ExampleLink.Views;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Json;
using Newtonsoft.Json;

using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using RestSharp;
using System.Collections.Generic;
using Prism.Navigation.Xaml;

#pragma warning disable CS0612 // Type or member is obsolete
[assembly: ExportRenderer(typeof(LoginPage), typeof(LoginPageRenderer))]
#pragma warning restore CS0612 // Type or member is obsolete
namespace ExampleLink.Droid
{
    [Obsolete]
    public class LoginPageRenderer : PageRenderer
    {
        protected INavigationService NavigationService { get; private set; }
        public LoginPageRenderer(Context context) : base(context) { }

        protected override async void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);
            // this is a ViewGroup - so should be able to load an AXML file and FindView<>
            var activity = this.Context as Activity;

            var auth = new OAuth2Authenticator(
                clientId: "86mir46493vare",
                clientSecret: "AdN49aqfrfv6JIgV",
                scope: "r_liteprofile",
                authorizeUrl: new Uri("https://www.linkedin.com/oauth/v2/authorization"),
                redirectUrl: new Uri("https://www.google.com/"),
                accessTokenUrl: new Uri("https://www.linkedin.com/oauth/v2/accessToken")
                );

            auth.Completed  += async (sender, eventArgs) =>
            {
                if (eventArgs.IsAuthenticated)
                {
                    string Token = eventArgs.Account.Properties["access_token"];
                    var resq = new OAuth2Request(
                                              "GET",
                                              new Uri("https://api.linkedin.com/v2/me?"
                                              + "oauth2_access_token="
                                              + Token
                                              + "&projection=(firstName,lastName,profilePicture(displayImage~:playableStreams))"),
                                              null,
                                              eventArgs.Account
                                              );

                    LinkModel linkModel = new LinkModel();
                    resq.AccessTokenParameterName = "oauth2_access_token";
                    var LinkResponse = await resq.GetResponseAsync();
                    var json = LinkResponse.GetResponseText();
                     linkModel = JsonConvert.DeserializeObject<LinkModel>(json);
                    Xamarin.Forms.Application.Current.Properties["Login"] = linkModel;
                    await Xamarin.Forms.Application.Current.SavePropertiesAsync();

                }
                else
                {
                    // The user cancelled
                }

            };

            activity.StartActivity(auth.GetUI(activity));

        }


    }


}