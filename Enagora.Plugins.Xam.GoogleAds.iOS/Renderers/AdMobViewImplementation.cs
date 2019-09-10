using AdSupport;
using CoreGraphics;
using Enagora.Plugins.Xam.GoogleAds.Abstractions.Views;
using Google.MobileAds;
using System;
using System.ComponentModel;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
[assembly: ExportRenderer(typeof(Enagora.Plugins.Xam.GoogleAds.Abstractions.Views.AdMobView), typeof(Enagora.Plugins.Xam.GoogleAds.iOS.AdMobViewRenderer))]
namespace Enagora.Plugins.Xam.GoogleAds.iOS
{
    public class AdMobViewRenderer : ViewRenderer<Abstractions.Views.AdMobView, BannerView>
    {
        
        protected override void OnElementChanged(ElementChangedEventArgs<AdMobView> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null || Element == null)
            {
                return;
            }

            if (Element !=null &&  Control == null)
            {
                SetNativeControl(CreateBannerView());
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (Control == null || Element == null)
                return;

            if (e.PropertyName == nameof(BannerView.AdUnitID))
                Control.AdUnitID = Element.AdUnitId;
        }

        private BannerView CreateBannerView()
        {
            var bannerView = new BannerView(AdSizeCons.SmartBannerPortrait)
            {
                AdUnitID = Element.AdUnitId,
                RootViewController = GetVisibleViewController()
            };

            CrossGoogleAds.Current.LoadBannerAdView(bannerView);

            //bannerView.LoadRequest(GetRequest());

            //Request GetRequest()
            //{
            //    var request = Request.GetDefaultRequest();
            //    return request;
            //}

            return bannerView;
        }

        private UIViewController GetVisibleViewController()
        {
            var windows = UIApplication.SharedApplication.Windows;
            foreach (var window in windows)
            {
                if (window.RootViewController != null)
                {
                    return window.RootViewController;
                }
            }
            return null;
        }
    }
}