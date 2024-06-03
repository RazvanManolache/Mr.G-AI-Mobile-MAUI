using MrG.AI.Client.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MrG.Maui.Helpers
{
    internal static class HttpHelper
    {
        internal async static Task<bool> OpenRegisterUrl()
        {
            return await OpenUrlInBrowser(Server.GetRegisterUrl());

        }

        internal async static Task<bool> OpenHowToUrl()
        {
            return await OpenUrlInBrowser(Server.GetHowToUrl());
        }

        private async static Task<bool> OpenUrlInBrowser(string url)
        {
            Uri uri = new Uri(url);
            BrowserLaunchOptions options = new BrowserLaunchOptions()
            {
                LaunchMode = BrowserLaunchMode.SystemPreferred,
                TitleMode = BrowserTitleMode.Show,
                PreferredToolbarColor = Colors.Violet,
                PreferredControlColor = Colors.SandyBrown
            };

            return await Browser.Default.OpenAsync(uri, options);
        }

    }
}
