using UnityEngine;
using System.Collections;
using GoogleMobileAds;
using GoogleMobileAds.Api;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ads : MonoBehaviour {

	bool AdShowed = true;
    private BannerView bannerView;
    private InterstitialAd interstitial;
    // Use this for initialization
    void Awake () {
        if (PlayerPrefs.GetInt("RemoveAds") == 0) {
            //ca-app-pub- Banner
            //ca-app-pub- Full

            interstitial = new InterstitialAd("ca-app-pub-");
            interstitial.LoadAd(new AdRequest.Builder().Build());

            bannerView = new BannerView("ca-app-pub-", AdSize.SmartBanner, AdPosition.Top);
            bannerView.LoadAd(new AdRequest.Builder().Build());
        }
    }
    void Start() {
        bannerView.Show();
    }
    // Update is called once per frame
    void Update () {
        if (PlayerPrefs.GetInt("RemoveAds") == 0) {
		    if (PlayerPrefs.GetInt ("GameOver") == 1 && AdShowed) {
			    if (interstitial.IsLoaded()) {
                    interstitial.Show();
                    AdShowed = false;
			    }
		    }
		    if (PlayerPrefs.GetInt ("GameOver") == 0) {
			    AdShowed = true;
		    }
        }
    }
}
