** README FILE **

Initialize GoogleAds where you want with:

	CrossGoogleAds.Current.Initialize([AppId]);


------------ BANNER XAML  ------------------------------------

When using banner be sure allocation element height or suscribe lo BannerAdLoaded 
event for example changing IsVisible AdMobView state. Otherwise on initialization
AdMobView height would be zero and when banner is loaded is not going to be visible.


Import element	
	xmlns:ads="clr-namespace:Enagora.Plugins.Xam.GoogleAds.Abstractions.Views;assembly=Enagora.Plugins.Xam.GoogleAds.Abstractions"

Use where you want
	<ads:AdMobView Grid.Row="2" AdUnitId="{Binding AdUnitId}" BackgroundColor="Transparent" /> //is recomended IsVisble={Binding ShowBanner} updated when BannerAdLoaded is raised



-------------- INTERSTITIAL ----------------------------------

Initialize with
	CrossGoogleAds.Current.LoadInterstitialAd([AdUnitId]);

After InterstitialAdLoaded event you can show when you want with

	CrossGoogleAds.Current.InterstitialShow();



--------------- USEFUL EVENTS ---------------------------------

Interstitial Ads:
    InterstitialAdLoaded; // Raises when interstitial is loaded and ready to show
    InterstitialAdClosed; // Raises when interstitial is closed

Banner Ads:
	BannerAdLoaded; // Raises when banner is loaded and ready to show


