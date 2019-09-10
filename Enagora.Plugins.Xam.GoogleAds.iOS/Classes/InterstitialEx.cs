using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using Google.MobileAds;
using UIKit;

namespace Enagora.Plugins.Xam.GoogleAds.Classes
{
    /// <summary>
    /// 
    /// </summary>
    public class InterstitialEx : Interstitial
    {
        public bool IsLoaded { get; set; }
        public bool IsLoading { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        public  InterstitialEx(string t) : base(t)
        {
            ScreenDismissed += InterstitialEx_ScreenDismissed;
            AdReceived += InterstitialEx_AdReceived;
            ReceiveAdFailed += InterstitialEx_ReceiveAdFailed;

        }

        private void InterstitialEx_ReceiveAdFailed(object sender, InterstitialDidFailToReceiveAdWithErrorEventArgs e)
        {
            IsLoading = false;
            LoadRequest(Request.GetDefaultRequest());
        }

        private void InterstitialEx_AdReceived(object sender, EventArgs e)
        {
            IsLoaded = true;
            IsLoading = false;
        }

        private void InterstitialEx_ScreenDismissed(object sender, EventArgs e)
        {
            IsLoaded = false;
            this.LoadRequest(Request.GetDefaultRequest());
            IsLoading = true;
        }
    }
}