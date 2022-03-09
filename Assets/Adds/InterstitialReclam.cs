using GoogleMobileAds.Api;
using UnityEngine;

public class InterstitialReclam : MonoBehaviour
{
    private InterstitialAd interstitial;
    private const string adUnitId = "ca-app-pub-3940256099942544/1033173712";

    private void OnEnable()
    {
        interstitial = new InterstitialAd(adUnitId);
        AdRequest request = new AdRequest.Builder().Build();
        interstitial.LoadAd(request);
    }

    public void Show()
    {
        if (interstitial.IsLoaded())
        {
            interstitial.Show();
        }
    }
}
