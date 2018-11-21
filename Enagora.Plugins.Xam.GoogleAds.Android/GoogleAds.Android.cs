using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Gms.Ads;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Enagora.Plugins.Xam.GoogleAds.Interfaces;


namespace Enagora.Plugins.Xam.GoogleAds
{
    public class GoogleAds :  IGoogleAds
    {
        InterstitialAd interstial;
        AdView banner;

        public string AppId { get; set; }
        public string AdUnitId { get; set; }

        public event EventHandler InterstitialAdLoaded;
        public event EventHandler InterstitialAdClosed;

        public void Initialize(string appid)
        {
            AppId = appid;

            MobileAds.Initialize(Application.Context, appid);
        }

        public bool IsLoaded()
        {
            return interstial.IsLoaded;
        }

        public bool IsLoading()
        {
            return interstial.IsLoading;
        }

        public void LoadAdView(object view)
        {
            //if(banner == null)
            banner = (AdView)view;
            banner.LoadAd(new AdRequest.Builder().Build());
            banner.RefreshDrawableState();


        }

        public void RefreshAdView()
        {
            if (banner != null)
                banner.RefreshDrawableState();
        }

        public void LoadAd(string adUnitId)
        {
            if (interstial == null)
            {
                interstial = new InterstitialAd(Application.Context);
                
                interstial.RewardedVideoAdLoaded += Interstial_RewardedVideoAdLoaded;
                interstial.RewardedVideoAdClosed += Interstial_RewardedVideoAdClosed;
            }

            if(string.IsNullOrEmpty(interstial.AdUnitId))
                interstial.AdUnitId = adUnitId;
                        

            interstial.LoadAd(new AdRequest.Builder().Build());
        }


        private void Interstial_RewardedVideoAdClosed(object sender, EventArgs e)
        {
            LoadAd(interstial.AdUnitId);
            InterstitialAdClosed?.Invoke(this, e);
        }

        private void Interstial_RewardedVideoAdLoaded(object sender, EventArgs e)
        {
            InterstitialAdLoaded?.Invoke(this, e);
        }

        public void Show()
        {
            if (interstial.IsLoaded)
                interstial.Show();
            else
                Toast.MakeText(Application.Context, "interstial wont load yet", ToastLength.Long).Show();

        }

        #region AdListener_Events


        //public override void OnAdClosed()
        //{
        //    LoadAd(interstial.AdUnitId);
        //    InterstitialAdClosed?.Invoke(this, null);
        //} 
        #endregion
    }
}