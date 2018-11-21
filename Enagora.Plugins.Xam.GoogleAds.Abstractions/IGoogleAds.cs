using System;
using System.Collections.Generic;
using System.Text;

namespace Enagora.Plugins.Xam.GoogleAds.Interfaces
{
    public interface  IGoogleAds
    {
        event EventHandler InterstitialAdLoaded;
        event EventHandler InterstitialAdClosed;

        string AppId { get; set; }
        string AdUnitId { get; set; }


        //Methods
        void Initialize(string appId);
        void LoadAdView(object view);
        void RefreshAdView();
        void LoadAd(string adUnitId);
        void Show();
        bool IsLoaded();
        bool IsLoading();
    }
}
