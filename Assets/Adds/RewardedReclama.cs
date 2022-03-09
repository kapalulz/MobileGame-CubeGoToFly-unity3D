using GoogleMobileAds.Api;
using UnityEngine;
using UnityEngine.UI;

public class RewardedReclama : MonoBehaviour
{
    private RewardedAd rewardedAd;
    private const string adUnitId = "ca-app-pub-3940256099942544/5224354917";
    public static bool addWatched = false;

    private void OnEnable()
    {
        rewardedAd = new RewardedAd(adUnitId);
        AdRequest request = new AdRequest.Builder().Build();
        rewardedAd.LoadAd(request);
        rewardedAd.OnUserEarnedReward += GetAdditionHealth;
    }

    public void GetAdditionHealth(object sender, Reward args)
    {
        Player.health = 3;
    }

    public void Show()
    {
        if (rewardedAd.IsLoaded())
        {
            rewardedAd.Show();
            addWatched = true;
            Time.timeScale = 0f;
        }
    }
}