using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Ads;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Enagora.Plugins.Xam.GoogleAds.Abstractions.Views;
using Xamarin.Forms.Platform.Android;


[assembly: Xamarin.Forms.ExportRenderer(typeof(AdMobView), typeof(Enagora.Plugins.Xam.GoogleAds.Android.Renderers.AdMobViewRenderer))]
namespace Enagora.Plugins.Xam.GoogleAds.Android.Renderers
{
    public class AdMobViewRenderer : ViewRenderer<AdMobView, AdView>
    {
        AdView myAdView;

        public AdMobViewRenderer(Context context) : base(context) { }

        protected override void OnElementChanged(ElementChangedEventArgs<AdMobView> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null || Element == null)
            {
                return;
            }
            
            if (e.NewElement != null && Control == null)
            SetNativeControl(CreateAdView());
        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
         
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == nameof(AdView.AdUnitId))
            {
                Control.AdUnitId = Element.AdUnitId;
                CrossGoogleAds.Current.LoadBannerAdView(myAdView);
            }
        }

        private AdView CreateAdView()
        {
            myAdView = new AdView(Context)
            {
                AdSize = AdSize.SmartBanner,
                AdUnitId = Element.AdUnitId
            };

            myAdView.LayoutParameters = new LinearLayout.LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent);
            CrossGoogleAds.Current.LoadBannerAdView(myAdView);
            

            //adView.LoadAd(new AdRequest.Builder().Build());

            return myAdView;
        }
    }
}