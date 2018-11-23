﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enagora.Plugins.Xam.GoogleAds.Interfaces;
using Foundation;
using Google.MobileAds;
using UIKit;

namespace Enagora.Plugins.Xam.GoogleAds
{
    public class GoogleAds : IGoogleAds
    {
        public string AppId {  get; set; }
        public string AdUnitId { get; set; }

        public event EventHandler InterstitialAdLoaded;
        public event EventHandler InterstitialAdClosed;

        public event EventHandler BannerAdLoaded;

        private Google.MobileAds.Interstitial interstitial;
        private BannerView banner;

        public void Initialize(string appId)
        {
            AppId = appId;
            MobileAds.Configure(appId);
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
            if (string.IsNullOrEmpty(AdUnitId))
            {
                AdUnitId = AdUnitId;
                interstitial = new Interstitial(adUnitId);

                interstitial.ScreenDismissed += (sender, e) =>
                {
                    interstitial.LoadRequest(Request.GetDefaultRequest());
                };

                interstitial.AdReceived += (sender, e) =>
                {
                    System.Diagnostics.Debug.WriteLine("AD LOADED");
                };

                interstitial.ReceiveAdFailed += (sender, e) =>
                {
                    System.Diagnostics.Debug.WriteLine("AD RECEIVE FAILED!");
                };
            }

            interstitial.LoadRequest(Request.GetDefaultRequest());
        }

        public void LoadBannerAdView(object view)
        {
            banner = (BannerView)view;
            banner.LoadRequest(Request.GetDefaultRequest());
            banner.AdReceived += OnBannerAdLoaded;

        }

        public void RefreshBannerAdView()
        {
            //No refresh method in iOS.
                
        }

        private void OnBannerAdLoaded(object sender, EventArgs e)
        {
            BannerAdLoaded?.Invoke(sender, e);
        }

        public void InterstitialShow()
        {
            //// We need to wait until the Intersitial is ready to show
            //do
            //{
            //    System.Threading.Tasks.Task.Delay(100).Wait();
            //} while (!interstitial.IsReady);

            if (interstitial.IsReady)
            {
                var viewController = GetVisibleViewController();
                interstitial.PresentFromRootViewController(viewController);
            }
        }

        UIViewController GetVisibleViewController()
        {
            var rootController = UIApplication.SharedApplication.KeyWindow.RootViewController;

            if (rootController.PresentedViewController == null)
                return rootController;

            if (rootController.PresentedViewController is UINavigationController)
            {
                return ((UINavigationController)rootController.PresentedViewController).VisibleViewController;
            }

            if (rootController.PresentedViewController is UITabBarController)
            {
                return ((UITabBarController)rootController.PresentedViewController).SelectedViewController;
            }

            return rootController.PresentedViewController;
        }
    }
}