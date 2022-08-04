using UnityEngine;
using UnityEngine.Advertisements;
public class AdsManager : MonoBehaviour, IUnityAdsListener
{
    private string playStoreID = "3875937";
    private string appStoreID = "3875936";

    private string intersitialAD = "video";
    private string rewardedVideoAD = "rewardedVideo";
    //private string dailyRewardVideoAD = "dailyReward";

    public bool isTargetPlayStore;
    public bool isTestAd;


    public Wheel wheel;

    public AudioSource audio;

    void Start()
    {
        Advertisement.AddListener(this);
        InitializeAdvertisement();
        
    }
    private void InitializeAdvertisement()
    {
        if(isTargetPlayStore)
        {
            Advertisement.Initialize(playStoreID, isTestAd);
            return;
        }
        Advertisement.Initialize(appStoreID, isTestAd);
    }

    public void PlayInterstitialAd()
    {
        if (!Advertisement.IsReady(intersitialAD)) { return; }
        Advertisement.Show(intersitialAD);
    }
    public void PlayRewardedVideoAd()
    {
        if (!Advertisement.IsReady(rewardedVideoAD)) { return; }
        Advertisement.Show(rewardedVideoAD);
    }

    public void OnUnityAdsReady(string placementId)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidError(string message)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        //throw new System.NotImplementedException();
        //mute the audio
        audio.mute = true;
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        //throw new System.NotImplementedException();
        
        switch (showResult)
        {
            case ShowResult.Failed:
                //brtw user kalau failed
                break;
            case ShowResult.Skipped:
                break;
            case ShowResult.Finished:
                if (placementId == rewardedVideoAD) 
                {
                    Debug.Log("reward the player");
                    wheel.startSpin();
                }
                if (placementId == intersitialAD) 
                { 
                    Debug.Log("finish interstatimal ads");
                    
                }

                break;
        }
        audio.mute = false;
    }
    /*
    public void OnUnityAdsDidFinish( ShowResult showResult)
    {
        //throw new System.NotImplementedException();
        
        switch (showResult)
        {
            case ShowResult.Failed:
                //brtw user kalau failed
                break;
            case ShowResult.Skipped:
                break;
            case ShowResult.Finished:
                break;
                
        }
        audio.mute = false;
    }
    */

}
