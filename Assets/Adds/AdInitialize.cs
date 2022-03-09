using UnityEngine;
using GoogleMobileAds.Api;

public class AdInitialize : MonoBehaviour
{
    void Awake()
    {
        MobileAds.Initialize(status => { });
    }
}

