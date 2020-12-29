using ExampleLink.iOS;
using ExampleLink.Model;
using ExampleLink.Views;
using Foundation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(LoginPage), typeof(LoginPageRenderer))]
namespace ExampleLink.iOS
{
    public class LoginPageRenderer : PageRenderer
    {
        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);


            var auth = new OAuth2Authenticator(
                clientId: "86mir46493vare",
                clientSecret: "AdN49aqfrfv6JIgV",
                scope: "r_liteprofile",
                authorizeUrl: new Uri("https://www.linkedin.com/oauth/v2/authorization"),
                redirectUrl: new Uri("https://www.google.com/"),
                accessTokenUrl: new Uri("https://www.linkedin.com/oauth/v2/accessToken")
                );

            auth.Completed += async (sender, eventArgs) =>
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

            PresentViewController(auth.GetUI(), true, null);
        }
    }
}