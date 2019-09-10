using System;
using System.Collections.Generic;
using System.Text;

namespace Enagora.Plugins.Xam.GoogleAds.Interfaces
{
    public interface  IGoogleAds
    {
        event EventHandler InterstitialAdLoaded;
        event EventHandler InterstitialAdClosed;

        event EventHandler BannerAdLoaded;

        string AppId { get; set; }
        
        string AdUnitIdBanner { get; set; }
        string AdUnitIdInterstitial { get; set; }

        //Methods
        void Initialize(string appId);

        /// <summary>
        /// Loads a banner ad
        /// </summary>
        /// <param name="view"></param>
        void LoadBannerAdView(object view);

        /// <summary>
        /// Refresh ad information with a new one
        /// </summary>
        void RefreshBannerAdView();

        /// <summary>
        /// Load interstitial style ad
        /// </summary>
        /// <param name="adUnitId">googleAds ad id</param>
        void LoadInterstitialAd(string adUnitId);

        /// <summary>
        /// Show 
        /// </summary>
        void InterstitialShow();
        bool IsLoaded();
        bool IsLoading();
    }
}
