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
        public string AdUnitId { get; set; }

        public event EventHandler InterstitialAdLoaded;
        public event EventHandler InterstitialAdClosed;

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

        public void LoadAd(string adUnitId)
        {
            throw new NotImplementedException();
        }

        public void LoadAdView(object view)
        {
            throw new NotImplementedException();
        }

        public void RefreshAdView()
        {
            throw new NotImplementedException();
        }

        public void Show()
        {
            throw new NotImplementedException();
        }
    }
}
