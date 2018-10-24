using UnityEngine;
using System.Collections;
using ChartboostSDK;
using UnityEngine.UI;

public class main_ads : MonoBehaviour {

    public Button GoldPlus;

    // Use this for initialization
    void Start () {
        Chartboost.cacheRewardedVideo(CBLocation.MainMenu);
    }
    void OnEnable()
    {
        // Listen related event
        Chartboost.didCompleteRewardedVideo += didCompleteRewardedVideo;
    }
    void OnDisable()
    {
        // Remove handler
        Chartboost.didCompleteRewardedVideo -= didCompleteRewardedVideo;
    }
    public void WatchRewardedVideo()
    {
        Chartboost.showRewardedVideo(CBLocation.MainMenu);
    }
    void didCompleteRewardedVideo(CBLocation MainMenu, int reward)
    {
        PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") + 250);
    }
    void Update () {
        if (Chartboost.hasRewardedVideo(CBLocation.MainMenu))
        {
            GoldPlus.interactable = true;
        }
        else
        {
            GoldPlus.interactable = false;
        }
    }
}
