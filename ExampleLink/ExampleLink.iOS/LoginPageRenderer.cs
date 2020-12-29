using ExampleLink.iOS;
using ExampleLink.Views;
using Foundation;
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
                clientId: "86mir46493vare", // your OAuth2 client id
                scope: "", // the scopes for the particular API you're accessing, delimited by "+" symbols
                authorizeUrl: new Uri("https://www.linkedin.com/uas/oauth2/authorization"),
                redirectUrl: new Uri("https://www.Google.com"));

            auth.Completed += async (sender, eventArgs) => {
                // We presented the UI, so it's up to us to dimiss it on iOS.
                //App.SuccessfulLoginAction.Invoke();

                if (eventArgs.IsAuthenticated)
                {
                    // Use eventArgs.Account to do wonderful things
                    //App.SaveToken(eventArgs.Account.Properties["access_token"]);
                    


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