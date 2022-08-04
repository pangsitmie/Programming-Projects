using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class AdMobScript : MonoBehaviour
{
    //admob variable
    private BannerView bannerView;
    private InterstitialAd interstitial;
    private RewardedAd rewardedAd;
    
    //real ID
    string App_ID = "ca-app-pub-2208460615126853~5937399378";
    string bannerAdId = "ca-app-pub-2208460615126853~5937399378";
    string interstitialAdId = "ca-app-pub-2208460615126853~5937399378";
    string rewardedAdId = "ca-app-pub-2208460615126853~5937399378";
    /*
    //testID
    string App_ID = "ca-app-pub-2208460615126853~5937399378";
    string bannerAdId = "ca-app-pub-3940256099942544/6300978111";
    string interstitialAdId = "ca-app-pub-3940256099942544/1033173712";
    string rewardedAdId = "ca-app-pub-3940256099942544/5224354917";
    */
    //game variables
    public Wheel wheel;
    
    void Start()
    {
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(App_ID);
        //request banner ads
        //this.RequestBanner();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //banner
    private void RequestBanner()
    {
        // Create a 320x50 banner at the top of the screen.
        this.bannerView = new BannerView(bannerAdId, AdSize.Banner, AdPosition.Top);

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        this.bannerView.LoadAd(request);
    }



//---------------------------------------------------------------------------------




    //interstitial
    public void RequestInterstitial()
    {
        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(interstitialAdId);

        // Called when an ad request has successfully loaded.
        this.interstitial.OnAdLoaded += HandleOnAdLoaded;
        // Called when an ad request failed to load.
        this.interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        // Called when an ad is shown.
        this.interstitial.OnAdOpening += HandleOnAdOpened;
        // Called when the ad is closed.
        this.interstitial.OnAdClosed += HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        this.interstitial.OnAdLeavingApplication += HandleOnAdLeavingApplication;


        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        this.interstitial.LoadAd(request);

        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
        }
    }

    

    







    //rewarded ad-----------------------------------------------------



    public void CreateAndLoadRewardedAd()
    {


        this.rewardedAd = new RewardedAd(rewardedAdId);

        this.rewardedAd.OnAdLoaded += RewardedAd_OnAdLoaded; ;
        this.rewardedAd.OnUserEarnedReward += RewardedAd_OnUserEarnedReward; ;
        this.rewardedAd.OnAdClosed += RewardedAd_OnAdClosed; ;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this.rewardedAd.LoadAd(request);
    }

    private void RewardedAd_OnAdClosed(object sender, System.EventArgs e)
    {
        //ad has been clopsed by the user
    }

    private void RewardedAd_OnUserEarnedReward(object sender, Reward e)
    {
        //reward your user ( spinn the wheel)
        wheel.startSpin();
    }

    private void RewardedAd_OnAdLoaded(object sender, System.EventArgs e)
    {
        rewardedAd.Show();
    }








    //EVENTS

    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        Debug.Log("HandleAdLoaded event received");
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        Debug.Log("HandleFailedToReceiveAd event received with message: "
                            + args.Message);
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        Debug.Log("HandleOnAdOpened");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        Debug.Log("HandleOnAdClosed");
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        Debug.Log("HandleOnAdLeavingApplication");
    }
}
