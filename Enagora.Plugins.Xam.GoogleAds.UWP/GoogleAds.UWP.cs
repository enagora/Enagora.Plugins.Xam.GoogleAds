using Enagora.Plugins.Xam.GoogleAds;
using Enagora.Plugins.Xam.GoogleAds.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enagora.Plugins.Xam.GoogleAds
{
    public class GoogleAds :  IGoogleAds
    {
        public string AppId { get; set; }
        public string AdUnitIdBanner { get; set; }
        public string AdUnitIdInterstitial { get; set; }

        public event EventHandler InterstitialAdLoaded;
        public event EventHandler InterstitialAdClosed;

        public event EventHandler BannerAdLoaded;

        public void Initialize(string appId)
        {
            throw new NotImplementedException();
        }

        public bool IsLoaded()
        {
            throw new NotImplementedException();
        }

        public bool IsLoading()
        {
            throw new NotImplementedException();
        }

        public void LoadInterstitialAd(string adUnitId)
        {
            throw new NotImplementedException();
        }

        public void LoadBannerAdView(object view)
        {
            throw new NotImplementedException();
        }

        public void RefreshBannerAdView()
        {
            throw new NotImplementedException();
        }

        public void InterstitialShow()
        {
            throw new NotImplementedException();
        }
    }
}
